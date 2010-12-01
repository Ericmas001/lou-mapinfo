namespace LouMapInfoApp
{
    partial class WorldTabPageContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldTabPageContent));
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
            this.txtName = new System.Windows.Forms.ToolStripTextBox();
            this.btnReportPlayers = new System.Windows.Forms.ToolStripButton();
            this.btnReportAlliance = new System.Windows.Forms.ToolStripButton();
            this.btnWorld = new System.Windows.Forms.ToolStripSplitButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.lblImage = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.toolbarReports.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.txtName,
            this.btnReportPlayers,
            this.btnReportAlliance});
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
            // txtName
            // 
            this.txtName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 25);
            this.txtName.Text = "Dirnahm";
            this.txtName.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReportPlayers
            // 
            this.btnReportPlayers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportPlayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportPlayers.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportPlayers.Name = "btnReportPlayers";
            this.btnReportPlayers.Size = new System.Drawing.Size(95, 22);
            this.btnReportPlayers.Text = "Player Overview";
            this.btnReportPlayers.Click += new System.EventHandler(this.btnReportPlayers_Click);
            // 
            // btnReportContinent
            // 
            this.btnReportAlliance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportAlliance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportAlliance.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportAlliance.Name = "btnReportContinent";
            this.btnReportAlliance.Size = new System.Drawing.Size(105, 22);
            this.btnReportAlliance.Text = "Alliance Overview";
            this.btnReportAlliance.Click += new System.EventHandler(this.btnReportAlliance_Click);
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
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(74, 22);
            this.btnLoad.Text = "Load World";
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
            this.btnLoad,
            this.lblImage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(627, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // WorldTabPageContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorldTabPageContent";
            this.Size = new System.Drawing.Size(627, 505);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.toolbarReports.ResumeLayout(false);
            this.toolbarReports.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripButton btnReportPlayers;
        private System.Windows.Forms.ToolStripButton btnReportAlliance;
        private System.Windows.Forms.ToolStripSplitButton btnCityType;
        private System.Windows.Forms.ToolStripMenuItem btnBoth;
        private System.Windows.Forms.ToolStripMenuItem btnCastles;
        private System.Windows.Forms.ToolStripMenuItem btnCities;
        private System.Windows.Forms.ToolStripSplitButton btnReportsLvl;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl1;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl2;
        private System.Windows.Forms.ToolStripMenuItem btnReportsLvl3;
        private System.Windows.Forms.ToolStripSplitButton btnWorld;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripLabel lblImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtName;

    }
}
