using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTable.Models;
using XPTable.Editors;
using TwTestData.ALGORITHM;
using System.Diagnostics;
using System.IO;
using TwTestData.DRIVER;

namespace TwTestData.FORM
{
    /// <summary>
    /// Create By HYX 2016.12.19
    /// 不管那么多了，界面，数据，算法，都在这里找。
    /// 
    /// 五步操作。
    /// 1. 加载文件
    ///    done 打开dialog 
    ///    done 选择文件
    ///    将文件名加载到内存组中（地址名唯一）
    ///    将最新的文件映射到界面上
    /// 2. 加载定位数据
    ///    按文件名逐数据加载到基本内存上
    ///    将内存中数据以唯一化简化
    ///    映射到界面上
    /// 3. 加载观察数据
    ///    打开dialog 
    ///    选择文件
    ///    按文件名逐数据加载到基本内存上
    ///    将内存中数据以唯一化简化
    /// 4. 分析
    ///    分析项目
    ///    1. 观察组数
    ///    2. 观察组对应定位组记录数
    ///    3. 各定位平均点及观察点的距离
    ///    4. 各定位点的准确度标准差
    ///    5. 总误差率
    ///    6. 总方差
    ///    7. 总偏移修正距离
    /// 5. 结果输出
    ///    
    /// </summary>
    public partial class SampleFORMcs : Form
    {
        public SampleFORMcs()
        {
            InitializeComponent();
            InitTable();
        }

     

        public void InitTable()
        {
            ButtonColumn btnRemoveCol = new ButtonColumn()
            {
                Sortable = false,
                Text = "移除文件",
                Width = 60,
            };
            TextColumn txtFilePathColumn = new TextColumn()
            {
                Text = "文件地址",
                Width = 350,
                Editable = false,
                Selectable = false
            };

            var editor = new ComboBoxCellEditor();
            editor.Items.AddRange(new Object[] {
                LocationDateSource.GPS,
                LocationDateSource.AMAP,
                LocationDateSource.MINIGPS
    });
            editor.SelectedIndex = 0;
            // editor.SelectedIndexChanged += new EventHandler(combolist_ChangeData);

            ComboBoxColumn cbbDataTypeColumn = new ComboBoxColumn()
            {
                Text = "数据类型",
                Width = 80,
                Editor = editor
            };
            //ProgressBarColumn progressBarLoadColumn = new ProgressBarColumn();
            //// 
            //// progressBarLoadColumn
            //// 
            //progressBarLoadColumn.Text = "加载进度";
            //progressBarLoadColumn.Width = 200;
            //progressBarLoadColumn.Text = "加载进度";


            // 
            // fileColumn
            // 
            fileColumn.Columns.AddRange(new Column[] {
            btnRemoveCol,
            txtFilePathColumn,
            cbbDataTypeColumn
});
            //progressBarLoadColumn});


            this.tableObv.ColumnModel = new ColumnModel(new Column[]
            {
                    NewTxtColumn("Begin"),
                    NewTxtColumn("End"),
                    NewTxtColumn("latitude"),
                    NewTxtColumn("longitude"),
                    NewTxtColumn("address"),
                    NewTxtColumn("imei"),
            });
            this.tableObv.TableModel = new TableModel();


            this.tableData.ColumnModel = new ColumnModel(new Column[] {
                   NewTxtColumn("index"),
                   NewTxtColumn("id"),
                   NewTxtColumn("IMEI"),
                   NewTxtColumn("timemark"),
                   NewTxtColumn("latitude"),
                   NewTxtColumn("longitude"),
                   NewTxtColumn("address"),
                   NewTxtColumn("type"),
                   NewTxtColumn("filesource"),
        });


            this.tableData.TableModel = new TableModel();

            this.tableResult.ColumnModel = new ColumnModel(new Column[] {
                new TextColumn(), new NumberColumn(),
                new TextColumn(), new NumberColumn(),
                new TextColumn(), new NumberColumn(),
                new TextColumn(), new NumberColumn(),
                 new TextColumn(), new NumberColumn(),});

            this.tableResult.TableModel = new TableModel();

        }

