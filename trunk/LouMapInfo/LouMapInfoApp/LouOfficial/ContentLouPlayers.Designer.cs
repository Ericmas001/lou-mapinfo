namespace LouMapInfoApp.LouOfficial
{
    partial class ContentLouPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLouPlayers));
            this.tbReportPlayerOverview = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnPlayerReportMe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtPlayerReportOther = new System.Windows.Forms.ToolStripTextBox();
            this.btnPlayerReportOther = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tbReportPlayerOverview.SuspendLayout();
            this.SuspendLayout();
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
            this.tbReportPlayerOverview.Size = new System.Drawing.Size(435, 25);
            this.tbReportPlayerOverview.TabIndex = 13;
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
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(435, 222);
            this.pnlContent.TabIndex = 14;
            // 
            // ContentLouPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            //this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tbReportPlayerOverview);
            this.DoubleBuffered = true;
            this.Name = "ContentLouPlayers";
            this.Size = new System.Drawing.Size(435, 247);
            this.tbReportPlayerOverview.ResumeLayout(false);
            this.tbReportPlayerOverview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbReportPlayerOverview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btnPlayerReportMe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox txtPlayerReportOther;
        private System.Windows.Forms.ToolStripButton btnPlayerReportOther;
        private System.Windows.Forms.Panel pnlContent;

    }
}
