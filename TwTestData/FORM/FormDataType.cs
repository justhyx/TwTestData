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
    public partial class FormDataType : Form
    {
        public LocationDateSource key;

        public FormDataType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = LocationDateSource.GPS;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = LocationDateSource.AMAP;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            key = LocationDateSource.MINIGPS;
            this.Hide();
        }
    }
}
