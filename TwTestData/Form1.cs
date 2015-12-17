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

namespace TwTestData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadLocationData_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title = "加载数据源",
                Multiselect = true,
                InitialDirectory = Application.StartupPath,
                Filter = "Excel 97-2003|*.xls|Excel 2007-2015|*.xlsx|其他|*.csv",
                CheckFileExists = true
            };

            if (DialogResult.OK == dialog.ShowDialog())
            {
                var files = dialog.FileNames;
                foreach (var filename in files)
                {
                    IExcelDataReader iReader = new exc
           


                }
            }
        }

    }


}
}
