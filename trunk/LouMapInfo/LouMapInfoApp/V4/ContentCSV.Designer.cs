namespace LouMapInfoApp.V4
{
    partial class ContentCSV
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.customTabControl1 = new System.Windows.Forms.TabControl();
            this.tpageReport = new System.Windows.Forms.TabPage();
            this.tpageBBCode = new System.Windows.Forms.TabPage();
            this.txtBBCode = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenCSV = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.customTabControl1.SuspendLayout();
            this.tpageReport.SuspendLayout();
            this.tpageBBCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.customTabControl1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(707, 468);
            this.pnlContent.TabIndex = 2;
            // 
            // customTabControl1
            // 
            this.customTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.customTabControl1.Controls.Add(this.tpageReport);
            this.customTabControl1.Controls.Add(this.tpageBBCode);
            this.customTabControl1.Controls.Add(this.tabPage1);
            this.customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTabControl1.HotTrack = true;
            this.customTabControl1.Location = new System.Drawing.Point(0, 0);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(707, 468);
            this.customTabControl1.TabIndex = 3;
            // 
            // tpageReport
            // 
            this.tpageReport.Controls.Add(this.btnOpenCSV);
            this.tpageReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpageReport.Location = new System.Drawing.Point(4, 4);
            this.tpageReport.Name = "tpageReport";
            this.tpageReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpageReport.Size = new System.Drawing.Size(699, 442);
            this.tpageReport.TabIndex = 0;
            this.tpageReport.Text = "CSV";
            this.tpageReport.UseVisualStyleBackColor = true;
            this.tpageReport.SizeChanged += new System.EventHandler(this.tpageReport_SizeChanged);
            // 
            // tpageBBCode
            // 
            this.tpageBBCode.Controls.Add(this.txtBBCode);
            this.tpageBBCode.Location = new System.Drawing.Point(4, 4);
            this.tpageBBCode.Name = "tpageBBCode";
            this.tpageBBCode.Padding = new System.Windows.Forms.Padding(3);
            this.tpageBBCode.Size = new System.Drawing.Size(699, 442);
            this.tpageBBCode.TabIndex = 1;
            this.tpageBBCode.Text = "Raw File";
            this.tpageBBCode.UseVisualStyleBackColor = true;
            // 
            // txtBBCode
            // 
            this.txtBBCode.BackColor = System.Drawing.Color.White;
            this.txtBBCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBBCode.Location = new System.Drawing.Point(3, 3);
            this.txtBBCode.Multiline = true;
            this.txtBBCode.Name = "txtBBCode";
            this.txtBBCode.ReadOnly = true;
            this.txtBBCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBBCode.Size = new System.Drawing.Size(693, 436);
            this.txtBBCode.TabIndex = 1;
            this.txtBBCode.WordWrap = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 442);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Grid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpenCSV
            // 
            this.btnOpenCSV.BackgroundImage = global::LouMapInfoApp.Properties.Resources.Office_excel_csv_icon;
            this.btnOpenCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenCSV.Location = new System.Drawing.Point(312, 122);
            this.btnOpenCSV.Name = "btnOpenCSV";
            this.btnOpenCSV.Size = new System.Drawing.Size(158, 189);
            this.btnOpenCSV.TabIndex = 0;
            this.btnOpenCSV.Text = "Open CSV";
            this.btnOpenCSV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenCSV.UseVisualStyleBackColor = true;
            this.btnOpenCSV.Click += new System.EventHandler(this.btnOpenCSV_Click);
            // 
            // ContentCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "ContentCSV";
            this.Size = new System.Drawing.Size(707, 468);
            this.pnlContent.ResumeLayout(false);
            this.customTabControl1.ResumeLayout(false);
            this.tpageReport.ResumeLayout(false);
            this.tpageBBCode.ResumeLayout(false);
            this.tpageBBCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl customTabControl1;
        private System.Windows.Forms.TabPage tpageReport;
        private System.Windows.Forms.TabPage tpageBBCode;
        private System.Windows.Forms.TextBox txtBBCode;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpenCSV;

    }
}