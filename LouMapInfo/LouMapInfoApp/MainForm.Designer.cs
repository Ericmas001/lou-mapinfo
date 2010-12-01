﻿namespace LouMapInfoApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCityType = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCastles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCities = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tpageReports = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cityCastleChooser1 = new LouMapInfoApp.CityCastleChooser();
            this.btnReportLawless = new System.Windows.Forms.Button();
            this.btnReportShrines = new System.Windows.Forms.Button();
            this.btnReportAllCities = new System.Windows.Forms.Button();
            this.chooReportShrines = new LouMapInfoApp.CityCastleChooser();
            this.chooReportAllCities = new LouMapInfoApp.CityCastleChooser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chooReportAlliance = new LouMapInfoApp.CityCastleChooser();
            this.chooReportPlayer = new LouMapInfoApp.CityCastleChooser();
            this.txtAllianceName = new System.Windows.Forms.TextBox();
            this.btnReportAlliance = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnReportPlayer = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudWorld = new System.Windows.Forms.NumericUpDown();
            this.nudContinent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statePictureBox1 = new EricUtility.Windows.Forms.StatePictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.tpageReports.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContinent)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpageReports);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.dgvCities);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Continent View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCityType});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(669, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // dgvCities
            // 
            this.dgvCities.AllowUserToAddRows = false;
            this.dgvCities.AllowUserToDeleteRows = false;
            this.dgvCities.AllowUserToOrderColumns = true;
            this.dgvCities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvCities.Location = new System.Drawing.Point(3, 110);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.ReadOnly = true;
            this.dgvCities.RowHeadersVisible = false;
            this.dgvCities.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCities.Size = new System.Drawing.Size(669, 272);
            this.dgvCities.TabIndex = 0;
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
            // tpageReports
            // 
            this.tpageReports.Controls.Add(this.groupBox1);
            this.tpageReports.Controls.Add(this.btnReportShrines);
            this.tpageReports.Controls.Add(this.btnReportAllCities);
            this.tpageReports.Controls.Add(this.chooReportShrines);
            this.tpageReports.Controls.Add(this.chooReportAllCities);
            this.tpageReports.Location = new System.Drawing.Point(4, 22);
            this.tpageReports.Name = "tpageReports";
            this.tpageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tpageReports.Size = new System.Drawing.Size(675, 385);
            this.tpageReports.TabIndex = 1;
            this.tpageReports.Text = "Continent Reports";
            this.tpageReports.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cityCastleChooser1);
            this.groupBox1.Controls.Add(this.btnReportLawless);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 136);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lawless Cities";
            // 
            // cityCastleChooser1
            // 
            this.cityCastleChooser1.BackColor = System.Drawing.Color.Transparent;
            this.cityCastleChooser1.Castle = true;
            this.cityCastleChooser1.City = true;
            this.cityCastleChooser1.Location = new System.Drawing.Point(137, 32);
            this.cityCastleChooser1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cityCastleChooser1.Name = "cityCastleChooser1";
            this.cityCastleChooser1.Size = new System.Drawing.Size(319, 39);
            this.cityCastleChooser1.TabIndex = 7;
            this.cityCastleChooser1.Value = LouMapInfo.Entities.CityCastleType.Both;
            // 
            // btnReportLawless
            // 
            this.btnReportLawless.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportLawless.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportLawless.Location = new System.Drawing.Point(6, 80);
            this.btnReportLawless.Name = "btnReportLawless";
            this.btnReportLawless.Size = new System.Drawing.Size(647, 50);
            this.btnReportLawless.TabIndex = 0;
            this.btnReportLawless.Text = "Lawless Cities";
            this.btnReportLawless.UseVisualStyleBackColor = true;
            this.btnReportLawless.Click += new System.EventHandler(this.btnReportLawless_Click);
            // 
            // btnReportShrines
            // 
            this.btnReportShrines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportShrines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportShrines.Location = new System.Drawing.Point(483, 329);
            this.btnReportShrines.Name = "btnReportShrines";
            this.btnReportShrines.Size = new System.Drawing.Size(184, 50);
            this.btnReportShrines.TabIndex = 3;
            this.btnReportShrines.Text = "Shrines";
            this.btnReportShrines.UseVisualStyleBackColor = true;
            this.btnReportShrines.Click += new System.EventHandler(this.btnReportShrines_Click);
            // 
            // btnReportAllCities
            // 
            this.btnReportAllCities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportAllCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportAllCities.Location = new System.Drawing.Point(483, 195);
            this.btnReportAllCities.Name = "btnReportAllCities";
            this.btnReportAllCities.Size = new System.Drawing.Size(171, 62);
            this.btnReportAllCities.TabIndex = 2;
            this.btnReportAllCities.Text = "Continent Overview";
            this.btnReportAllCities.UseVisualStyleBackColor = true;
            this.btnReportAllCities.Click += new System.EventHandler(this.btnReportAllCities_Click);
            // 
            // chooReportShrines
            // 
            this.chooReportShrines.BackColor = System.Drawing.Color.Transparent;
            this.chooReportShrines.Castle = true;
            this.chooReportShrines.City = true;
            this.chooReportShrines.Location = new System.Drawing.Point(265, 329);
            this.chooReportShrines.Name = "chooReportShrines";
            this.chooReportShrines.Size = new System.Drawing.Size(199, 36);
            this.chooReportShrines.TabIndex = 5;
            this.chooReportShrines.Value = LouMapInfo.Entities.CityCastleType.Both;
            // 
            // chooReportAllCities
            // 
            this.chooReportAllCities.BackColor = System.Drawing.Color.Transparent;
            this.chooReportAllCities.Castle = true;
            this.chooReportAllCities.City = true;
            this.chooReportAllCities.Location = new System.Drawing.Point(265, 233);
            this.chooReportAllCities.Name = "chooReportAllCities";
            this.chooReportAllCities.Size = new System.Drawing.Size(210, 36);
            this.chooReportAllCities.TabIndex = 4;
            this.chooReportAllCities.Value = LouMapInfo.Entities.CityCastleType.Both;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chooReportAlliance);
            this.tabPage2.Controls.Add(this.chooReportPlayer);
            this.tabPage2.Controls.Add(this.txtAllianceName);
            this.tabPage2.Controls.Add(this.btnReportAlliance);
            this.tabPage2.Controls.Add(this.txtPlayerName);
            this.tabPage2.Controls.Add(this.btnReportPlayer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(675, 385);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "World Reports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chooReportAlliance
            // 
            this.chooReportAlliance.BackColor = System.Drawing.Color.Transparent;
            this.chooReportAlliance.Castle = true;
            this.chooReportAlliance.City = true;
            this.chooReportAlliance.Location = new System.Drawing.Point(94, 230);
            this.chooReportAlliance.Name = "chooReportAlliance";
            this.chooReportAlliance.Size = new System.Drawing.Size(489, 36);
            this.chooReportAlliance.TabIndex = 7;
            this.chooReportAlliance.Value = LouMapInfo.Entities.CityCastleType.Both;
            // 
            // chooReportPlayer
            // 
            this.chooReportPlayer.BackColor = System.Drawing.Color.Transparent;
            this.chooReportPlayer.Castle = true;
            this.chooReportPlayer.City = true;
            this.chooReportPlayer.Location = new System.Drawing.Point(94, 47);
            this.chooReportPlayer.Name = "chooReportPlayer";
            this.chooReportPlayer.Size = new System.Drawing.Size(489, 36);
            this.chooReportPlayer.TabIndex = 6;
            this.chooReportPlayer.Value = LouMapInfo.Entities.CityCastleType.Both;
            // 
            // txtAllianceName
            // 
            this.txtAllianceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllianceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtAllianceName.Location = new System.Drawing.Point(94, 199);
            this.txtAllianceName.Name = "txtAllianceName";
            this.txtAllianceName.Size = new System.Drawing.Size(489, 31);
            this.txtAllianceName.TabIndex = 5;
            this.txtAllianceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAllianceName.TextChanged += new System.EventHandler(this.txtAllianceName_TextChanged);
            // 
            // btnReportAlliance
            // 
            this.btnReportAlliance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportAlliance.Enabled = false;
            this.btnReportAlliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportAlliance.Location = new System.Drawing.Point(94, 266);
            this.btnReportAlliance.Name = "btnReportAlliance";
            this.btnReportAlliance.Size = new System.Drawing.Size(489, 65);
            this.btnReportAlliance.TabIndex = 4;
            this.btnReportAlliance.Text = "Alliance Report";
            this.btnReportAlliance.UseVisualStyleBackColor = true;
            this.btnReportAlliance.Click += new System.EventHandler(this.btnReportAlliance_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtPlayerName.Location = new System.Drawing.Point(94, 16);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(489, 31);
            this.txtPlayerName.TabIndex = 3;
            this.txtPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlayerName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnReportPlayer
            // 
            this.btnReportPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportPlayer.Enabled = false;
            this.btnReportPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportPlayer.Location = new System.Drawing.Point(94, 82);
            this.btnReportPlayer.Name = "btnReportPlayer";
            this.btnReportPlayer.Size = new System.Drawing.Size(489, 65);
            this.btnReportPlayer.TabIndex = 2;
            this.btnReportPlayer.Text = "Player Report";
            this.btnReportPlayer.UseVisualStyleBackColor = true;
            this.btnReportPlayer.Click += new System.EventHandler(this.btnReportPlayer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "World:";
            // 
            // nudWorld
            // 
            this.nudWorld.Location = new System.Drawing.Point(48, 7);
            this.nudWorld.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.nudWorld.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWorld.Name = "nudWorld";
            this.nudWorld.Size = new System.Drawing.Size(63, 20);
            this.nudWorld.TabIndex = 3;
            this.nudWorld.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudContinent
            // 
            this.nudContinent.Location = new System.Drawing.Point(196, 7);
            this.nudContinent.Maximum = new decimal(new int[] {
            66,
            0,
            0,
            0});
            this.nudContinent.Name = "nudContinent";
            this.nudContinent.Size = new System.Drawing.Size(63, 20);
            this.nudContinent.TabIndex = 5;
            this.nudContinent.Value = new decimal(new int[] {
            41,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Continent: ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(283, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(360, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Load Continent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.statePictureBox1);
            this.panel1.Location = new System.Drawing.Point(649, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 30);
            this.panel1.TabIndex = 1;
            // 
            // statePictureBox1
            // 
            this.statePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.None;
            this.statePictureBox1.Location = new System.Drawing.Point(2, 2);
            this.statePictureBox1.Name = "statePictureBox1";
            this.statePictureBox1.Size = new System.Drawing.Size(23, 23);
            this.statePictureBox1.TabIndex = 8;
            this.statePictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudContinent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWorld);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoU Map Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.tpageReports.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContinent)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWorld;
        private System.Windows.Forms.NumericUpDown nudContinent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private EricUtility.Windows.Forms.StatePictureBox statePictureBox1;
        private System.Windows.Forms.TabPage tpageReports;
        private System.Windows.Forms.Button btnReportLawless;
        private System.Windows.Forms.Button btnReportAllCities;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button btnReportPlayer;
        private System.Windows.Forms.TextBox txtAllianceName;
        private System.Windows.Forms.Button btnReportAlliance;
        private System.Windows.Forms.Button btnReportShrines;
        private CityCastleChooser chooReportAllCities;
        private CityCastleChooser chooReportShrines;
        private CityCastleChooser chooReportAlliance;
        private CityCastleChooser chooReportPlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private CityCastleChooser cityCastleChooser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton btnCityType;
        private System.Windows.Forms.ToolStripMenuItem btnBoth;
        private System.Windows.Forms.ToolStripMenuItem btnCastles;
        private System.Windows.Forms.ToolStripMenuItem btnCities;
    }
}

