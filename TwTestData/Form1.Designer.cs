namespace TwTestData
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnloadLocationData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnloadLocationData
            // 
            this.btnloadLocationData.Location = new System.Drawing.Point(12, 12);
            this.btnloadLocationData.Name = "btnloadLocationData";
            this.btnloadLocationData.Size = new System.Drawing.Size(122, 23);
            this.btnloadLocationData.TabIndex = 0;
            this.btnloadLocationData.Text = "加载定位数据";
            this.btnloadLocationData.UseVisualStyleBackColor = true;
            this.btnloadLocationData.Click += new System.EventHandler(this.btnLoadLocationData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 374);
            this.Controls.Add(this.btnloadLocationData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnloadLocationData;
    }
}

