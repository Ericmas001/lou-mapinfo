namespace LouMapInfoApp
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnReportsLvl = new System.Windows.Forms.ToolStripSplitButton();
            this.btnReportsLvl1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsLvl2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsLvl3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCityType = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCastles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCities = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDisplayOptions = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDisplayOptionsCityCount = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsCityScore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsCityName = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsPlayerCount = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsPlayerScore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsAllianceScore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayOptionsAllianceRank = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent = new System.Windows.Forms.Panel();
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
            this.toolStrip2.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.customTabControl1.SuspendLayout();
            this.tpageReport.SuspendLayout();
            this.tpageBBCode.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportsLvl,
            this.toolStripSeparator2,
            this.btnCityType,
            this.toolStripSeparator3,
            this.btnDisplayOptions});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(707, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnReportsLvl
            // 
            this.btnReportsLvl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportsLvl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportsLvl1,
            this.btnReportsLvl2,
            this.btnReportsLvl3});
            this.btnReportsLvl.Image = ((System.Drawing.Image)(resources.GetObject("btnReportsLvl.Image")));
            this.btnReportsLvl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportsLvl.Name = "btnReportsLvl";
            this.btnReportsLvl.Size = new System.Drawing.Size(109, 22);
            this.btnReportsLvl.Text = "Detailed Reports";
            this.btnReportsLvl.ButtonClick += new System.EventHandler(this.btnReportsLvl_ButtonClick);
            // 
            // btnReportsLvl1
            // 
            this.btnReportsLvl1.Name = "btnReportsLvl1";
            this.btnReportsLvl1.Size = new System.Drawing.Size(168, 22);
            this.btnReportsLvl1.Text = "Global Reports";
            this.btnReportsLvl1.Click += new System.EventHandler(this.btnReportsLvl1_Click);
            // 
            // btnReportsLvl2
            // 
            this.btnReportsLvl2.Name = "btnReportsLvl2";
            this.btnReportsLvl2.Size = new System.Drawing.Size(168, 22);
            this.btnReportsLvl2.Text = "Summary Reports";
            this.btnReportsLvl2.Click += new System.EventHandler(this.btnReportsLvl2_Click);
            // 
            // btnReportsLvl3
            // 
            this.btnReportsLvl3.Checked = true;
            this.btnReportsLvl3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnReportsLvl3.Name = "btnReportsLvl3";
            this.btnReportsLvl3.Size = new System.Drawing.Size(168, 22);
            this.btnReportsLvl3.Text = "Detailed Reports";
            this.btnReportsLvl3.Click += new System.EventHandler(this.btnReportsLvl3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCityType
            // 
            this.btnCityType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCityType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBoth,
            this.btnCastles,
            this.btnCities});
            this.btnCityType.Image = ((System.Drawing.Image)(resources.GetObject("btnCityType.Image")));
            this.btnCityType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCityType.Name = "btnCityType";
            this.btnCityType.Size = new System.Drawing.Size(117, 22);
            this.btnCityType.Text = "Cities And Castles";
            this.btnCityType.ButtonClick += new System.EventHandler(this.btnCityType_ButtonClick);
            // 
            // btnBoth
            // 
            this.btnBoth.Checked = true;
            this.btnBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBoth.Name = "btnBoth";
            this.btnBoth.Size = new System.Drawing.Size(166, 22);
            this.btnBoth.Text = "Cities and Castles";
            this.btnBoth.Click += new System.EventHandler(this.btnBoth_Click);
            // 
            // btnCastles
            // 
            this.btnCastles.Name = "btnCastles";
            this.btnCastles.Size = new System.Drawing.Size(166, 22);
            this.btnCastles.Text = "Castles Only";
            this.btnCastles.Click += new System.EventHandler(this.btnCastles_Click);
            // 
            // btnCities
            // 
            this.btnCities.Name = "btnCities";
            this.btnCities.Size = new System.Drawing.Size(166, 22);
            this.btnCities.Text = "Cities Only";
            this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDisplayOptions
            // 
            this.btnDisplayOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDisplayOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDisplayOptionsCityCount,
            this.btnDisplayOptionsCityScore,
            this.btnDisplayOptionsCityName,
            this.btnDisplayOptionsPlayerCount,
            this.btnDisplayOptionsPlayerScore,
            this.btnDisplayOptionsAllianceScore,
            this.btnDisplayOptionsAllianceRank});
            this.btnDisplayOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplayOptions.Image")));
            this.btnDisplayOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplayOptions.Name = "btnDisplayOptions";
            this.btnDisplayOptions.Size = new System.Drawing.Size(106, 22);
            this.btnDisplayOptions.Text = "Display Options";
            this.btnDisplayOptions.ButtonClick += new System.EventHandler(this.btnDisplayOptions_ButtonClick);
            // 
            // btnDisplayOptionsCityCount
            // 
            this.btnDisplayOptionsCityCount.Name = "btnDisplayOptionsCityCount";
            this.btnDisplayOptionsCityCount.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsCityCount.Text = "City Count";
            this.btnDisplayOptionsCityCount.Click += new System.EventHandler(this.btnDisplayOptionsCityCount_Click);
            // 
            // btnDisplayOptionsCityScore
            // 
            this.btnDisplayOptionsCityScore.Name = "btnDisplayOptionsCityScore";
            this.btnDisplayOptionsCityScore.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsCityScore.Text = "City Score";
            this.btnDisplayOptionsCityScore.Click += new System.EventHandler(this.btnDisplayOptionsCityScore_Click);
            // 
            // btnDisplayOptionsCityName
            // 
            this.btnDisplayOptionsCityName.Name = "btnDisplayOptionsCityName";
            this.btnDisplayOptionsCityName.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsCityName.Text = "City Name";
            this.btnDisplayOptionsCityName.Click += new System.EventHandler(this.btnDisplayOptionsCityName_Click);
            // 
            // btnDisplayOptionsPlayerCount
            // 
            this.btnDisplayOptionsPlayerCount.Name = "btnDisplayOptionsPlayerCount";
            this.btnDisplayOptionsPlayerCount.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsPlayerCount.Text = "Player Count";
            this.btnDisplayOptionsPlayerCount.Click += new System.EventHandler(this.btnDisplayOptionsPlayerCount_Click);
            // 
            // btnDisplayOptionsPlayerScore
            // 
            this.btnDisplayOptionsPlayerScore.Name = "btnDisplayOptionsPlayerScore";
            this.btnDisplayOptionsPlayerScore.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsPlayerScore.Text = "Player Score";
            this.btnDisplayOptionsPlayerScore.Click += new System.EventHandler(this.btnDisplayOptionsPlayerScore_Click);
            // 
            // btnDisplayOptionsAllianceScore
            // 
            this.btnDisplayOptionsAllianceScore.Name = "btnDisplayOptionsAllianceScore";
            this.btnDisplayOptionsAllianceScore.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsAllianceScore.Text = "Alliance Score";
            this.btnDisplayOptionsAllianceScore.Click += new System.EventHandler(this.btnDisplayOptionsAllianceScore_Click);
            // 
            // btnDisplayOptionsAllianceRank
            // 
            this.btnDisplayOptionsAllianceRank.Name = "btnDisplayOptionsAllianceRank";
            this.btnDisplayOptionsAllianceRank.Size = new System.Drawing.Size(148, 22);
            this.btnDisplayOptionsAllianceRank.Text = "Alliance Rank";
            this.btnDisplayOptionsAllianceRank.Click += new System.EventHandler(this.btnDisplayOptionsAllianceRank_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.customTabControl1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(707, 443);
            this.pnlContent.TabIndex = 2;
            // 
            // customTabControl1
            // 
            this.customTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.customTabControl1.Controls.Add(this.tpageReport);
            this.customTabControl1.Controls.Add(this.tpageBBCode);
            this.customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTabControl1.HotTrack = true;
            this.customTabControl1.Location = new System.Drawing.Point(0, 0);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(707, 443);
            this.customTabControl1.TabIndex = 3;
            // 
            // tpageReport
            // 
            this.tpageReport.Controls.Add(this.reportBrowser);
            this.tpageReport.Location = new System.Drawing.Point(4, 4);
            this.tpageReport.Name = "tpageReport";
            this.tpageReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpageReport.Size = new System.Drawing.Size(699, 417);
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
            this.reportBrowser.Size = new System.Drawing.Size(693, 411);
            this.reportBrowser.TabIndex = 0;
            // 
            // tpageBBCode
            // 
            this.tpageBBCode.Controls.Add(this.txtBBCode);
            this.tpageBBCode.Controls.Add(this.toolStrip1);
            this.tpageBBCode.Location = new System.Drawing.Point(4, 4);
            this.tpageBBCode.Name = "tpageBBCode";
            this.tpageBBCode.Padding = new System.Windows.Forms.Padding(3);
            this.tpageBBCode.Size = new System.Drawing.Size(699, 417);
            this.tpageBBCode.TabIndex = 1;
            this.tpageBBCode.Text = "BBCode";
            this.tpageBBCode.UseVisualStyleBackColor = true;
            // 
            // txtBBCode
            // 
            this.txtBBCode.BackColor = System.Drawing.Color.White;
            this.txtBBCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBBCode.Location = new System.Drawing.Point(3, 28);
            this.txtBBCode.Multiline = true;
            this.txtBBCode.Name = "txtBBCode";
            this.txtBBCode.ReadOnly = true;
            this.txtBBCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBBCode.Size = new System.Drawing.Size(693, 386);
            this.txtBBCode.TabIndex = 1;
            this.txtBBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBBCode_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
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
            this.btnBBCodeDisplay.Click += new System.EventHandler(this.btnBBCodeDisplay_ButtonClick);
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
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 468);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.toolStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.customTabControl1.ResumeLayout(false);
            this.tpageReport.ResumeLayout(false);
            this.tpageBBCode.ResumeLayout(false);
            this.tpageBBCode.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton btnReportsLvl;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl1;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl2;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl3;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl customTabControl1;
        private System.Windows.Forms.TabPage tpageReport;
        private System.Windows.Forms.WebBrowser reportBrowser;
        private System.Windows.Forms.TabPage tpageBBCode;
        private System.Windows.Forms.TextBox txtBBCode;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnCityType;
        private System.Windows.Forms.ToolStripMenuItem btnBoth;
        private System.Windows.Forms.ToolStripMenuItem btnCastles;
        private System.Windows.Forms.ToolStripMenuItem btnCities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton btnDisplayOptions;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsCityCount;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsCityScore;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsCityName;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsPlayerCount;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsPlayerScore;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsAllianceScore;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayOptionsAllianceRank;

    }
}