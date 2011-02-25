using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfoApp.V4.LouOfficial
{
    public partial class ContentLouContinent : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;

        public LoUSessionInfo Session
        {
            get { return m_Frame.MainForm.Session; }
        }
        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set { m_Frame = value; }
        }
        public ContentLouContinent()
        {
            InitializeComponent();
        }
    }
}
