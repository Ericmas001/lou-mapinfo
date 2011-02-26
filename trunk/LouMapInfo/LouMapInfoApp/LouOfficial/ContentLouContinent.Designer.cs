namespace LouMapInfoApp.LouOfficial
{
    partial class ContentLouContinent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLouContinent));
            this.tbReportContinentOverview = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnChooseContinent = new System.Windows.Forms.ToolStripButton();
            this.tbReportContinentOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReportContinentOverview
            // 
            this.tbReportContinentOverview.BackColor = System.Drawing.Color.White;
            this.tbReportContinentOverview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbReportContinentOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel8,
            this.toolStripSeparator4,
            this.toolStripLabel9,
            this.btnChooseContinent});
            this.tbReportContinentOverview.Location = new System.Drawing.Point(0, 0);
            this.tbReportContinentOverview.Name = "tbReportContinentOverview";
            this.tbReportContinentOverview.Size = new System.Drawing.Size(435, 25);
            this.tbReportContinentOverview.TabIndex = 18;
            this.tbReportContinentOverview.Text = "toolStrip2";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(126, 22);
            this.toolStripLabel8.Text = "Continent Overview: ";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel9.Text = "Other:";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(435, 222);
            this.pnlContent.TabIndex = 19;
            // 
            // btnChooseContinent
            // 
            this.btnChooseContinent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnChooseContinent.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseContinent.Image")));
            this.btnChooseContinent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChooseContinent.Name = "btnChooseContinent";
            this.btnChooseContinent.Size = new System.Drawing.Size(23, 22);
            this.btnChooseContinent.Text = "??";
            this.btnChooseContinent.Click += new System.EventHandler(this.btnChooseContinent_Click);
            // 
            // ContentLouContinent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tbReportContinentOverview);
            this.DoubleBuffered = true;
            this.Name = "ContentLouContinent";
            this.Size = new System.Drawing.Size(435, 247);
            this.tbReportContinentOverview.ResumeLayout(false);
            this.tbReportContinentOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbReportContinentOverview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripButton btnChooseContinent;



    }
}
