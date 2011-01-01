﻿namespace LouMapInfoApp
{
    partial class LiveTabPageContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveTabPageContent));
            this.toolbarConnection = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtUsername = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtPassword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lstServerNames = new System.Windows.Forms.ToolStripComboBox();
            this.lblImage = new System.Windows.Forms.ToolStripLabel();
            this.lblWorldInfo = new System.Windows.Forms.ToolStripLabel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.dgvPlayersName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvPlayersAlliance = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvPlayersScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlayersRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlayersCities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbReportPlayerOverview = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnPlayerReportMe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtPlayerReportOther = new System.Windows.Forms.ToolStripTextBox();
            this.btnPlayerReportOther = new System.Windows.Forms.ToolStripButton();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolbarConnection.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.tbReportPlayerOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarConnection
            // 
            this.toolbarConnection.BackColor = System.Drawing.Color.White;
            this.toolbarConnection.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtUsername,
            this.toolStripLabel2,
            this.txtPassword,
            this.toolStripLabel3,
            this.lstServerNames,
            this.btnConnect,
            this.lblImage,
            this.lblWorldInfo});
            this.toolbarConnection.Location = new System.Drawing.Point(0, 0);
            this.toolbarConnection.Name = "toolbarConnection";
            this.toolbarConnection.Size = new System.Drawing.Size(912, 25);
            this.toolbarConnection.TabIndex = 0;
            this.toolbarConnection.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "E-Mail:";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 25);
            this.txtUsername.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 25);
            this.txtPassword.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel3.Text = "World:";
            // 
            // lstServerNames
            // 
            this.lstServerNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.lstServerNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstServerNames.Name = "lstServerNames";
            this.lstServerNames.Size = new System.Drawing.Size(150, 25);
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
            // lblWorldInfo
            // 
            this.lblWorldInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblWorldInfo.Name = "lblWorldInfo";
            this.lblWorldInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWorldInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvPlayers);
            this.pnlContent.Controls.Add(this.tbReportPlayerOverview);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(912, 421);
            this.pnlContent.TabIndex = 11;
            this.pnlContent.Visible = false;
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToOrderColumns = true;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPlayersName,
            this.dgvPlayersAlliance,
            this.dgvPlayersScore,
            this.dgvPlayersRank,
            this.dgvPlayersCities});
            this.dgvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayers.Location = new System.Drawing.Point(0, 25);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPlayers.Size = new System.Drawing.Size(912, 396);
            this.dgvPlayers.TabIndex = 13;
            // 
            // dgvPlayersName
            // 
            this.dgvPlayersName.ActiveLinkColor = System.Drawing.Color.Black;
            this.dgvPlayersName.HeaderText = "Name";
            this.dgvPlayersName.LinkColor = System.Drawing.Color.Black;
            this.dgvPlayersName.Name = "dgvPlayersName";
            this.dgvPlayersName.ReadOnly = true;
            this.dgvPlayersName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayersName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvPlayersName.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // dgvPlayersAlliance
            // 
            this.dgvPlayersAlliance.ActiveLinkColor = System.Drawing.Color.Black;
            this.dgvPlayersAlliance.HeaderText = "Alliance";
            this.dgvPlayersAlliance.LinkColor = System.Drawing.Color.Black;
            this.dgvPlayersAlliance.Name = "dgvPlayersAlliance";
            this.dgvPlayersAlliance.ReadOnly = true;
            this.dgvPlayersAlliance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayersAlliance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvPlayersAlliance.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // dgvPlayersScore
            // 
            this.dgvPlayersScore.HeaderText = "Score";
            this.dgvPlayersScore.Name = "dgvPlayersScore";
            this.dgvPlayersScore.ReadOnly = true;
            // 
            // dgvPlayersRank
            // 
            this.dgvPlayersRank.HeaderText = "Rank";
            this.dgvPlayersRank.Name = "dgvPlayersRank";
            this.dgvPlayersRank.ReadOnly = true;
            // 
            // dgvPlayersCities
            // 
            this.dgvPlayersCities.HeaderText = "Cities";
            this.dgvPlayersCities.Name = "dgvPlayersCities";
            this.dgvPlayersCities.ReadOnly = true;
            // 
            // tbReportPlayerOverview
            // 
            this.tbReportPlayerOverview.BackColor = System.Drawing.Color.White;
            this.tbReportPlayerOverview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbReportPlayerOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.btnPlayerReportMe,
            this.toolStripSeparator1,
            this.toolStripLabel5,
            this.txtPlayerReportOther,
            this.btnPlayerReportOther});
            this.tbReportPlayerOverview.Location = new System.Drawing.Point(0, 0);
            this.tbReportPlayerOverview.Name = "tbReportPlayerOverview";
            this.tbReportPlayerOverview.Size = new System.Drawing.Size(912, 25);
            this.tbReportPlayerOverview.TabIndex = 12;
            this.tbReportPlayerOverview.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(105, 22);
            this.toolStripLabel4.Text = "Player Overview: ";
            // 
            // btnPlayerReportMe
            // 
            this.btnPlayerReportMe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlayerReportMe.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayerReportMe.Image")));
            this.btnPlayerReportMe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlayerReportMe.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnPlayerReportMe.Name = "btnPlayerReportMe";
            this.btnPlayerReportMe.Size = new System.Drawing.Size(28, 22);
            this.btnPlayerReportMe.Text = "Me";
            this.btnPlayerReportMe.Click += new System.EventHandler(this.btnPlayerReportMe_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel5.Text = "Other:";
            // 
            // txtPlayerReportOther
            // 
            this.txtPlayerReportOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.txtPlayerReportOther.Name = "txtPlayerReportOther";
            this.txtPlayerReportOther.Size = new System.Drawing.Size(100, 25);
            this.txtPlayerReportOther.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPlayerReportOther
            // 
            this.btnPlayerReportOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlayerReportOther.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayerReportOther.Image")));
            this.btnPlayerReportOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlayerReportOther.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnPlayerReportOther.Name = "btnPlayerReportOther";
            this.btnPlayerReportOther.Size = new System.Drawing.Size(78, 22);
            this.btnPlayerReportOther.Text = "Show Report";
            this.btnPlayerReportOther.Click += new System.EventHandler(this.btnPlayerReportOther_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // LiveTabPageContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.toolbarConnection);
            this.Name = "LiveTabPageContent";
            this.Size = new System.Drawing.Size(912, 446);
            this.Load += new System.EventHandler(this.LiveTabPageContent_Load);
            this.toolbarConnection.ResumeLayout(false);
            this.toolbarConnection.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.tbReportPlayerOverview.ResumeLayout(false);
            this.tbReportPlayerOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarConnection;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtUsername;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtPassword;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox lstServerNames;
        private System.Windows.Forms.ToolStripLabel lblImage;
        private System.Windows.Forms.ToolStripLabel lblWorldInfo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tbReportPlayerOverview;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.DataGridViewLinkColumn dgvPlayersName;
        private System.Windows.Forms.DataGridViewLinkColumn dgvPlayersAlliance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersCities;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btnPlayerReportMe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox txtPlayerReportOther;
        private System.Windows.Forms.ToolStripButton btnPlayerReportOther;
        private System.Windows.Forms.ToolStripButton btnConnect;
    }
}
