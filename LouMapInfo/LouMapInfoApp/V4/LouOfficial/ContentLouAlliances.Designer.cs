namespace LouMapInfoApp.V4.LouOfficial
{
    partial class ContentLouAlliances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLouAlliances));
            this.tbReportAllianceOverview = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.btnAllianceReportMe = new System.Windows.Forms.ToolStripButton();
            this.famousSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.lblOther = new System.Windows.Forms.ToolStripLabel();
            this.txtAllianceReportOther = new System.Windows.Forms.ToolStripTextBox();
            this.btnAllianceReportOther = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAllianceReportNoAlliance = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tbReportAllianceOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReportAllianceOverview
            // 
            this.tbReportAllianceOverview.BackColor = System.Drawing.Color.White;
            this.tbReportAllianceOverview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbReportAllianceOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.btnAllianceReportMe,
            this.famousSeparator,
            this.lblOther,
            this.txtAllianceReportOther,
            this.btnAllianceReportOther,
            this.toolStripSeparator3,
            this.btnAllianceReportNoAlliance});
            this.tbReportAllianceOverview.Location = new System.Drawing.Point(0, 0);
            this.tbReportAllianceOverview.Name = "tbReportAllianceOverview";
            this.tbReportAllianceOverview.Size = new System.Drawing.Size(435, 25);
            this.tbReportAllianceOverview.TabIndex = 16;
            this.tbReportAllianceOverview.Text = "toolStrip1";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(114, 22);
            this.toolStripLabel6.Text = "Alliance Overview: ";
            // 
            // btnAllianceReportMe
            // 
            this.btnAllianceReportMe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAllianceReportMe.Image = ((System.Drawing.Image)(resources.GetObject("btnAllianceReportMe.Image")));
            this.btnAllianceReportMe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAllianceReportMe.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnAllianceReportMe.Name = "btnAllianceReportMe";
            this.btnAllianceReportMe.Size = new System.Drawing.Size(28, 22);
            this.btnAllianceReportMe.Text = "Me";
            this.btnAllianceReportMe.Click += new System.EventHandler(this.btnAllianceReportMe_Click);
            // 
            // famousSeparator
            // 
            this.famousSeparator.Name = "famousSeparator";
            this.famousSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // lblOther
            // 
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(40, 22);
            this.lblOther.Text = "Other:";
            // 
            // txtAllianceReportOther
            // 
            this.txtAllianceReportOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.txtAllianceReportOther.Name = "txtAllianceReportOther";
            this.txtAllianceReportOther.Size = new System.Drawing.Size(100, 25);
            this.txtAllianceReportOther.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAllianceReportOther
            // 
            this.btnAllianceReportOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAllianceReportOther.Image = ((System.Drawing.Image)(resources.GetObject("btnAllianceReportOther.Image")));
            this.btnAllianceReportOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAllianceReportOther.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnAllianceReportOther.Name = "btnAllianceReportOther";
            this.btnAllianceReportOther.Size = new System.Drawing.Size(78, 22);
            this.btnAllianceReportOther.Text = "Show Report";
            this.btnAllianceReportOther.Click += new System.EventHandler(this.btnAllianceReportOther_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAllianceReportNoAlliance
            // 
            this.btnAllianceReportNoAlliance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAllianceReportNoAlliance.Image = ((System.Drawing.Image)(resources.GetObject("btnAllianceReportNoAlliance.Image")));
            this.btnAllianceReportNoAlliance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAllianceReportNoAlliance.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnAllianceReportNoAlliance.Name = "btnAllianceReportNoAlliance";
            this.btnAllianceReportNoAlliance.Size = new System.Drawing.Size(134, 19);
            this.btnAllianceReportNoAlliance.Text = "Players with no alliance";
            this.btnAllianceReportNoAlliance.Click += new System.EventHandler(this.btnAllianceReportNoAlliance_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(435, 222);
            this.pnlContent.TabIndex = 17;
            // 
            // ContentLouAlliances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tbReportAllianceOverview);
            this.DoubleBuffered = true;
            this.Name = "ContentLouAlliances";
            this.Size = new System.Drawing.Size(435, 247);
            this.tbReportAllianceOverview.ResumeLayout(false);
            this.tbReportAllianceOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbReportAllianceOverview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton btnAllianceReportMe;
        private System.Windows.Forms.ToolStripSeparator famousSeparator;
        private System.Windows.Forms.ToolStripLabel lblOther;
        private System.Windows.Forms.ToolStripTextBox txtAllianceReportOther;
        private System.Windows.Forms.ToolStripButton btnAllianceReportOther;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAllianceReportNoAlliance;
        private System.Windows.Forms.Panel pnlContent;


    }
}
