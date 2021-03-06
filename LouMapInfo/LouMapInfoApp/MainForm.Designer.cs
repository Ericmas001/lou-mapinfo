﻿namespace LouMapInfoApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnMenuEmpire = new System.Windows.Forms.RadioButton();
            this.lstSubItems = new System.Windows.Forms.ListBox();
            this.btnMenuHelp = new System.Windows.Forms.RadioButton();
            this.btnMenuTools = new System.Windows.Forms.RadioButton();
            this.btnMenuOfficial = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.LinkLabel();
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuEmpire);
            this.splitContainer1.Panel1.Controls.Add(this.lstSubItems);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuHelp);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuTools);
            this.splitContainer1.Panel1.Controls.Add(this.btnMenuOfficial);
            this.splitContainer1.Panel1MinSize = 10;
            // 
            // splitContainer1.Panel2
            // 
            //this.splitContainer1.Panel2.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitContainer1.Panel2MinSize = 10;
            this.splitContainer1.Size = new System.Drawing.Size(934, 537);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(196, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(14, 537);
            this.button1.TabIndex = 10;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // btnMenuEmpire
            // 
            this.btnMenuEmpire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuEmpire.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuEmpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuEmpire.Image = global::LouMapInfoApp.Properties.Resources.menu_Empire;
            this.btnMenuEmpire.Location = new System.Drawing.Point(-2, 70);
            this.btnMenuEmpire.Name = "btnMenuEmpire";
            this.btnMenuEmpire.Size = new System.Drawing.Size(198, 71);
            this.btnMenuEmpire.TabIndex = 9;
            this.btnMenuEmpire.Text = "Manage your Empire";
            this.btnMenuEmpire.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuEmpire.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuEmpire.UseVisualStyleBackColor = true;
            this.btnMenuEmpire.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            this.btnMenuEmpire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // lstSubItems
            // 
            this.lstSubItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSubItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSubItems.FormattingEnabled = true;
            this.lstSubItems.IntegralHeight = false;
            this.lstSubItems.ItemHeight = 16;
            this.lstSubItems.Location = new System.Drawing.Point(0, 280);
            this.lstSubItems.Name = "lstSubItems";
            this.lstSubItems.Size = new System.Drawing.Size(196, 257);
            this.lstSubItems.TabIndex = 8;
            this.lstSubItems.SelectedIndexChanged += new System.EventHandler(this.lstSubItems_SelectedIndexChanged);
            this.lstSubItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // btnMenuHelp
            // 
            this.btnMenuHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuHelp.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHelp.Image = global::LouMapInfoApp.Properties.Resources.menu_Official;
            this.btnMenuHelp.Location = new System.Drawing.Point(-2, 210);
            this.btnMenuHelp.Name = "btnMenuHelp";
            this.btnMenuHelp.Size = new System.Drawing.Size(198, 71);
            this.btnMenuHelp.TabIndex = 7;
            this.btnMenuHelp.Text = "Help / About";
            this.btnMenuHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuHelp.UseVisualStyleBackColor = true;
            this.btnMenuHelp.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            this.btnMenuHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // btnMenuTools
            // 
            this.btnMenuTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuTools.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTools.Image = global::LouMapInfoApp.Properties.Resources.menu_Tools;
            this.btnMenuTools.Location = new System.Drawing.Point(-2, 140);
            this.btnMenuTools.Name = "btnMenuTools";
            this.btnMenuTools.Size = new System.Drawing.Size(198, 71);
            this.btnMenuTools.TabIndex = 5;
            this.btnMenuTools.Text = "Tools";
            this.btnMenuTools.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuTools.UseVisualStyleBackColor = true;
            this.btnMenuTools.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            this.btnMenuTools.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // btnMenuOfficial
            // 
            this.btnMenuOfficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuOfficial.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMenuOfficial.Checked = true;
            this.btnMenuOfficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuOfficial.Image = global::LouMapInfoApp.Properties.Resources.menu_Map;
            this.btnMenuOfficial.Location = new System.Drawing.Point(-2, 0);
            this.btnMenuOfficial.Name = "btnMenuOfficial";
            this.btnMenuOfficial.Size = new System.Drawing.Size(198, 71);
            this.btnMenuOfficial.TabIndex = 4;
            this.btnMenuOfficial.TabStop = true;
            this.btnMenuOfficial.Text = "Generate Reports";
            this.btnMenuOfficial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuOfficial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuOfficial.UseVisualStyleBackColor = true;
            this.btnMenuOfficial.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            this.btnMenuOfficial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(934, 25);
            this.label1.TabIndex = 1;
            this.label1.TabStop = true;
            this.label1.Text = "Generate reports online at http://www.loumapinfo.com !!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label1_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "LoU Map Info";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubItems_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton btnMenuOfficial;
        private System.Windows.Forms.RadioButton btnMenuTools;
        private System.Windows.Forms.RadioButton btnMenuHelp;
        private System.Windows.Forms.ListBox lstSubItems;
        private System.Windows.Forms.RadioButton btnMenuEmpire;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel label1;
    }
}