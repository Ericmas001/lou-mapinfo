namespace LouMapInfoApp.LouMap
{
    partial class ContentLMWorld
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblWorld = new System.Windows.Forms.ToolStripLabel();
            this.lstWorld = new System.Windows.Forms.ToolStripComboBox();
            this.lblImage = new System.Windows.Forms.ToolStripLabel();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtName = new System.Windows.Forms.ToolStripTextBox();
            this.btnReportPlayers = new System.Windows.Forms.ToolStripButton();
            this.btnReportAlliance = new System.Windows.Forms.ToolStripButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStrip1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWorld,
            this.lstWorld,
            this.lblImage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(428, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblWorld
            // 
            this.lblWorld.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(44, 22);
            this.lblWorld.Text = "World:";
            // 
            // lstWorld
            // 
            this.lstWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstWorld.Items.AddRange(new object[] {
            "World  1 (Europe)",
            "World  2 (Europe)",
            "World  3 (USA East Coast)",
            "World  4 (Europe)",
            "World  5 (USA East Coast)",
            "World  6 (Europe)",
            "World  7 (USA East Coast)",
            "World  8 (Europe)",
            "World  9 (USA East Coast)",
            "World 10 (Europe)",
            "World 11 (USA East Coast)",
            "World 12 (Europe)                                               ",
            "World 13 (USA West Coast)",
            "World 14 (USA East Coast)",
            "World 15 (Europe)",
            "World 16 (USA West Coast)",
            "World 17 (USA East Coast)",
            "World 18 (Europe)",
            "World 19 (Europe)\t\t\t  ",
            "Welt 1 (German)",
            "Welt 2 (German)",
            "Welt 3 (German)"});
            this.lstWorld.Name = "lstWorld";
            this.lstWorld.Size = new System.Drawing.Size(175, 25);
            this.lstWorld.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // lblImage
            // 
            this.lblImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblImage.AutoSize = false;
            this.lblImage.BackgroundImage = global::LouMapInfoApp.Properties.Resources.map;
            this.lblImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(22, 22);
            this.lblImage.Text = "toolStripLabel1";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdated.Location = new System.Drawing.Point(0, 25);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(428, 23);
            this.lblLastUpdated.TabIndex = 11;
            this.lblLastUpdated.Text = "Last Updated: ";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLastUpdated.Visible = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlReport);
            this.pnlContent.Controls.Add(this.toolStrip2);
            this.pnlContent.Location = new System.Drawing.Point(0, 48);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(428, 211);
            this.pnlContent.TabIndex = 12;
            this.pnlContent.Visible = false;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.BackColor = System.Drawing.Color.Transparent;
            this.pnlReport.Location = new System.Drawing.Point(0, 23);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(428, 188);
            this.pnlReport.TabIndex = 12;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txtName,
            this.btnReportPlayers,
            this.btnReportAlliance});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(428, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "Reports:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel2.Text = "Report: ";
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
            // btnReportAlliance
            // 
            this.btnReportAlliance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReportAlliance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportAlliance.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnReportAlliance.Name = "btnReportAlliance";
            this.btnReportAlliance.Size = new System.Drawing.Size(105, 22);
            this.btnReportAlliance.Text = "Alliance Overview";
            this.btnReportAlliance.Click += new System.EventHandler(this.btnReportAlliance_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(0, 262);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(428, 19);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.lou-map.com";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ContentLMWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "ContentLMWorld";
            this.Size = new System.Drawing.Size(428, 281);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblWorld;
        private System.Windows.Forms.ToolStripComboBox lstWorld;
        private System.Windows.Forms.ToolStripLabel lblImage;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.ToolStripTextBox txtName;
        private System.Windows.Forms.ToolStripButton btnReportPlayers;
        private System.Windows.Forms.ToolStripButton btnReportAlliance;
    }
}
