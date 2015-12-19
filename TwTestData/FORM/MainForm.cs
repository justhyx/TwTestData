using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;
using XPTable.Models;
using XPTable.Editors;

namespace TwTestData
{
    public partial class MainForm : Form
    {
        private Dictionary<string, int> datafiles = new Dictionary<string, int>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void RefreshTable(EventArgs e)
        {
            base.OnLoad(e);

            this.DataFileTable.BeginUpdate();

            TextColumn fileNameColumn = new TextColumn("文件名");
            fileNameColumn.Editable = false;
            fileNameColumn.Sortable = false;

            var boxeditor = new ComboBoxCellEditor();
            boxeditor.Items.AddRange(new string[] { "GPS", "AMap", "MiniGps" });

            ComboBoxColumn comboBoxColumn = new ComboBoxColumn("定位数据源");
            comboBoxColumn.Sortable = false;
            comboBoxColumn.Editor = boxeditor;

            //comboBoxColumn.Text = "DataSource";
            //checkBoxColumn.Width = 94;

            ButtonColumn buttonColumn = new ButtonColumn("排除文件");

            this.tableColumn.Columns.AddRange(new Column[] { fileNameColumn, comboBoxColumn, buttonColumn });
            
            this.DataFileTable.EndUpdate();
        }

        private void btnLoadLocationData_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title = "加载数据源",
                Multiselect = true,
                InitialDirectory = Application.StartupPath,
                Filter = "Excel 97-2003|*.xls|Excel 2007-2015|*.xlsx|文本数据源|*.csv|其他|*.*",
                CheckFileExists = true
            };

            if (DialogResult.OK == dialog.ShowDialog())
            {
                var files = dialog.FileNames;

                RefreshTable(e);
            }
        }


    }


}