        private static TextColumn NewTxtColumn(string colname)
        {
            return new TextColumn(colname) { Editable = false, Selectable = false, Sortable = false };
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog()
            {
                Title = "ResultSave",
                InitialDirectory = Application.StartupPath,
                Filter = "*.*|*.txt",
                DefaultExt = "*.txt",
                AddExtension = true,
                ValidateNames = true,
            };

            if (DialogResult.OK == saveDialog.ShowDialog())
            {
                if (TxtHelper.Save(saveDialog.FileName, resultReport, UTF8Encoding.UTF8))
                {
                    MessageBox.Show("Success Save Result Report!");
                }
            }
        }

        /// <summary>
        /// 加载观察文件，只考察文件的存在，不考察有效性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "Excel2007-2015|*.xlsx|Excel 97-2003|*.xls|分隔的数据格式|*.cvs|普通数据|*.*",
                Title = "加载观察文件",
                //              DefaultExt = "Excel2007-2015|*.xlsx",
                Multiselect = true,
                CheckFileExists = true,
            };
            LocationDateSource sourcetype = LocationDateSource.GPS;
            if (DialogResult.OK == dialog.ShowDialog())
            {
                if (DialogResult.Yes == MessageBox.Show("Is Single DataType?", "DataType", MessageBoxButtons.YesNo))
                {
                    var form = new FORM.FormDataType();
                    form.ShowDialog(this);
                    sourcetype = form.key;
                    form.Close();
                }

                foreach (var file in dialog.FileNames)
                {
                    try //有可能重复加载，报错的话，就截取跳过
                    {
                        filepaths.Add(file, sourcetype);
                        //filesTable.TableModel.Rows.Add(new Row(new string[] { "移除", file, sourcetype.ToString() }));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                FillfilesTable();
            }
        }

        //刷新截取类
        private void FillfilesTable()
        {
            filesTable.BeginUpdate();
            Row[] lr = new Row[filepaths.Count];
            var i = 0;
            foreach (var kp in filepaths)
            {
                lr[i++] = new Row(new string[] { "移除", kp.Key, kp.Value.ToString() }) { Tag = kp.Key };
            }

            filesTable.TableModel.Rows.Clear();
            filesTable.TableModel.Rows.AddRange(lr);
            filesTable.TableModel.RowHeight = 24;
            filesTable.EndUpdate();
        }

        private void BtnloadObv_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "Excel2007-2015|*.xlsx|Excel 97-2003|*.xls",
                Title = "加载观察文件",
                DefaultExt = "Excel2007-2015|*.xlsx",
                Multiselect = false,
                CheckFileExists = true,
            };

