using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp
{
    public partial class ReportForm : Form
    {
        public ReportForm(string title, string report, string bbcode)
        {

            InitializeComponent();
            Text = title;
            webBrowser1.DocumentText = report;
            webBrowser1.AllowNavigation = false;
            txtBBCode.Text = bbcode.Replace("\n", Environment.NewLine);
        }

        private void btnCopyBBCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBCode.Text);
        }

        private void txtBBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                txtBBCode.SelectAll();
        }
    }
}
