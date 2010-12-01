namespace LouMapInfoApp
{
    partial class ReportForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm2));
            this.customTabControl1 = new System.Windows.Forms.TabControl();
            this.tpageReport = new System.Windows.Forms.TabPage();
            this.reportBrowser = new System.Windows.Forms.WebBrowser();
            this.tpageBBCode = new System.Windows.Forms.TabPage();
            this.txtBBCode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCopyAllBBCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBBCodeDisplay = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBBCodeB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeU = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeI = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeCity = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBBCodeAlliance = new System.Windows.Forms.ToolStripMenuItem();
            this.customTabControl1.SuspendLayout();
            this.tpageReport.SuspendLayout();
            this.tpageBBCode.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customTabControl1
            // 
            this.customTabControl1.Controls.Add(this.tpageReport);
            this.customTabControl1.Controls.Add(this.tpageBBCode);
            this.customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTabControl1.HotTrack = true;
            this.customTabControl1.Location = new System.Drawing.Point(0, 0);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(707, 468);
            this.customTabControl1.TabIndex = 0;
            // 
            // tpageReport
            // 
            this.tpageReport.Controls.Add(this.reportBrowser);
            this.tpageReport.Location = new System.Drawing.Point(4, 22);
            this.tpageReport.Name = "tpageReport";
            this.tpageReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpageReport.Size = new System.Drawing.Size(699, 442);
            this.tpageReport.TabIndex = 0;
            this.tpageReport.Text = "Report";
            this.tpageReport.UseVisualStyleBackColor = true;
            // 
            // reportBrowser
            // 
            this.reportBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportBrowser.Location = new System.Drawing.Point(3, 3);
            this.reportBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.reportBrowser.Name = "reportBrowser";
            this.reportBrowser.Size = new System.Drawing.Size(693, 436);
            this.reportBrowser.TabIndex = 0;
            // 
            // tpageBBCode
            // 
            this.tpageBBCode.Controls.Add(this.txtBBCode);
            this.tpageBBCode.Controls.Add(this.toolStrip1);
            this.tpageBBCode.Location = new System.Drawing.Point(4, 22);
            this.tpageBBCode.Name = "tpageBBCode";
            this.tpageBBCode.Padding = new System.Windows.Forms.Padding(3);
            this.tpageBBCode.Size = new System.Drawing.Size(699, 442);
            this.tpageBBCode.TabIndex = 1;
            this.tpageBBCode.Text = "BBCode";
            this.tpageBBCode.UseVisualStyleBackColor = true;
            // 
            // txtBBCode
            // 
            this.txtBBCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBBCode.Location = new System.Drawing.Point(3, 28);
            this.txtBBCode.Multiline = true;
            this.txtBBCode.Name = "txtBBCode";
            this.txtBBCode.ReadOnly = true;
            this.txtBBCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBBCode.Size = new System.Drawing.Size(693, 411);
            this.txtBBCode.TabIndex = 1;
            this.txtBBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBBCode_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyAllBBCode,
            this.toolStripSeparator1,
            this.btnBBCodeDisplay});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(693, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCopyAllBBCode
            // 
            this.btnCopyAllBBCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyAllBBCode.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAllBBCode.Image")));
            this.btnCopyAllBBCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyAllBBCode.Name = "btnCopyAllBBCode";
            this.btnCopyAllBBCode.Size = new System.Drawing.Size(125, 22);
            this.btnCopyAllBBCode.Text = "Copy All to Clipboard";
            this.btnCopyAllBBCode.Click += new System.EventHandler(this.btnCopyAllBBCode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBBCodeDisplay
            // 
            this.btnBBCodeDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBBCodeDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBBCodeB,
            this.btnBBCodeU,
            this.btnBBCodeI,
            this.btnBBCodeS,
            this.btnBBCodeUrl,
            this.btnBBCodeCity,
            this.btnBBCodePlayer,
            this.btnBBCodeAlliance});
            this.btnBBCodeDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btnBBCodeDisplay.Image")));
            this.btnBBCodeDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBBCodeDisplay.Name = "btnBBCodeDisplay";
            this.btnBBCodeDisplay.Size = new System.Drawing.Size(119, 22);
            this.btnBBCodeDisplay.Text = "Displayed BBCode";
            this.btnBBCodeDisplay.ButtonClick += new System.EventHandler(this.btnBBCodeDisplay_ButtonClick);
            // 
            // btnBBCodeB
            // 
            this.btnBBCodeB.Checked = true;
            this.btnBBCodeB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeB.Name = "btnBBCodeB";
            this.btnBBCodeB.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeB.Text = "[b] [/b]";
            this.btnBBCodeB.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeU
            // 
            this.btnBBCodeU.Checked = true;
            this.btnBBCodeU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeU.Name = "btnBBCodeU";
            this.btnBBCodeU.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeU.Text = "[u] [/u]";
            this.btnBBCodeU.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeI
            // 
            this.btnBBCodeI.Checked = true;
            this.btnBBCodeI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeI.Name = "btnBBCodeI";
            this.btnBBCodeI.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeI.Text = "[i] [/i]";
            this.btnBBCodeI.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeS
            // 
            this.btnBBCodeS.Checked = true;
            this.btnBBCodeS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeS.Name = "btnBBCodeS";
            this.btnBBCodeS.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeS.Text = "[s] [/s]";
            this.btnBBCodeS.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeUrl
            // 
            this.btnBBCodeUrl.Checked = true;
            this.btnBBCodeUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeUrl.Name = "btnBBCodeUrl";
            this.btnBBCodeUrl.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeUrl.Text = "[url] [/url]";
            this.btnBBCodeUrl.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeCity
            // 
            this.btnBBCodeCity.Name = "btnBBCodeCity";
            this.btnBBCodeCity.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeCity.Text = "[city] [/city]";
            this.btnBBCodeCity.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodePlayer
            // 
            this.btnBBCodePlayer.Checked = true;
            this.btnBBCodePlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodePlayer.Name = "btnBBCodePlayer";
            this.btnBBCodePlayer.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodePlayer.Text = "[player] [/player]";
            this.btnBBCodePlayer.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // btnBBCodeAlliance
            // 
            this.btnBBCodeAlliance.Checked = true;
            this.btnBBCodeAlliance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBBCodeAlliance.Name = "btnBBCodeAlliance";
            this.btnBBCodeAlliance.Size = new System.Drawing.Size(178, 22);
            this.btnBBCodeAlliance.Text = "[alliance] [/alliance]";
            this.btnBBCodeAlliance.Click += new System.EventHandler(this.btnBBCode_Click);
            // 
            // ReportForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 468);
            this.Controls.Add(this.customTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.customTabControl1.ResumeLayout(false);
            this.tpageReport.ResumeLayout(false);
            this.tpageBBCode.ResumeLayout(false);
            this.tpageBBCode.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl customTabControl1;
        private System.Windows.Forms.TabPage tpageReport;
        private System.Windows.Forms.TabPage tpageBBCode;
        private System.Windows.Forms.WebBrowser reportBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCopyAllBBCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnBBCodeDisplay;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeB;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeU;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeI;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeS;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeUrl;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeCity;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodePlayer;
        private System.Windows.Forms.ToolStripMenuItem btnBBCodeAlliance;
        private System.Windows.Forms.TextBox txtBBCode;
    }
}