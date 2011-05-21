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

                lblScore.Text = Session.MyPlayer.Score.ToString("N0");
                lblRank.Text = Session.MyPlayer.Rank.ToString("N0");
                lblGold.Text = Session.MyPlayer.Gold.ToString("N0");
                lblMana.Text = Session.MyPlayer.Mana.ToString("N0");
                lblPurWood.Text = Session.MyPlayer.PurWood.ToString("N0");
                lblPurStone.Text = Session.MyPlayer.PurStone.ToString("N0");
                lblPurIron.Text = Session.MyPlayer.PurIron.ToString("N0");
                lblPurFood.Text = Session.MyPlayer.PurFood.ToString("N0");
            }
        }
    }
}
