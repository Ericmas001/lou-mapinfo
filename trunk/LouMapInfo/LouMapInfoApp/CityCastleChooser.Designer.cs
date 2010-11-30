namespace LouMapInfoApp
{
    partial class CityCastleChooser
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
            this.chkCity = new System.Windows.Forms.CheckBox();
            this.chkCastles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkCity
            // 
            this.chkCity.AutoSize = true;
            this.chkCity.BackColor = System.Drawing.Color.Transparent;
            this.chkCity.Checked = true;
            this.chkCity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.chkCity.Location = new System.Drawing.Point(3, 3);
            this.chkCity.Name = "chkCity";
            this.chkCity.Size = new System.Drawing.Size(86, 29);
            this.chkCity.TabIndex = 0;
            this.chkCity.Text = "Cities";
            this.chkCity.UseVisualStyleBackColor = false;
            // 
            // chkCastles
            // 
            this.chkCastles.AutoSize = true;
            this.chkCastles.BackColor = System.Drawing.Color.Transparent;
            this.chkCastles.Checked = true;
            this.chkCastles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCastles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCastles.Location = new System.Drawing.Point(95, 3);
            this.chkCastles.Name = "chkCastles";
            this.chkCastles.Size = new System.Drawing.Size(104, 29);
            this.chkCastles.TabIndex = 1;
            this.chkCastles.Text = "Castles";
            this.chkCastles.UseVisualStyleBackColor = false;
            // 
            // CityCastleChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chkCastles);
            this.Controls.Add(this.chkCity);
            this.Name = "CityCastleChooser";
            this.Size = new System.Drawing.Size(202, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCity;
        private System.Windows.Forms.CheckBox chkCastles;
    }
}
