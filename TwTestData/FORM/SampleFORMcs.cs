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
                new TextColumn("Begin") { Editable = false, Selectable = false, Sortable = false },
                new TextColumn("End") { Editable = false, Selectable = false, Sortable = false },
                new TextColumn("latitude") { Editable = false, Selectable = false, Sortable = false },
                new TextColumn("longitude") { Editable = false, Selectable = false, Sortable = false },
                new TextColumn("address") { Editable = false, Selectable = false, Sortable = false },
                new TextColumn("imei") { Editable = false, Selectable = false, Sortable = false },
            });
            this.tableObv.TableModel = new TableModel();


            this.tableData.ColumnModel = new ColumnModel(new Column[] {
            new TextColumn("index") { Editable = false, Selectable = false, Sortable = false },
          new TextColumn("id") { Editable = false, Selectable = false, Sortable = false },
          new TextColumn("IMEI") { Editable = false, Selectable = false, Sortable = true },
           new TextColumn("timemark") { Editable = false, Selectable = false, Sortable = true },
             new TextColumn("latitude") { Editable = false, Selectable = false, Sortable = false },
            new TextColumn("longitude") { Editable = false, Selectable = false, Sortable = false },
            new TextColumn("address") { Editable = false, Selectable = false, Sortable = false },
            new TextColumn("type") { Editable = false, Selectable = false, Sortable = false },
              new TextColumn("filesource") { Editable = false, Selectable = false, Sortable = false }
        });


            this.tableData.TableModel = new TableModel();

            this.tableResult.ColumnModel = new ColumnModel();
            this.tableResult.TableModel = new TableModel();

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
                            case ".xml":
                                mesdata.Add(name, FileReader.ReadXML(kp.Key, kp.Value));
                                break;
                            case ".cvs":
                                break;
                            default:
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
            MessageBox.Show(string.Format("Done Add {0} Files， TOtal {1} ROWs Data", i, j));
        }

        private void BtnAnalayis_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 2;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

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