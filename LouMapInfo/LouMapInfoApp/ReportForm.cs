using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Reports.core;

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
        public ReportForm(ReportInfo r, int d)
        {
            InitializeComponent();
            Text = r.Title;
            webBrowser1.DocumentText = r.Report(d);
            webBrowser1.AllowNavigation = false;
            txtBBCode.Text = r.BBCode(d);
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
