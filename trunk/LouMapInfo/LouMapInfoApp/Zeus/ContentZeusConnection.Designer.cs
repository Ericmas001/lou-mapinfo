namespace LouMapInfoApp.Zeus
{
    partial class ContentZeusConnection
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lstServerNames1 = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectCredentials = new System.Windows.Forms.Button();
            this.lblConnectUser = new System.Windows.Forms.Label();
            this.statePictureBox1 = new EricUtility.Windows.Forms.StatePictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lstServerNames2 = new System.Windows.Forms.ComboBox();
            this.txtUsername2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLostPassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.centerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.centerPanel.Size = new System.Drawing.Size(350, 299);
            this.centerPanel.TabIndex = 4;
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
            this.panel1.Size = new System.Drawing.Size(337, 125);
            this.panel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "World:";
            // 
            // lstServerNames1
            // 
            this.lstServerNames1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstServerNames1.FormattingEnabled = true;
            this.lstServerNames1.Location = new System.Drawing.Point(116, 68);
            this.lstServerNames1.Name = "lstServerNames1";
            this.lstServerNames1.Size = new System.Drawing.Size(216, 21);
            this.lstServerNames1.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(116, 42);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(216, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ZEUS Password: ";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(116, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(216, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PlayerName on LoU:";
            // 
            // btnConnectCredentials
            // 
            this.btnConnectCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectCredentials.Location = new System.Drawing.Point(139, 95);
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
            this.lblConnectUser.Size = new System.Drawing.Size(127, 20);
            this.lblConnectUser.TabIndex = 4;
            this.lblConnectUser.Text = "Log into ZEUS";
            // 
            // statePictureBox1
            // 
            this.statePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.None;
            this.statePictureBox1.Location = new System.Drawing.Point(376, 3);
            this.statePictureBox1.Name = "statePictureBox1";
            this.statePictureBox1.Size = new System.Drawing.Size(22, 20);
            this.statePictureBox1.TabIndex = 5;
            this.statePictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lstServerNames2);
            this.panel2.Controls.Add(this.txtUsername2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnLostPassword);
            this.panel2.Location = new System.Drawing.Point(7, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 95);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "World:";
            // 
            // lstServerNames2
            // 
            this.lstServerNames2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstServerNames2.FormattingEnabled = true;
            this.lstServerNames2.Location = new System.Drawing.Point(116, 35);
            this.lstServerNames2.Name = "lstServerNames2";
            this.lstServerNames2.Size = new System.Drawing.Size(216, 21);
            this.lstServerNames2.TabIndex = 5;
            // 
            // txtUsername2
            // 
            this.txtUsername2.Location = new System.Drawing.Point(116, 9);
            this.txtUsername2.Name = "txtUsername2";
            this.txtUsername2.Size = new System.Drawing.Size(216, 20);
            this.txtUsername2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "PlayerName on LoU:";
            // 
            // btnLostPassword
            // 
            this.btnLostPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLostPassword.Location = new System.Drawing.Point(107, 62);
            this.btnLostPassword.Name = "btnLostPassword";
            this.btnLostPassword.Size = new System.Drawing.Size(142, 23);
            this.btnLostPassword.TabIndex = 0;
            this.btnLostPassword.Text = "GET PASSWORD";
            this.btnLostPassword.UseVisualStyleBackColor = true;
            this.btnLostPassword.Click += new System.EventHandler(this.btnLostPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(326, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Register on ZEUS / Password Recovery";
            // 
            // ContentZeusConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.statePictureBox1);
            this.Controls.Add(this.centerPanel);
            this.DoubleBuffered = true;
            this.Name = "ContentZeusConnection";
            this.Size = new System.Drawing.Size(401, 330);
            this.Resize += new System.EventHandler(this.ContentLouConnection_Resize);
            this.centerPanel.ResumeLayout(false);
            this.centerPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statePictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectCredentials;
        private System.Windows.Forms.Label lblConnectUser;
        private EricUtility.Windows.Forms.StatePictureBox statePictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lstServerNames1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstServerNames2;
        private System.Windows.Forms.TextBox txtUsername2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLostPassword;
        private System.Windows.Forms.Label label5;

    }
}
