using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Reports.core;
using EricUtility.Windows.Forms;
using EricUtility;
using System.Threading;

namespace LouMapInfoApp
{
    public partial class ReportForm : Form
    {
        public ReportForm(ReportInfo r, int d)
        {
            InitializeComponent();
            Text = StringUtility.RemoveBBCodeTags(r.Title);
            ContentReport cr = new ContentReport(r, d);
            Controls.Add(cr);
            cr.Dock = DockStyle.Fill;
        }
    }
}
