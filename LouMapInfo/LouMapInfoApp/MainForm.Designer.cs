namespace LouMapInfoApp
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
            this.tpageLive = new System.Windows.Forms.TabPage();
            this.tpageContinent = new System.Windows.Forms.TabPage();
            this.tpageWorld = new System.Windows.Forms.TabPage();
            this.liveTabPageContent1 = new LouMapInfoApp.LiveTabPageContent();
            this.continentView = new LouMapInfoApp.ContinentTabPageContent();
            this.worldView = new LouMapInfoApp.WorldTabPageContent();
            this.tabControl1.SuspendLayout();
            this.tpageLive.SuspendLayout();
            this.tpageContinent.SuspendLayout();
            this.tpageWorld.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageLive);
            this.tabControl1.Controls.Add(this.tpageContinent);
            this.tabControl1.Controls.Add(this.tpageWorld);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tpageLive
            // 
            this.tpageLive.Controls.Add(this.liveTabPageContent1);
            this.tpageLive.Location = new System.Drawing.Point(4, 22);
            this.tpageLive.Name = "tpageLive";
            this.tpageLive.Padding = new System.Windows.Forms.Padding(3);
            this.tpageLive.Size = new System.Drawing.Size(757, 464);
            this.tpageLive.TabIndex = 2;
            this.tpageLive.Text = "Live (Official LoU)";
            this.tpageLive.UseVisualStyleBackColor = true;
            // 
            // tpageContinent
            // 
            this.tpageContinent.Controls.Add(this.continentView);
            this.tpageContinent.Location = new System.Drawing.Point(4, 22);
            this.tpageContinent.Name = "tpageContinent";
            this.tpageContinent.Padding = new System.Windows.Forms.Padding(3);
            this.tpageContinent.Size = new System.Drawing.Size(568, 464);
            this.tpageContinent.TabIndex = 0;
            this.tpageContinent.Text = "Continent View (LoU-Map)";
            this.tpageContinent.UseVisualStyleBackColor = true;
            // 
            // tpageWorld
            // 
            this.tpageWorld.Controls.Add(this.worldView);
            this.tpageWorld.Location = new System.Drawing.Point(4, 22);
            this.tpageWorld.Name = "tpageWorld";
            this.tpageWorld.Padding = new System.Windows.Forms.Padding(3);
            this.tpageWorld.Size = new System.Drawing.Size(568, 464);
            this.tpageWorld.TabIndex = 1;
            this.tpageWorld.Text = "World View (LoU-Map)";
            this.tpageWorld.UseVisualStyleBackColor = true;
            // 
            // liveTabPageContent1
            // 
            this.liveTabPageContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveTabPageContent1.Location = new System.Drawing.Point(3, 3);
            this.liveTabPageContent1.Name = "liveTabPageContent1";
            this.liveTabPageContent1.Size = new System.Drawing.Size(751, 458);
            this.liveTabPageContent1.TabIndex = 0;
            // 
            // continentView
            // 
            this.continentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continentView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continentView.Location = new System.Drawing.Point(3, 3);
            this.continentView.Name = "continentView";
            this.continentView.Size = new System.Drawing.Size(562, 458);
            this.continentView.TabIndex = 0;
            this.continentView.Worlds = null;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 490);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "LoU Map Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tpageLive.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tpageLive;
        private LiveTabPageContent liveTabPageContent1;
    }
}