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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageContinent = new System.Windows.Forms.TabPage();
            this.continentView = new LouMapInfoApp.ContinentTabPageContent();
            this.tpageWorld = new System.Windows.Forms.TabPage();
            this.worldView = new LouMapInfoApp.WorldTabPageContent();
            this.tabControl1.SuspendLayout();
            this.tpageContinent.SuspendLayout();
            this.tpageWorld.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageContinent);
            this.tabControl1.Controls.Add(this.tpageWorld);
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
            this.tpageContinent.Location = new System.Drawing.Point(4, 22);
            this.tpageContinent.Name = "tpageContinent";
            this.tpageContinent.Padding = new System.Windows.Forms.Padding(3);
            this.tpageContinent.Size = new System.Drawing.Size(568, 464);
            this.tpageContinent.TabIndex = 0;
            this.tpageContinent.Text = "Continent View";
            this.tpageContinent.UseVisualStyleBackColor = true;
            // 
            // continentView
            // 
            this.continentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continentView.Location = new System.Drawing.Point(3, 3);
            this.continentView.Name = "continentView";
            this.continentView.Size = new System.Drawing.Size(562, 458);
            this.continentView.TabIndex = 0;
            this.continentView.Worlds = null;
            // 
            // tpageWorld
            // 
            this.tpageWorld.Controls.Add(this.worldView);
            this.tpageWorld.Location = new System.Drawing.Point(4, 22);
            this.tpageWorld.Name = "tpageWorld";
            this.tpageWorld.Padding = new System.Windows.Forms.Padding(3);
            this.tpageWorld.Size = new System.Drawing.Size(568, 464);
            this.tpageWorld.TabIndex = 1;
            this.tpageWorld.Text = "World View";
            this.tpageWorld.UseVisualStyleBackColor = true;
            // 
            // worldView
            // 
            this.worldView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldView.Location = new System.Drawing.Point(3, 3);
            this.worldView.Name = "worldView";
            this.worldView.Size = new System.Drawing.Size(562, 458);
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
            this.tpageWorld.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpageContinent;
        private System.Windows.Forms.TabPage tpageWorld;
        private ContinentTabPageContent continentView;
        private WorldTabPageContent worldView;
    }
}