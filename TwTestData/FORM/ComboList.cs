using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwTestData
{
    public partial class ComboList : Panel
    {
        public ComboList()
        {
            InitializeComponent();
        }
        #region view
        private static Font standfont = new Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        public void AddItem(string fileName)
        {
            Label ItemLable = new Label();
            LinkLabel DeleteLable = new LinkLabel();
            ListBox ChoiceList = new ListBox();

            // 
            // ItemLable
            // 
            ItemLable.AutoSize = true;
            ItemLable.Font = standfont;
            ItemLable.Location = new System.Drawing.Point(25, 27);
            ItemLable.Name = "ItemLable";
            ItemLable.Size = new System.Drawing.Size(43, 20);
            ItemLable.Text = fileName;
            // 
            // DeleteLable
            // 
            DeleteLable.AutoSize = true;
            DeleteLable.Font = standfont;
            DeleteLable.Location = new System.Drawing.Point(396, 27);
            DeleteLable.Name = "DeleteLable";
            DeleteLable.Size = new System.Drawing.Size(37, 20);
            DeleteLable.TabStop = true;
            DeleteLable.Text = "删除";
            DeleteLable.Tag = fileName;
            // 
            // ChoiceList
            // 
            ChoiceList.Font = standfont; ;
            ChoiceList.FormattingEnabled = true;
            ChoiceList.ItemHeight = 20;
            ChoiceList.Location = new System.Drawing.Point(195, 25);
            ChoiceList.Name = "ChoiceList";
            ChoiceList.Size = new System.Drawing.Size(195, 24);
            ChoiceList.DataSource = DataType;

        }

        private void FlashComponent()
        {
            this.SuspendLayout();
            foreach (var key in fileItem.Keys)
            {
                AddItem(key);
                NextRowLocation();
            }
            this.ResumeLayout();
        }
        private void NextRowLocation()
        {

        }
        #endregion view


        private Dictionary<string, int> fileItem = new Dictionary<string, int>();
        private Dictionary<string, int> DataType = new Dictionary<string, int>();
        public void SetColumn(string[] columnName)
        {
            int i = 0;
            foreach (var str in columnName)
            {
                fileItem.Add(str, i++);
            }
            FlashComponent();
        }

        public void SetColumn(IEnumerable<KeyValuePair<string, int>> columnName)
        {
            fileItem.Concat(columnName);
            FlashComponent();
        }

      

      
     
    }
}
