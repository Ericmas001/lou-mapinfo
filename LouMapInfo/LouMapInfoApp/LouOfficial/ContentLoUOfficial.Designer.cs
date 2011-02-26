namespace LouMapInfoApp.LouOfficial
{
    partial class ContentLoUOfficial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLoUOfficial));
            this.toolbarConnection = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.lblImage = new System.Windows.Forms.ToolStripLabel();
            this.lblWorldInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolbarConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarConnection
            // 
            this.toolbarConnection.BackColor = System.Drawing.Color.White;
            this.toolbarConnection.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWorldInfo,
            this.lblImage,
            this.btnConnect});
            this.toolbarConnection.Location = new System.Drawing.Point(0, 0);
            this.toolbarConnection.Name = "toolbarConnection";
            this.toolbarConnection.Size = new System.Drawing.Size(345, 25);
            this.toolbarConnection.TabIndex = 1;
            this.toolbarConnection.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 22);
            this.btnConnect.Text = "Disconnect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
            this.lblWorldInfo.Name = "lblWorldInfo";
            this.lblWorldInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWorldInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // ContentLoUOfficial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.toolbarConnection);
            this.DoubleBuffered = true;
            this.Name = "ContentLoUOfficial";
            this.Size = new System.Drawing.Size(345, 313);
            this.toolbarConnection.ResumeLayout(false);
            this.toolbarConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarConnection;
        private System.Windows.Forms.ToolStripLabel lblWorldInfo;
        private System.Windows.Forms.ToolStripLabel lblImage;
        private System.Windows.Forms.ToolStripButton btnConnect;
    }
}