            if (DialogResult.OK == dialog.ShowDialog())
            {
                var f = dialog.FileName;
                obvdata.Clear();
                switch (Path.GetExtension(f).ToLower())
                {
                    case ".xls":
                        obvdata.AddRange(FileReader.ReadXLS(f));
                        break;
                    case ".xlsx":
                        obvdata.AddRange(FileReader.ReadXLSX(f));
                        break;
                    default:
                        Debug.WriteLine("UnknowFileType");
                        break;
                }

                fillObvTable();
                tabControl1.SelectedIndex = 0;
            }
        }
        private void fillObvTable()
        {
            var rows = new Row[obvdata.Count];
            int i = 0;
            foreach (var obv in obvdata)
            {
                rows[i++] = new Row(new string[] {
                    obv.Begin.ToString(),
                    obv.End.ToString(),
                    obv.Latitude.ToString(),
                    obv.Longitude.ToString(),
                    obv.Address,
                    obv.TestIMEIGroup.Aggregate((s1,s2)=>(s1 +" "+s2))
                });
            }
            tableObv.BeginUpdate();
            tableObv.TableModel.Rows.Clear();
            tableObv.TableModel.Rows.AddRange(rows);
            tableObv.TableModel.RowHeight = 20;
            tableObv.EndUpdate();
        }
        private void btnLocationData_Click(object sender, EventArgs e)
        {
            mesdata.Clear();
            foreach (var kp in filepaths)
            {
                if (File.Exists(kp.Key))
                {
                    var name = Path.GetFileNameWithoutExtension(kp.Key);
                    try
                    {
                        switch (Path.GetExtension(kp.Key).ToLower())
                        {
                            case ".xls":
                                mesdata.Add(name, FileReader.ReadXLS(kp.Key, kp.Value));
                                break;
                            case ".xlsx":
                                mesdata.Add(name, FileReader.ReadXLSX(kp.Key, kp.Value));
                                break;
                            //case ".xml":
                            //    mesdata.Add(name, FileReader.ReadXML(kp.Key, kp.Value));
                            //    break;
                            //case ".cvs":
                            //    break;
                            default:
                                MessageBox.Show("Unknow File TYPE!");
                                break;
                        }
                        Debug.WriteLine("Data Loaded", kp.Key);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            FillDataTable();
            tabControl1.SelectedIndex = 1;
        }

        private void FillDataTable()
        {
            this.tableData.BeginUpdate();
            List<Row> lr = new List<Row>();
            var j = 0; var i = 0;

            foreach (var filedata in mesdata)
            {
                i++;
                foreach (var rd in filedata.Value)
                {
                    lr.Add(new Row(new string[] {
                        rd.TestId.ToString(),
                        rd.ServerID.ToString(),
                        rd.IMEI,
                        rd.LocationTime.ToString(),
                        rd.Latitude.ToString(),
                        rd.Longitude.ToString(),
                        rd.LocationAddress,
                        rd.DataType.ToString(),
                        filedata.Key
                    }));
                    j++;
                }

            }

            this.tableData.TableModel.Rows.Clear();
            this.tableData.TableModel.Rows.AddRange(lr.ToArray());
            this.tableData.TableModel.RowHeight = 24;
            this.tableData.EndUpdate();
            MessageBox.Show(string.Format("Done Add {0} Files， Total {1} ROWs Data", i, j));
        }

        private void BtnAnalayis_Click(object sender, EventArgs e)
        {
            var rows = new List<Row>();

            var locadata = new List<LocationDataRecord>();

            foreach (var vv in mesdata.Values)
            {
                locadata.AddRange(vv);
            }

            //分析对象
            // 1. 分组分析 
            //按观察数据对当前定位数据分组。定位类型-》 时间序列 -》
            // 对每组的定位数据做归一化处理，然后先对当前GPS定位 进行准确度分析
            // 比照GPS定位记录，对两种LBS定位进行比照式计算。
            // 比照GPS平均值 看看 GPS误差之间是否存在方向性偏差。
            // 2. 总比照对象列表
            // 对全部定位记录的偏差 归一化，确认总偏差度。
            //

            var Ct = new CellStyle() { Font = new Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))) };
            /*
            观察组数{}
            测试设备数
            GPS测量点数：{}、Gaode测量点数：{}、MiniGPS测量点数：{}、

            */
            rows.Add(new Row(new Cell[] {
                new Cell("观察组数："), new Cell(obvdata.Count, Ct) }));
            rows.Add(new Row(new Cell[] {
                new Cell("测试设备数："), new Cell(FixedAlgorithm.DistinctIMEI(obvdata).Count()   ) }));
            rows.Add(new Row(new Cell[] {
                new Cell("GPS测量点数："),new Cell(locadata.Count(s => s.DataType == LocationDateSource.GPS)),
                new Cell("Gaode 测量点数："),new Cell(locadata.Count(s => s.DataType == LocationDateSource.AMAP)),
                new Cell("MiniGPS 测量点数："),new Cell(locadata.Count(s => s.DataType == LocationDateSource.MINIGPS)), }));

            /*
            组号：{index}
            测定时间：开始：{Obv.Begin}，结束：{Obv.End}
            参与测试设备：{Obv.IMEI}
            观察位置点：{Obv.Latitude}：{Obv.Lontitude}
            GPS测量点数：{}、Gaode测量点数：{}、MiniGPS测量点数：{}、
            GPS 平均误差：{}、Gaode 平均误差：、MiniGPS 平均误差：
            GPS 归一化标准差：{}、GPS 归一化标准差：{}、GPS 归一化标准差：{}
            */
            var i = 0;
            double sampleLatitude, sampleLongitude;
            foreach (var obv in obvdata)
            {

                var sample = from loca in locadata
                             where (loca.LocationTime >= obv.Begin && loca.LocationTime <= obv.End)
                             select loca;

                //locadata. (s => s.LocationTime > obv.Begin && s.LocationTime < obv.End);

                rows.Add(new Row(new Cell[] { new Cell("组号："), new Cell(++i), }));

                rows.Add(new Row(new Cell[] {
                    new Cell(" 测定开始时间："+ obv.Begin.ToString("yyyy/MM/dd  hh:mm")), new Cell(),
                    new Cell(" 测定结束时间："+ obv.End.ToString("yyyy/MM/dd  hh:mm")), }));
                rows.Add(new Row(new Cell[] {
                    new Cell("GPS测量点数："),new Cell(FixedAlgorithm.Count(sample,LocationDateSource.GPS)),
                    new Cell("Gaode 测量点数："),new Cell(FixedAlgorithm.Count(sample,LocationDateSource.AMAP)),
                    new Cell("MiniGPS 测量点数："),new Cell(FixedAlgorithm.Count(sample,LocationDateSource.MINIGPS)), }));

                /*
        GPS 平均误差：{ }、Gaode 平均误差：、MiniGPS 平均误差：
        GPS归一化标准差：{ }、GPS 归一化标准差：{ }、GPS 归一化标准差：{ }、            
        */

                sampleLatitude = FixedAlgorithm.AvgLatitude(sample, LocationDateSource.GPS, obv);
                sampleLongitude = FixedAlgorithm.AvgLongitude(sample, LocationDateSource.GPS, obv);
                rows.Add(new Row(new Cell[] {
                new Cell("GPS 纬度平均数："),new Cell(sampleLatitude),
                new Cell("GPS 经度平均数："),new Cell(sampleLongitude),
                new Cell("GPS 标准差："), new Cell(FixedAlgorithm.Variance(sample,LocationDateSource.GPS,obv.Latitude,obv.Longitude)),}));

                rows.Add(new Row(new Cell[] {
                new Cell("Gaode 纬度平均数："),new Cell(FixedAlgorithm.AvgLatitude(sample,LocationDateSource.AMAP,obv)),
                new Cell("Gaode 经度平均数："),new Cell(FixedAlgorithm.AvgLongitude(sample,LocationDateSource.AMAP,obv)),
                new Cell("Gaode 标准差："), new Cell(FixedAlgorithm.Variance(sample,LocationDateSource.AMAP,obv.Latitude,obv.Longitude)),}));

                rows.Add(new Row(new Cell[] {
                new Cell("MiniGPS 纬度平均数："),new Cell(FixedAlgorithm.AvgLatitude(sample,LocationDateSource.MINIGPS,obv)),
                new Cell("MiniGPS 经度平均数："),new Cell(FixedAlgorithm.AvgLongitude(sample,LocationDateSource.MINIGPS,obv)),
                new Cell("MiniGPS 标准差："), new Cell(FixedAlgorithm.Variance(sample,LocationDateSource.MINIGPS,obv.Latitude,obv.Longitude)),}));
            }


            //rows.Add(new Row(new Cell[] {
            //    new Cell("GPS 纬度平均误差："),   new Cell(),
            //    new Cell("GPS 纬度平均误差："),   new Cell("GPS 纬度平均误差："),
            //    new Cell("GPS 归一化标准差："), new Cell(),}));

            //rows.Add(new Row(new Cell[] {
            //    new Cell("Gaode 纬度平均误差："), new Cell("Gaode 纬度平均误差："),
            //    new Cell("Gaode 纬度平均误差："), new Cell("Gaode 纬度平均误差："),
            //    new Cell("Gaode 归一化标准差："), new Cell(obvdata.Count),}));
            //rows.Add(new Row(new Cell[] {
            //    new Cell("MiniGPS 纬度平均误差："),   new Cell("MiniGPS 纬度平均误差："),
            //    new Cell("MiniGPS 纬度平均误差："),   new Cell("MiniGPS 纬度平均误差："),
            // new Cell("MiniGPS 归一化标准差："), new Cell(obvdata.Count),}));

            resultReport.Clear();

            foreach (var r in rows)
            {
                resultReport.Append("[");
                foreach (Cell c in r.Cells)
                {
                    if (c != null)
                    {
                        if (c.Data != null)
                        {
                            resultReport.Append(c.Data.ToString() + ",");
                            Debug.Write("[" + c.Data.ToString() + "]");
                        }
                        else
                        {
                            if (c.Text != null)
                            {
                                resultReport.Append(c.Text.ToString() + ",");
                                Debug.Write("[" + c.Text.ToString() + "]");
                            }
                        }
                    }
                }
                resultReport.AppendLine("]");
                Debug.WriteLine("");
            }

            tableResult.BeginUpdate();
            tableResult.TableModel.Rows.Clear();
            tableResult.TableModel.Rows.AddRange(rows.ToArray());
            tableResult.TableModel.RowHeight = 20;
            tableResult.EndUpdate();

            tabControl1.SelectedIndex = 2;
        }


        /// <summary>
        /// 地址列表
        /// </summary>
        private Dictionary<string, LocationDateSource> filepaths = new Dictionary<string, LocationDateSource>();

        /// <summary>
        /// 加载的定位数据
        /// </summary>
        private Dictionary<string, List<LocationDataRecord>> mesdata = new Dictionary<string, List<LocationDataRecord>>();

        /// <summary>
        /// 观察数据
        /// </summary>
        private List<ObservedValueOfFixed> obvdata = new List<ObservedValueOfFixed>();


        /// <summary>
        /// 分析报告
        /// </summary>
        private StringBuilder resultReport = new StringBuilder();

        private void filesTable_CellButtonClicked(object sender, XPTable.Events.CellButtonEventArgs e)
        {
            Debug.WriteLine("Click ROW:{0},COL:{1}", filesTable_row, filesTable_col);

            ///
            string file = (string)filesTable.TableModel.Rows[filesTable_row].Tag;
            if (DialogResult.Yes == MessageBox.Show("Do you want to remove the file /n [" + file + "] /n from the list?",
                "移除操作",
                 MessageBoxButtons.YesNo))
            {
                filepaths.Remove(file);
                FillfilesTable();
            }
        }



        private void filesTable_CellPropertyChanged(object sender, XPTable.Events.CellEventArgs e)
        {
            Debug.WriteLine("filesTable_CellPropertyChanged!! \n Time{0},\n source {1}:{2} \n Value From {3} become {4} \n", DateTime.Now.ToLongTimeString(), e.Row, e.Column, e.OldValue, e.Cell.Data);

            if (e.Column != 2) return;

            string file = (string)filesTable.TableModel.Rows[e.Row].Tag;
            filepaths[file] = (LocationDateSource)Enum.Parse(typeof(LocationDateSource), e.Cell.Text);


        }
        /// 控件的SB的局限性 ，
        /// 只能通过CellEnter的方式确认当前被点击的对象坐标 
        private int filesTable_row, filesTable_col;

        private void filesTable_CellMouseEnter(object sender, XPTable.Events.CellMouseEventArgs e)
        {
            filesTable_row = e.Row;
            filesTable_col = e.Column;
            Debug.WriteLine("ROW:{0},COL:{1}", filesTable_row, filesTable_col);
        }



    }
}