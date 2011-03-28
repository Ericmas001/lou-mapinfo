using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports;
using System.Threading;
using LouMapInfo.Zeus;

namespace LouMapInfoApp.Zeus
{
    public partial class ContentZeusAccount : UserControl, IZeusContent
    {
        private ContentZeus m_Frame;

        public ZeusSessionInfo Session
        {
            get { return m_Frame.MainForm.ZeusSession; }
        }
        public ContentZeus Frame
        {
            get { return m_Frame; }
            set
            {
                m_Frame = value;
            }
        }
        public ContentZeusAccount()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != Session.Password)
                MessageBox.Show("Old Password is wrong");
            else if (txtPassword1.Text != txtPassword2.Text)
                MessageBox.Show("'New Password' and 'Confirm Password' are not the same");
            else
            {
                Session.ChangePassword(txtPassword1.Text);
                Session.Disconnect();
                Frame.MainForm.ZeusSession = null;
                Frame.MainForm.FillZeus();
            }
        }
    }
}
