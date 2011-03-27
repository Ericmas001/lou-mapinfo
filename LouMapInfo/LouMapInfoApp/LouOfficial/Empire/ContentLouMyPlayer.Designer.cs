namespace LouMapInfoApp.LouOfficial.Empire
{
    partial class ContentLouMyPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLouMyPlayer));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContenu = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lstCities = new System.Windows.Forms.ToolStripComboBox();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowCurrent = new System.Windows.Forms.ToolStripButton();
            this.btnShowPlan = new System.Windows.Forms.ToolStripButton();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditLayout = new System.Windows.Forms.ToolStripButton();
            this.btnCreateLayout = new System.Windows.Forms.ToolStripButton();
            this.btnCloseEditLayout = new System.Windows.Forms.ToolStripButton();
            this.btnSaveLayout = new System.Windows.Forms.ToolStripButton();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRename = new System.Windows.Forms.ToolStripButton();
            this.txtRename = new System.Windows.Forms.ToolStripTextBox();
            this.btnRenameSave = new System.Windows.Forms.ToolStripButton();
            this.btnRenameCancel = new System.Windows.Forms.ToolStripButton();
            this.pnlContent.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.pnlContenu);
            this.pnlContent.Controls.Add(this.toolStrip1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1050, 247);
            this.pnlContent.TabIndex = 19;
            // 
            // pnlContenu
            // 
            this.pnlContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenu.Location = new System.Drawing.Point(0, 25);
            this.pnlContenu.Name = "pnlContenu";
            this.pnlContenu.Size = new System.Drawing.Size(1050, 222);
            this.pnlContenu.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lstCities,
            this.sep1,
            this.btnShowCurrent,
            this.btnShowPlan,
            this.sep2,
            this.btnEditLayout,
            this.btnCreateLayout,
            this.btnCloseEditLayout,
            this.btnSaveLayout,
            this.sep3,
            this.btnRename,
            this.txtRename,
            this.btnRenameSave,
            this.btnRenameCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1050, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "City: ";
            // 
            // lstCities
            // 
            this.lstCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstCities.Name = "lstCities";
            this.lstCities.Size = new System.Drawing.Size(121, 25);
            this.lstCities.SelectedIndexChanged += new System.EventHandler(this.lstCities_SelectedIndexChanged);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 25);
            this.sep1.Visible = false;
            // 
            // btnShowCurrent
            // 
            this.btnShowCurrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowCurrent.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCurrent.Image")));
            this.btnShowCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowCurrent.Name = "btnShowCurrent";
            this.btnShowCurrent.Size = new System.Drawing.Size(90, 22);
            this.btnShowCurrent.Text = "Current Layout";
            this.btnShowCurrent.Visible = false;
            this.btnShowCurrent.Click += new System.EventHandler(this.btnShowCurrent_Click);
            // 
            // btnShowPlan
            // 
            this.btnShowPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPlan.Image")));
            this.btnShowPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowPlan.Name = "btnShowPlan";
            this.btnShowPlan.Size = new System.Drawing.Size(93, 22);
            this.btnShowPlan.Text = "Planned Layout";
            this.btnShowPlan.Visible = false;
            this.btnShowPlan.Click += new System.EventHandler(this.btnShowPlan_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 25);
            this.sep2.Visible = false;
            // 
            // btnEditLayout
            // 
            this.btnEditLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnEditLayout.Image")));
            this.btnEditLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditLayout.Name = "btnEditLayout";
            this.btnEditLayout.Size = new System.Drawing.Size(116, 22);
            this.btnEditLayout.Text = "Edit Planned Layout";
            this.btnEditLayout.Visible = false;
            this.btnEditLayout.Click += new System.EventHandler(this.btnEditLayout_Click);
            // 
            // btnCreateLayout
            // 
            this.btnCreateLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCreateLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateLayout.Image")));
            this.btnCreateLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateLayout.Name = "btnCreateLayout";
            this.btnCreateLayout.Size = new System.Drawing.Size(111, 22);
            this.btnCreateLayout.Text = "Create New Layout";
            this.btnCreateLayout.Visible = false;
            this.btnCreateLayout.Click += new System.EventHandler(this.btnCreateLayout_Click);
            // 
            // btnCloseEditLayout
            // 
            this.btnCloseEditLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCloseEditLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseEditLayout.Image")));
            this.btnCloseEditLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseEditLayout.Name = "btnCloseEditLayout";
            this.btnCloseEditLayout.Size = new System.Drawing.Size(89, 22);
            this.btnCloseEditLayout.Text = "Discard Layout";
            this.btnCloseEditLayout.Visible = false;
            this.btnCloseEditLayout.Click += new System.EventHandler(this.btnCloseEditLayout_Click);
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLayout.Image")));
            this.btnSaveLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.Size = new System.Drawing.Size(74, 22);
            this.btnSaveLayout.Text = "Save Layout";
            this.btnSaveLayout.Visible = false;
            this.btnSaveLayout.Click += new System.EventHandler(this.btnSaveLayout_Click);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 25);
            this.sep3.Visible = false;
            // 
            // btnRename
            // 
            this.btnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRename.Image = ((System.Drawing.Image)(resources.GetObject("btnRename.Image")));
            this.btnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(54, 22);
            this.btnRename.Text = "Rename";
            this.btnRename.Visible = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txtRename
            // 
            this.txtRename.BackColor = System.Drawing.Color.White;
            this.txtRename.MaxLength = 12;
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(100, 25);
            this.txtRename.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRename.Visible = false;
            // 
            // btnRenameSave
            // 
            this.btnRenameSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRenameSave.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameSave.Image")));
            this.btnRenameSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameSave.Name = "btnRenameSave";
            this.btnRenameSave.Size = new System.Drawing.Size(35, 22);
            this.btnRenameSave.Text = "Save";
            this.btnRenameSave.Visible = false;
            this.btnRenameSave.Click += new System.EventHandler(this.btnRenameSave_Click);
            // 
            // btnRenameCancel
            // 
            this.btnRenameCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRenameCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameCancel.Image")));
            this.btnRenameCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameCancel.Name = "btnRenameCancel";
            this.btnRenameCancel.Size = new System.Drawing.Size(47, 22);
            this.btnRenameCancel.Text = "Cancel";
            this.btnRenameCancel.Visible = false;
            this.btnRenameCancel.Click += new System.EventHandler(this.btnRenameCancel_Click);
            // 
            // ContentLouMyPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlContent);
            this.DoubleBuffered = true;
            this.Name = "ContentLouMyPlayer";
            this.Size = new System.Drawing.Size(1050, 247);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox lstCities;
        private System.Windows.Forms.Panel pnlContenu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnCloseEditLayout;
        private System.Windows.Forms.ToolStripButton btnEditLayout;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripButton btnShowCurrent;
        private System.Windows.Forms.ToolStripButton btnShowPlan;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripButton btnCreateLayout;
        private System.Windows.Forms.ToolStripButton btnSaveLayout;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripButton btnRename;
        private System.Windows.Forms.ToolStripTextBox txtRename;
        private System.Windows.Forms.ToolStripButton btnRenameSave;
        private System.Windows.Forms.ToolStripButton btnRenameCancel;



    }
}
