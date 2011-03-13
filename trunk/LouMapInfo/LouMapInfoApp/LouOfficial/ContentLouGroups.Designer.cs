namespace LouMapInfoApp.LouOfficial
{
    partial class ContentLouGroups
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLouGroups));
            this.tbReportAllianceOverview = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.lstGroupReport = new System.Windows.Forms.ToolStripComboBox();
            this.btnGroupReportShow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGroupReportManage = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.tbReportAllianceOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReportAllianceOverview
            // 
            this.tbReportAllianceOverview.BackColor = System.Drawing.Color.White;
            this.tbReportAllianceOverview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbReportAllianceOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.lstGroupReport,
            this.btnGroupReportShow,
            this.toolStripSeparator1,
            this.btnGroupReportManage});
            this.tbReportAllianceOverview.Location = new System.Drawing.Point(0, 0);
            this.tbReportAllianceOverview.Name = "tbReportAllianceOverview";
            this.tbReportAllianceOverview.Size = new System.Drawing.Size(658, 25);
            this.tbReportAllianceOverview.TabIndex = 16;
            this.tbReportAllianceOverview.Text = "toolStrip1";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel6.Text = "Group Report: ";
            // 
            // lstGroupReport
            // 
            this.lstGroupReport.Name = "lstGroupReport";
            this.lstGroupReport.Size = new System.Drawing.Size(121, 25);
            // 
            // btnGroupReportShow
            // 
            this.btnGroupReportShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGroupReportShow.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupReportShow.Image")));
            this.btnGroupReportShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupReportShow.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnGroupReportShow.Name = "btnGroupReportShow";
            this.btnGroupReportShow.Size = new System.Drawing.Size(78, 22);
            this.btnGroupReportShow.Text = "Show Report";
            this.btnGroupReportShow.Click += new System.EventHandler(this.btnGroupReportShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGroupReportManage
            // 
            this.btnGroupReportManage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGroupReportManage.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupReportManage.Image")));
            this.btnGroupReportManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupReportManage.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnGroupReportManage.Name = "btnGroupReportManage";
            this.btnGroupReportManage.Size = new System.Drawing.Size(95, 22);
            this.btnGroupReportManage.Text = "Manage Groups";
            this.btnGroupReportManage.Click += new System.EventHandler(this.btnGroupReportManage_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(658, 222);
            this.pnlContent.TabIndex = 19;
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // ContentLouGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tbReportAllianceOverview);
            this.DoubleBuffered = true;
            this.Name = "ContentLouGroups";
            this.Size = new System.Drawing.Size(658, 247);
            this.tbReportAllianceOverview.ResumeLayout(false);
            this.tbReportAllianceOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbReportAllianceOverview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
        private System.Windows.Forms.ToolStripComboBox lstGroupReport;
        private System.Windows.Forms.ToolStripButton btnGroupReportShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGroupReportManage;


    }
}
