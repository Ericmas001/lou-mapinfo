namespace LouMapInfoApp
{
    partial class MainForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.tabControl1 = new EricUtility.Windows.Forms.CustomTabControl();
            this.tpageContinent = new System.Windows.Forms.TabPage();
            this.continentView = new LouMapInfoApp.ContinentTabPageContent();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.worldView = new LouMapInfoApp.WorldTabPageContent();
            this.tabControl1.SuspendLayout();
            this.tpageContinent.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageContinent);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DisplayStyle = EricUtility.Windows.Forms.TabStyle.Chrome;
            // 
            // 
            // 
            this.tabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.tabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.tabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.tabControl1.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.White;
            this.tabControl1.DisplayStyleProvider.FocusTrack = false;
            this.tabControl1.DisplayStyleProvider.HotTrack = true;
            this.tabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControl1.DisplayStyleProvider.Opacity = 1F;
            this.tabControl1.DisplayStyleProvider.Overlap = 16;
            this.tabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.DisplayStyleProvider.Radius = 16;
            this.tabControl1.DisplayStyleProvider.ShowTabCloser = false;
            this.tabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.tabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tpageContinent
            // 
            this.tpageContinent.Controls.Add(this.continentView);
            this.tpageContinent.Location = new System.Drawing.Point(4, 27);
            this.tpageContinent.Name = "tpageContinent";
            this.tpageContinent.Padding = new System.Windows.Forms.Padding(3);
            this.tpageContinent.Size = new System.Drawing.Size(568, 459);
            this.tpageContinent.TabIndex = 0;
            this.tpageContinent.Text = "Continent View";
            this.tpageContinent.UseVisualStyleBackColor = true;
            // 
            // continentView
            // 
            this.continentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continentView.Location = new System.Drawing.Point(3, 3);
            this.continentView.Name = "continentView";
            this.continentView.Size = new System.Drawing.Size(562, 453);
            this.continentView.TabIndex = 0;
            this.continentView.Worlds = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.worldView);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WorldView";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // worldView
            // 
            this.worldView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldView.Location = new System.Drawing.Point(3, 3);
            this.worldView.Name = "worldView";
            this.worldView.Size = new System.Drawing.Size(562, 453);
            this.worldView.TabIndex = 0;
            this.worldView.Worlds = null;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 490);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm2";
            this.Text = "LoU Map Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tpageContinent.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EricUtility.Windows.Forms.CustomTabControl tabControl1;
        private System.Windows.Forms.TabPage tpageContinent;
        private System.Windows.Forms.TabPage tabPage2;
        private ContinentTabPageContent continentView;
        private WorldTabPageContent worldView;
    }
}