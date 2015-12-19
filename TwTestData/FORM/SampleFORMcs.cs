using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwTestData.FORM
{
   /// <summary>
   /// 不管那么多了，界面，数据，算法，都在这里找。
   /// </summary>
    public partial class SampleFORMcs : Form
    {
        public SampleFORMcs()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 加载观察文件，只考察文件的存在，不考察有效性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnloadObv_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "Excel 97-2003|*.xls|Excel2007-2015|*.xlsx|分隔的数据格式|*.cvs|普通数据|*.*",
                Title = "加载观察文件",
                DefaultExt = "Excel2007-2015|*.xlsx"

            };

        }

    

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "Excel 97-2003|*.xls|Excel2007-2015|*.xlsx|分隔的数据格式|*.cvs|普通数据|*.*",
                Title = "加载观察文件",
                DefaultExt = "Excel2007-2015|*.xlsx"

            };
        }




    }
}
