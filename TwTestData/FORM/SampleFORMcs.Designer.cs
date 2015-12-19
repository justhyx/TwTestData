namespace TwTestData.FORM
{
    partial class SampleFORMcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnloadObv = new System.Windows.Forms.Button();
            this.BtnLoadFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filesTable = new XPTable.Models.Table();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnAnalayis = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.obvpage = new System.Windows.Forms.TabPage();
            this.table1 = new XPTable.Models.Table();
            this.mespage = new System.Windows.Forms.TabPage();
            this.table3 = new XPTable.Models.Table();
            this.Anapage = new System.Windows.Forms.TabPage();
            this.table4 = new XPTable.Models.Table();
            this.fileColumn = new XPTable.Models.ColumnModel();
            this.textColumn1 = new XPTable.Models.TextColumn();
            this.btnRemoveCol = new XPTable.Models.ButtonColumn();
            this.comboBoxColumn1 = new XPTable.Models.ComboBoxColumn();
            this.progressBarColumn1 = new XPTable.Models.ProgressBarColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filesTable)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.obvpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.mespage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).BeginInit();
            this.Anapage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnloadObv
            // 
            this.BtnloadObv.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnloadObv.Location = new System.Drawing.Point(6, 20);
            this.BtnloadObv.Name = "BtnloadObv";
            this.BtnloadObv.Size = new System.Drawing.Size(137, 38);
            this.BtnloadObv.TabIndex = 0;
            this.BtnloadObv.Text = "添加观察数据";
            this.BtnloadObv.UseVisualStyleBackColor = true;
            this.BtnloadObv.Click += new System.EventHandler(this.BtnloadObv_Click);
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.BtnLoadFile.Location = new System.Drawing.Point(6, 20);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(137, 35);
            this.BtnLoadFile.TabIndex = 1;
            this.BtnLoadFile.Text = "添加测量数据";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnloadObv);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "观察数据";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.filesTable);
            this.groupBox2.Controls.Add(this.BtnLoadFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 433);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "后台数据";
            // 
            // filesTable
            // 
            this.filesTable.ColumnModel = this.fileColumn;
            this.filesTable.Location = new System.Drawing.Point(6, 61);
            this.filesTable.Name = "filesTable";
            this.filesTable.Size = new System.Drawing.Size(294, 366);
            this.filesTable.TabIndex = 0;
            this.filesTable.Text = "table2";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.BtnAnalayis);
            this.groupBox3.Location = new System.Drawing.Point(12, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(836, 71);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分析数据";
            // 
            // BtnAnalayis
            // 
            this.BtnAnalayis.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.BtnAnalayis.Location = new System.Drawing.Point(6, 20);
            this.BtnAnalayis.Name = "BtnAnalayis";
            this.BtnAnalayis.Size = new System.Drawing.Size(137, 38);
            this.BtnAnalayis.TabIndex = 0;
            this.BtnAnalayis.Text = "分析定位准确度";
            this.BtnAnalayis.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.obvpage);
            this.tabControl1.Controls.Add(this.mespage);
            this.tabControl1.Controls.Add(this.Anapage);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.tabControl1.Location = new System.Drawing.Point(324, 166);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // obvpage
            // 
            this.obvpage.Controls.Add(this.table1);
            this.obvpage.Location = new System.Drawing.Point(4, 30);
            this.obvpage.Name = "obvpage";
            this.obvpage.Padding = new System.Windows.Forms.Padding(3);
            this.obvpage.Size = new System.Drawing.Size(520, 399);
            this.obvpage.TabIndex = 0;
            this.obvpage.Text = "观察数据";
            this.obvpage.UseVisualStyleBackColor = true;
            // 
            // table1
            // 
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.table1.Location = new System.Drawing.Point(3, 3);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(514, 393);
            this.table1.TabIndex = 0;
            this.table1.Text = "table1";
            // 
            // mespage
            // 
            this.mespage.Controls.Add(this.table3);
            this.mespage.Location = new System.Drawing.Point(4, 30);
            this.mespage.Name = "mespage";
            this.mespage.Padding = new System.Windows.Forms.Padding(3);
            this.mespage.Size = new System.Drawing.Size(520, 399);
            this.mespage.TabIndex = 1;
            this.mespage.Text = "后台数据";
            this.mespage.UseVisualStyleBackColor = true;
            // 
            // table3
            // 
            this.table3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table3.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.table3.Location = new System.Drawing.Point(3, 3);
            this.table3.Name = "table3";
            this.table3.Size = new System.Drawing.Size(514, 393);
            this.table3.TabIndex = 0;
            this.table3.Text = "table3";
            // 
            // Anapage
            // 
            this.Anapage.Controls.Add(this.table4);
            this.Anapage.Location = new System.Drawing.Point(4, 30);
            this.Anapage.Name = "Anapage";
            this.Anapage.Padding = new System.Windows.Forms.Padding(3);
            this.Anapage.Size = new System.Drawing.Size(520, 399);
            this.Anapage.TabIndex = 2;
            this.Anapage.Text = "分析结果";
            this.Anapage.UseVisualStyleBackColor = true;
            // 
            // table4
            // 
            this.table4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table4.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.table4.Location = new System.Drawing.Point(3, 3);
            this.table4.Name = "table4";
            this.table4.Size = new System.Drawing.Size(514, 393);
            this.table4.TabIndex = 0;
            this.table4.Text = "table4";
            // 
            // fileColumn
            // 
            this.fileColumn.Columns.AddRange(new XPTable.Models.Column[] {
            this.btnRemoveCol,
            this.textColumn1,
            this.comboBoxColumn1,
            this.progressBarColumn1});
            // 
            // btnRemoveCol
            // 
            this.btnRemoveCol.Sortable = false;
            this.btnRemoveCol.Text = "移除文件";
            this.btnRemoveCol.Width = 40;
            // 
            // SampleFORMcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 611);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(880, 650);
            this.Name = "SampleFORMcs";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定位准确度评估器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filesTable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.obvpage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.mespage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table3)).EndInit();
            this.Anapage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnloadObv;
        private System.Windows.Forms.Button BtnLoadFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnAnalayis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage obvpage;
        private System.Windows.Forms.TabPage mespage;
        private System.Windows.Forms.TabPage Anapage;
        private XPTable.Models.Table filesTable;
        private XPTable.Models.Table table1;
        private XPTable.Models.Table table3;
        private XPTable.Models.Table table4;
        private XPTable.Models.ColumnModel fileColumn;
        private XPTable.Models.ButtonColumn btnRemoveCol;
        private XPTable.Models.TextColumn textColumn1;
        private XPTable.Models.ComboBoxColumn comboBoxColumn1;
        private XPTable.Models.ProgressBarColumn progressBarColumn1;
    }
}