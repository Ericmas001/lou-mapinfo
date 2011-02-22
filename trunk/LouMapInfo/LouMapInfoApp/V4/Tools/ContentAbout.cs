using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LouMapInfoApp.V4.Tools
{
    public partial class ContentAbout : UserControl
    {
        public ContentAbout()
        {
            InitializeComponent();
        }

        private void GeneralUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((Control)sender).Text);
        }

        private void MailUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:"+((Control)sender).Text);
        }
    }
}
