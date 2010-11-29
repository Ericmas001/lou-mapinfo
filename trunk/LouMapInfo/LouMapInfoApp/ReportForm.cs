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
        public ReportForm(string title, string report)
        {

            InitializeComponent();
            Text = title;
            webBrowser1.DocumentText = report;
            webBrowser1.AllowNavigation = false;
        }
    }
}
