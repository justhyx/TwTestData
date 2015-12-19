namespace TwTestData.FORM
{
    partial class ComboListItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
           
            this.ItemLable = new System.Windows.Forms.Label();
            this.DeleteLable = new System.Windows.Forms.LinkLabel();
            this.ChoiceList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.ItemLable.AutoSize = true;
            this.ItemLable.Location = new System.Drawing.Point(14, 18);
            this.ItemLable.Name = "label1";
            this.ItemLable.Size = new System.Drawing.Size(41, 12);
            this.ItemLable.TabIndex = 0;
            this.ItemLable.Text = "label1";
            // 
            // linkLabel1
            // 
            this.DeleteLable.AutoSize = true;
            this.DeleteLable.Location = new System.Drawing.Point(361, 18);
            this.DeleteLable.Name = "linkLabel1";
            this.DeleteLable.Size = new System.Drawing.Size(65, 12);
            this.DeleteLable.TabIndex = 1;
            this.DeleteLable.TabStop = true;
            this.DeleteLable.Text = "linkLabel1";
            // 
            // comboBox1
            // 
            this.ChoiceList.FormattingEnabled = true;
            this.ChoiceList.Location = new System.Drawing.Point(97, 9);
            this.ChoiceList.Name = "comboBox1";
            this.ChoiceList.Size = new System.Drawing.Size(121, 20);
            this.ChoiceList.TabIndex = 2;
            // 
            // ComboListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChoiceList);
            this.Controls.Add(this.DeleteLable);
            this.Controls.Add(this.ItemLable);
            this.Name = "ComboListItem";
            this.Size = new System.Drawing.Size(447, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemLable;
        private System.Windows.Forms.LinkLabel DeleteLable;
        private System.Windows.Forms.ComboBox ChoiceList;

      //  Label ItemLable = new Label();
      //  LinkLabel DeleteLable = new LinkLabel();
      //  ListBox ChoiceList = new ListBox();
    }
}
