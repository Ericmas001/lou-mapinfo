using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;

namespace LouMapInfoApp.LouOfficial.Empire
{
    public partial class ContentEmpireSummary : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;
        public ContentEmpireSummary()
        {
            InitializeComponent();
        }
        public SessionInfo Session
        {
            get
            {
                return m_Frame.MainForm.Session;
            }
        }

        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set
            {
                m_Frame = value;

                //DO LOADING STUFF HERE
            }
        }
    }
}
