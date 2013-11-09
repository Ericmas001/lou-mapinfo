namespace LouMapInfoApp.LouOfficial
{
    partial class ContentLouConnection
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
            this.centerPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSessionID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnectSessionID = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectCredentials = new System.Windows.Forms.Button();
            this.lblConnectUser = new System.Windows.Forms.Label();
            this.statePictureBox1 = new EricUtility.Windows.Forms.StatePictureBox();
            this.lstServerNames2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstServerNames1 = new System.Windows.Forms.ComboBox();
            this.centerPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // centerPanel
            // 
            this.centerPanel.BackColor = System.Drawing.Color.Transparent;
            this.centerPanel.Controls.Add(this.panel2);
            this.centerPanel.Controls.Add(this.label5);
            this.centerPanel.Controls.Add(this.panel1);
            this.centerPanel.Controls.Add(this.lblConnectUser);
            this.centerPanel.Location = new System.Drawing.Point(21, 15);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(350, 317);
            this.centerPanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lstServerNames2);
            this.panel2.Controls.Add(this.txtSessionID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnConnectSessionID);
            this.panel2.Location = new System.Drawing.Point(9, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 96);
            this.panel2.TabIndex = 7;
            // 
            // txtSessionID
            // 
            this.txtSessionID.Location = new System.Drawing.Point(66, 9);
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Size = new System.Drawing.Size(264, 20);
            this.txtSessionID.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "SessionID:";
            // 
            // btnConnectSessionID
            // 
            this.btnConnectSessionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectSessionID.Location = new System.Drawing.Point(137, 68);
            this.btnConnectSessionID.Name = "btnConnectSessionID";
            this.btnConnectSessionID.Size = new System.Drawing.Size(75, 23);
            this.btnConnectSessionID.TabIndex = 0;
            this.btnConnectSessionID.Text = "CONNECT";
            this.btnConnectSessionID.UseVisualStyleBackColor = true;
            this.btnConnectSessionID.Click += new System.EventHandler(this.btnConnectSessionID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Connect with SessionID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lstServerNames1);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnConnectCredentials);
            this.panel1.Location = new System.Drawing.Point(7, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 127);
            this.panel1.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 42);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(264, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password: ";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(68, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(264, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mail:";
            // 
            // btnConnectCredentials
            // 
            this.btnConnectCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectCredentials.Location = new System.Drawing.Point(139, 99);
            this.btnConnectCredentials.Name = "btnConnectCredentials";
            this.btnConnectCredentials.Size = new System.Drawing.Size(75, 23);
            this.btnConnectCredentials.TabIndex = 0;
            this.btnConnectCredentials.Text = "CONNECT";
            this.btnConnectCredentials.UseVisualStyleBackColor = true;
            this.btnConnectCredentials.Click += new System.EventHandler(this.btnConnectCredentials_Click);
            // 
            // lblConnectUser
            // 
            this.lblConnectUser.AutoSize = true;
            this.lblConnectUser.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectUser.Location = new System.Drawing.Point(1, 3);
            this.lblConnectUser.Name = "lblConnectUser";
            this.lblConnectUser.Size = new System.Drawing.Size(206, 20);
            this.lblConnectUser.TabIndex = 4;
            this.lblConnectUser.Text = "Connect with credentials";
            // 
            // statePictureBox1
            // 
            this.statePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.None;
            this.statePictureBox1.Location = new System.Drawing.Point(401, 3);
            this.statePictureBox1.Name = "statePictureBox1";
            this.statePictureBox1.Size = new System.Drawing.Size(22, 20);
            this.statePictureBox1.TabIndex = 5;
            this.statePictureBox1.TabStop = false;
            // 
            // lstServerNames2
            // 
            this.lstServerNames2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstServerNames2.FormattingEnabled = true;
            this.lstServerNames2.Location = new System.Drawing.Point(66, 35);
            this.lstServerNames2.Name = "lstServerNames2";
            this.lstServerNames2.Size = new System.Drawing.Size(264, 21);
            this.lstServerNames2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "World:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "World:";
            // 
            // lstServerNames1
            // 
            this.lstServerNames1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstServerNames1.FormattingEnabled = true;
            this.lstServerNames1.Location = new System.Drawing.Point(68, 68);
            this.lstServerNames1.Name = "lstServerNames1";
            this.lstServerNames1.Size = new System.Drawing.Size(264, 21);
            this.lstServerNames1.TabIndex = 5;
            // 
            // ContentLouConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            //this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.statePictureBox1);
            this.Controls.Add(this.centerPanel);
            this.DoubleBuffered = true;
            this.Name = "ContentLouConnection";
            this.Size = new System.Drawing.Size(426, 395);
            this.Resize += new System.EventHandler(this.ContentLouConnection_Resize);
            this.centerPanel.ResumeLayout(false);
            this.centerPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSessionID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnectSessionID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectCredentials;
        private System.Windows.Forms.Label lblConnectUser;
        private EricUtility.Windows.Forms.StatePictureBox statePictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstServerNames2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lstServerNames1;

    }
}
