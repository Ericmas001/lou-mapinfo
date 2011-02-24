﻿namespace LouMapInfoApp.V4
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstSubItems = new System.Windows.Forms.ListBox();
            this.btnMenuTools = new System.Windows.Forms.RadioButton();
            this.btnMenuMap = new System.Windows.Forms.RadioButton();
            this.btnMenuZeus = new System.Windows.Forms.RadioButton();
            this.btnMenuOfficial = new System.Windows.Forms.RadioButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstSubItems);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuTools);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuMap);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuZeus);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuOfficial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitContainer1.Size = new System.Drawing.Size(784, 562);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstSubItems
            // 
            this.lstSubItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSubItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSubItems.FormattingEnabled = true;
            this.lstSubItems.IntegralHeight = false;
            this.lstSubItems.ItemHeight = 16;
            this.lstSubItems.Location = new System.Drawing.Point(2, 280);
            this.lstSubItems.Name = "lstSubItems";
            this.lstSubItems.Size = new System.Drawing.Size(206, 282);
            this.lstSubItems.TabIndex = 8;
            this.lstSubItems.SelectedIndexChanged += new System.EventHandler(this.lstSubItems_SelectedIndexChanged);
            // 
            // btnMenuTools
            // 
            this.btnMenuTools.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTools.Image = global::LouMapInfoApp.Properties.Resources.icon_tool;
            this.btnMenuTools.Location = new System.Drawing.Point(1, 210);
            this.btnMenuTools.Name = "btnMenuTools";
            this.btnMenuTools.Size = new System.Drawing.Size(208, 71);
            this.btnMenuTools.TabIndex = 7;
            this.btnMenuTools.Text = "Tools";
            this.btnMenuTools.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuTools.UseVisualStyleBackColor = true;
            this.btnMenuTools.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // btnMenuMap
            // 
            this.btnMenuMap.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMap.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuMap.Image")));
            this.btnMenuMap.Location = new System.Drawing.Point(1, 140);
            this.btnMenuMap.Name = "btnMenuMap";
            this.btnMenuMap.Size = new System.Drawing.Size(208, 71);
            this.btnMenuMap.TabIndex = 6;
            this.btnMenuMap.Text = "LoU-Map";
            this.btnMenuMap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuMap.UseVisualStyleBackColor = true;
            this.btnMenuMap.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // btnMenuZeus
            // 
            this.btnMenuZeus.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuZeus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuZeus.Image = global::LouMapInfoApp.Properties.Resources.Zeus_icon;
            this.btnMenuZeus.Location = new System.Drawing.Point(1, 70);
            this.btnMenuZeus.Name = "btnMenuZeus";
            this.btnMenuZeus.Size = new System.Drawing.Size(208, 71);
            this.btnMenuZeus.TabIndex = 5;
            this.btnMenuZeus.Text = "ZEUS";
            this.btnMenuZeus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuZeus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuZeus.UseVisualStyleBackColor = true;
            this.btnMenuZeus.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // btnMenuOfficial
            // 
            this.btnMenuOfficial.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuOfficial.Checked = true;
            this.btnMenuOfficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuOfficial.Image = global::LouMapInfoApp.Properties.Resources.logo_LOU;
            this.btnMenuOfficial.Location = new System.Drawing.Point(1, 0);
            this.btnMenuOfficial.Name = "btnMenuOfficial";
            this.btnMenuOfficial.Size = new System.Drawing.Size(209, 71);
            this.btnMenuOfficial.TabIndex = 4;
            this.btnMenuOfficial.TabStop = true;
            this.btnMenuOfficial.Text = "Official LoU";
            this.btnMenuOfficial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuOfficial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuOfficial.UseVisualStyleBackColor = true;
            this.btnMenuOfficial.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.Text = "LoU Map Info";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton btnMenuOfficial;
        private System.Windows.Forms.RadioButton btnMenuMap;
        private System.Windows.Forms.RadioButton btnMenuZeus;
        private System.Windows.Forms.RadioButton btnMenuTools;
        private System.Windows.Forms.ListBox lstSubItems;
    }
}