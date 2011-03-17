using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouGroupsManage : UserControl
    {
        public delegate void EmptyHandler();
        public event EmptyHandler CloseIsIminent = delegate { };
        public ContentLouGroupsManage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseIsIminent();
        }
    }
}
