namespace LouMapInfoApp
{
    partial class ContinentTabPageContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinentTabPageContent));
            this.btnWorld = new System.Windows.Forms.ToolStripSplitButton();
            this.btnContinent = new System.Windows.Forms.ToolStripSplitButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.lblImage = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.AllianceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllianceScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityCastle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CityScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbarReports = new System.Windows.Forms.ToolStrip();
            this.btnCityType = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCastles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCities = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsLvl = new System.Windows.Forms.ToolStripSplitButton();
            this.btnReportsLvl1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsLvl2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsLvl3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportLawless = new System.Windows.Forms.ToolStripButton();
            this.btnReportContinent = new System.Windows.Forms.ToolStripButton();
            this.btnReportShrines = new System.Windows.Forms.ToolStripButton();
            this.lblTitLastUpdated = new System.Windows.Forms.ToolStripLabel();
            this.lblLastUpdated = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.toolbarReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWorld
            // 
            this.btnWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnWorld.Image = ((System.Drawing.Image)(resources.GetObject("btnWorld.Image")));
            this.btnWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWorld.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnWorld.Name = "btnWorld";
            this.btnWorld.Size = new System.Drawing.Size(46, 22);
            this.btnWorld.Text = "W10";
            this.btnWorld.ButtonClick += new System.EventHandler(this.btnWorld_ButtonClick);
            // 
            // btnContinent
            // 
            this.btnContinent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnContinent.Image = ((System.Drawing.Image)(resources.GetObject("btnContinent.Image")));
            this.btnContinent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContinent.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnContinent.Name = "btnContinent";
            this.btnContinent.Size = new System.Drawing.Size(43, 22);
            this.btnContinent.Text = "C41";
            this.btnContinent.ButtonClick += new System.EventHandler(this.btnContinent_ButtonClick);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 22);
            this.btnLoad.Text = "Load Continent";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblImage
            // 
            this.lblImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblImage.AutoSize = false;
            this.lblImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblImage.Image = global::LouMapInfoApp.Properties.Resources.logo_LOU;
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(22, 22);
            this.lblImage.Text = "toolStripLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWorld,
            this.btnContinent,
            this.btnLoad,
            this.lblImage,
            this.lblLastUpdated,
            this.lblTitLastUpdated});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(627, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvCities);
            this.pnlContent.Controls.Add(this.toolbarReports);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(627, 480);
            this.pnlContent.TabIndex = 7;
            this.pnlContent.Visible = false;
            // 
            // dgvCities
            // 
            this.dgvCities.AllowUserToAddRows = false;
            this.dgvCities.AllowUserToDeleteRows = false;
            this.dgvCities.AllowUserToOrderColumns = true;
            this.dgvCities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AllianceName,
            this.AllianceScore,
            this.PlayerName,
            this.PlayerScore,
            this.CityX,
            this.CityY,
            this.CityName,
            this.CityCastle,
            this.CityScore});
            this.dgvCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCities.Location = new System.Drawing.Point(0, 25);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.ReadOnly = true;
            this.dgvCities.RowHeadersVisible = false;
            this.dgvCities.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCities.Size = new System.Drawing.Size(627, 455);
            this.dgvCities.TabIndex = 9;
            // 
            // AllianceName
            // 
            this.AllianceName.HeaderText = "Alliance Name";
            this.AllianceName.Name = "AllianceName";
            this.AllianceName.ReadOnly = true;
            // 
            // AllianceScore
            // 
            this.AllianceScore.HeaderText = "Alliance Score";
            this.AllianceScore.Name = "AllianceScore";
            this.AllianceScore.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "PlayerName";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // PlayerScore
            // 
            this.PlayerScore.HeaderText = "PlayerScore";
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.ReadOnly = true;
            // 
            // CityX
            // 
            this.CityX.HeaderText = "X";
            this.CityX.Name = "CityX";
            this.CityX.ReadOnly = true;
            // 
            // CityY
            // 
            this.CityY.HeaderText = "Y";
            this.CityY.Name = "CityY";
            this.CityY.ReadOnly = true;
            // 
            // CityName
            // 
            this.CityName.HeaderText = "Name";
            this.CityName.Name = "CityName";
            this.CityName.ReadOnly = true;
            // 
            // CityCastle
            // 
            this.CityCastle.HeaderText = "Castle";
            this.CityCastle.Name = "CityCastle";
            this.CityCastle.ReadOnly = true;
            // 
            // CityScore
            // 
            this.CityScore.HeaderText = "Score";
            this.CityScore.Name = "CityScore";
            this.CityScore.ReadOnly = true;
            // 
            // toolbarReports
            // 
            this.toolbarReports.BackColor = System.Drawing.Color.White;
            this.toolbarReports.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarReports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCityType,
            this.btnReportsLvl,
            this.btnReportContinent,
            this.btnReportLawless,
            this.btnReportShrines});
            this.toolbarReports.Location = new System.Drawing.Point(0, 0);
            this.toolbarReports.Name = "toolbarReports";
            this.toolbarReports.Size = new System.Drawing.Size(627, 25);
            this.toolbarReports.TabIndex = 8;
            this.toolbarReports.Text = "Reports:";
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
            // btnReportsLvl
            // 
            this.btnReportsLvl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportsLvl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportsLvl1,
            this.btnReportsLvl2,
            this.btnReportsLvl3});
            this.btnReportsLvl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReportsLvl.Image = ((System.Drawing.Image)(resources.GetObject("btnReportsLvl.Image")));
            this.btnReportsLvl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportsLvl.Margin = new System.Windows.Forms.Padding(42, 1, 0, 2);
            this.btnReportsLvl.Name = "btnReportsLvl";
            this.btnReportsLvl.Size = new System.Drawing.Size(120, 22);
            this.btnReportsLvl.Text = "Detailed Reports:";
            this.btnReportsLvl.ButtonClick += new System.EventHandler(this.btnReportsLvl_ButtonClick);
            // 
            // btnReportsLvl1
            // 
            this.btnReportsLvl1.Name = "btnReportsLvl1";
            this.btnReportsLvl1.Size = new System.Drawing.Size(174, 22);
            this.btnReportsLvl1.Text = "Global Reports";
            this.btnReportsLvl1.Click += new System.EventHandler(this.btnReportsLvl1_Click);
            // 
            // btnReportsLvl2
            // 
            this.btnReportsLvl2.Name = "btnReportsLvl2";
            this.btnReportsLvl2.Size = new System.Drawing.Size(174, 22);
            this.btnReportsLvl2.Text = "Summary Reports";
            this.btnReportsLvl2.Click += new System.EventHandler(this.btnReportsLvl2_Click);
            // 
            // btnReportsLvl3
            // 
            this.btnReportsLvl3.Checked = true;
            this.btnReportsLvl3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnReportsLvl3.Name = "btnReportsLvl3";
            this.btnReportsLvl3.Size = new System.Drawing.Size(174, 22);
            this.btnReportsLvl3.Text = "Detailed Reports";
            this.btnReportsLvl3.Click += new System.EventHandler(this.btnReportsLvl3_Click);
            // 
            // btnReportLawless
            // 
            this.btnReportLawless.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportLawless.Image = ((System.Drawing.Image)(resources.GetObject("btnReportLawless.Image")));
            this.btnReportLawless.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportLawless.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportLawless.Name = "btnReportLawless";
            this.btnReportLawless.Size = new System.Drawing.Size(51, 22);
            this.btnReportLawless.Text = "Lawless";
            this.btnReportLawless.Click += new System.EventHandler(this.btnReportLawless_Click);
            // 
            // btnReportContinent
            // 
            this.btnReportContinent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportContinent.Image = ((System.Drawing.Image)(resources.GetObject("btnReportContinent.Image")));
            this.btnReportContinent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportContinent.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportContinent.Name = "btnReportContinent";
            this.btnReportContinent.Size = new System.Drawing.Size(116, 22);
            this.btnReportContinent.Text = "Continent Overview";
            this.btnReportContinent.Click += new System.EventHandler(this.btnReportContinent_Click);
            // 
            // btnReportShrines
            // 
            this.btnReportShrines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportShrines.Image = ((System.Drawing.Image)(resources.GetObject("btnReportShrines.Image")));
            this.btnReportShrines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportShrines.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportShrines.Name = "btnReportShrines";
            this.btnReportShrines.Size = new System.Drawing.Size(49, 22);
            this.btnReportShrines.Text = "Shrines";
            this.btnReportShrines.Click += new System.EventHandler(this.btnReportShrines_Click);
            // 
            // lblTitLastUpdated
            // 
            this.lblTitLastUpdated.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTitLastUpdated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitLastUpdated.Name = "lblTitLastUpdated";
            this.lblTitLastUpdated.Size = new System.Drawing.Size(83, 22);
            this.lblTitLastUpdated.Text = "Last Updated:";
            this.lblTitLastUpdated.Visible = false;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(65, 22);
            this.lblLastUpdated.Text = "2010-00-00";
            this.lblLastUpdated.Visible = false;
            // 
            // ContinentTabPageContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ContinentTabPageContent";
            this.Size = new System.Drawing.Size(627, 505);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.toolbarReports.ResumeLayout(false);
            this.toolbarReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSplitButton btnWorld;
        private System.Windows.Forms.ToolStripSplitButton btnContinent;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripLabel lblImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CityCastle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityScore;
        private System.Windows.Forms.ToolStrip toolbarReports;
        private System.Windows.Forms.ToolStripButton btnReportLawless;
        private System.Windows.Forms.ToolStripButton btnReportContinent;
        private System.Windows.Forms.ToolStripButton btnReportShrines;
        private System.Windows.Forms.ToolStripSplitButton btnCityType;
        private System.Windows.Forms.ToolStripMenuItem btnBoth;
        private System.Windows.Forms.ToolStripMenuItem btnCastles;
        private System.Windows.Forms.ToolStripMenuItem btnCities;
        private System.Windows.Forms.ToolStripSplitButton btnReportsLvl;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl1;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl2;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl3;
        private System.Windows.Forms.ToolStripLabel lblLastUpdated;
        private System.Windows.Forms.ToolStripLabel lblTitLastUpdated;

    }
}
