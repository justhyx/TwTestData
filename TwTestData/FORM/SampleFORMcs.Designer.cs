using XPTable.Editors;

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
            this.btnLocationData = new System.Windows.Forms.Button();
            this.BtnAnalayis = new System.Windows.Forms.Button();
            this.filesTable = new XPTable.Models.Table();
            this.fileColumn = new XPTable.Models.ColumnModel();
            this.filedata = new XPTable.Models.TableModel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.obvpage = new System.Windows.Forms.TabPage();
            this.tableObv = new XPTable.Models.Table();
            this.mespage = new System.Windows.Forms.TabPage();
            this.tableData = new XPTable.Models.Table();
            this.Anapage = new System.Windows.Forms.TabPage();
            this.tableResult = new XPTable.Models.Table();
            this.btn_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.obvpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableObv)).BeginInit();
            this.mespage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
            this.Anapage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnloadObv
            // 
            this.BtnloadObv.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnloadObv.Location = new System.Drawing.Point(302, 12);
            this.BtnloadObv.Name = "BtnloadObv";
            this.BtnloadObv.Size = new System.Drawing.Size(148, 40);
            this.BtnloadObv.TabIndex = 0;
            this.BtnloadObv.Text = "3. 添加观察数据";
            this.BtnloadObv.UseVisualStyleBackColor = true;
            this.BtnloadObv.Click += new System.EventHandler(this.BtnloadObv_Click);
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.BtnLoadFile.Location = new System.Drawing.Point(12, 12);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(135, 40);
            this.BtnLoadFile.TabIndex = 1;
            this.BtnLoadFile.Text = "1. 添加数据文件";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // btnLocationData
            // 
            this.btnLocationData.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.btnLocationData.Location = new System.Drawing.Point(153, 12);
            this.btnLocationData.Name = "btnLocationData";
            this.btnLocationData.Size = new System.Drawing.Size(143, 40);
            this.btnLocationData.TabIndex = 2;
            this.btnLocationData.Text = "2. 添加后台数据";
            this.btnLocationData.UseVisualStyleBackColor = true;
            this.btnLocationData.Click += new System.EventHandler(this.btnLocationData_Click);
            // 
            // BtnAnalayis
            // 
            this.BtnAnalayis.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.BtnAnalayis.Location = new System.Drawing.Point(456, 12);
            this.BtnAnalayis.Name = "BtnAnalayis";
            this.BtnAnalayis.Size = new System.Drawing.Size(152, 40);
            this.BtnAnalayis.TabIndex = 0;
            this.BtnAnalayis.Text = "4. 分析定位准确度";
            this.BtnAnalayis.UseVisualStyleBackColor = true;
            this.BtnAnalayis.Click += new System.EventHandler(this.BtnAnalayis_Click);
            // 
            // filesTable
            // 
            this.filesTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesTable.ColumnModel = this.fileColumn;
            this.filesTable.Location = new System.Drawing.Point(12, 58);
            this.filesTable.Name = "filesTable";
            this.filesTable.Size = new System.Drawing.Size(524, 541);
            this.filesTable.TabIndex = 0;
            this.filesTable.TableModel = this.filedata;
            this.filesTable.Text = "table2";
            this.filesTable.CellPropertyChanged += new XPTable.Events.CellEventHandler(this.filesTable_CellPropertyChanged);
            this.filesTable.CellMouseEnter += new XPTable.Events.CellMouseEventHandler(this.filesTable_CellMouseEnter);
            this.filesTable.CellButtonClicked += new XPTable.Events.CellButtonEventHandler(this.filesTable_CellButtonClicked);
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
            this.tabControl1.Location = new System.Drawing.Point(542, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 541);
            this.tabControl1.TabIndex = 0;
            // 
            // obvpage
            // 
            this.obvpage.Controls.Add(this.tableObv);
            this.obvpage.Location = new System.Drawing.Point(4, 30);
            this.obvpage.Name = "obvpage";
            this.obvpage.Padding = new System.Windows.Forms.Padding(3);
            this.obvpage.Size = new System.Drawing.Size(309, 507);
            this.obvpage.TabIndex = 0;
            this.obvpage.Text = "观察数据";
            this.obvpage.UseVisualStyleBackColor = true;
            // 
            // tableObv
            // 
            this.tableObv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableObv.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableObv.Location = new System.Drawing.Point(3, 3);
            this.tableObv.Name = "tableObv";
            this.tableObv.Size = new System.Drawing.Size(303, 501);
            this.tableObv.TabIndex = 0;
            this.tableObv.Text = "table1";
            // 
            // mespage
            // 
            this.mespage.Controls.Add(this.tableData);
            this.mespage.Location = new System.Drawing.Point(4, 30);
            this.mespage.Name = "mespage";
            this.mespage.Padding = new System.Windows.Forms.Padding(3);
            this.mespage.Size = new System.Drawing.Size(309, 507);
            this.mespage.TabIndex = 1;
            this.mespage.Text = "后台数据";
            this.mespage.UseVisualStyleBackColor = true;
            // 
            // tableData
            // 
            this.tableData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableData.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableData.Location = new System.Drawing.Point(3, 3);
            this.tableData.Name = "tableData";
            this.tableData.Size = new System.Drawing.Size(303, 501);
            this.tableData.TabIndex = 0;
            this.tableData.Text = "table3";
            // 
            // Anapage
            // 
            this.Anapage.Controls.Add(this.tableResult);
            this.Anapage.Location = new System.Drawing.Point(4, 30);
            this.Anapage.Name = "Anapage";
            this.Anapage.Padding = new System.Windows.Forms.Padding(3);
            this.Anapage.Size = new System.Drawing.Size(309, 507);
            this.Anapage.TabIndex = 2;
            this.Anapage.Text = "分析结果";
            this.Anapage.UseVisualStyleBackColor = true;
            // 
            // tableResult
            // 
            this.tableResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableResult.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableResult.Location = new System.Drawing.Point(3, 3);
            this.tableResult.Name = "tableResult";
            this.tableResult.Size = new System.Drawing.Size(303, 501);
            this.tableResult.TabIndex = 0;
            this.tableResult.Text = "table4";
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.btn_Export.Location = new System.Drawing.Point(614, 12);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(102, 40);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.Text = "5. 导出报告";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // SampleFORMcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 611);
            this.Controls.Add(this.btnLocationData);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.filesTable);
            this.Controls.Add(this.BtnLoadFile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnAnalayis);
            this.Controls.Add(this.BtnloadObv);
            this.MinimumSize = new System.Drawing.Size(880, 650);
            this.Name = "SampleFORMcs";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定位准确度评估器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.filesTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.obvpage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableObv)).EndInit();
            this.mespage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).EndInit();
            this.Anapage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnloadObv;
        private System.Windows.Forms.Button BtnLoadFile;
        private System.Windows.Forms.Button BtnAnalayis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage obvpage;
        private System.Windows.Forms.TabPage mespage;
        private System.Windows.Forms.TabPage Anapage;
        private XPTable.Models.Table filesTable;
        private XPTable.Models.Table tableObv;
        private XPTable.Models.Table tableData;
        private XPTable.Models.Table tableResult;
        private XPTable.Models.ColumnModel fileColumn;
        private XPTable.Models.TableModel filedata;
        private System.Windows.Forms.Button btnLocationData;
        private System.Windows.Forms.Button btn_Export;
    }
}