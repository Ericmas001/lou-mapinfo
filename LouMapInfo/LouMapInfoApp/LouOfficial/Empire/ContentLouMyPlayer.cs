using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.OfficialLOU;
using System.Threading;
using LouMapInfo.Layout;

namespace LouMapInfoApp.LouOfficial.Empire
{
    public partial class ContentLouMyPlayer : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;

        public LoUSessionInfo Session
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


                LoUPlayerInfo pj = Session.World.Player(Session.PlayerID);
                toolStripComboBox1.Items.Clear();
                foreach (LoUCityInfo c in pj.Cities())
                {
                    toolStripComboBox1.Items.Add(c);
                }
            }
        }
        public ContentLouMyPlayer()
        {
            InitializeComponent();
        }
        public delegate void ReportHandler(ReportInfo r);
        public void OpenReport(ReportInfo r)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportHandler(OpenReport), r);
                return;
            }
            // ReportForm.ShowReport(r, Properties.Settings.Default.lastWDetailLvl);
            ContentReport content = new ContentReport(r, Properties.Settings.Default.lastWDetailLvl);
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                LoUCityInfo c = (LoUCityInfo)toolStripComboBox1.SelectedItem;
                CompleteLayout l = CompleteLayout.GetLayoutFromCity(c);
                layoutPictureBox1.Import(l);
            }
        }
    }
}
