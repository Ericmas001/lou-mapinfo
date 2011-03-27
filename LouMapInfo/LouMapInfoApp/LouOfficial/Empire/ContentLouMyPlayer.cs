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
using LouMapInfoApp.Tools;
using LouMapInfo.OfficialLOU;

namespace LouMapInfoApp.LouOfficial.Empire
{
    public partial class ContentLouMyPlayer : UserControl, ILouContent
    {
        private class CityEntry : IComparable<CityEntry>
        {
            private LoUCityInfo info;

            public LoUCityInfo Info
            {
                get { return info; }
                set { info = value; }
            }
            public CityEntry(LoUCityInfo i)
            {
                info = i;
            }
            public override string ToString()
            {
                return info.Name;
            }

            #region IComparable<CityEntry> Members

            public int CompareTo(CityEntry other)
            {
                string nameMe = info.Name;
                string nameOther = other.Info.Name;
                if (nameMe[0] == '_')
                    nameMe = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ" + nameMe;
                if (nameOther[0] == '_')
                    nameOther = "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ" + nameOther;
                return nameMe.CompareTo(nameOther);
            }

            #endregion
        }
        CityEntry[] entrys;
        bool inEdit = false;
        string m_CurrentLayout;
        string m_PlannedLayout;
        private LayoutPictureBox lpb = new LayoutPictureBox();
        private ContentLayout cl = new ContentLayout();
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
                lstCities.Items.Clear();
                LoUCityInfo[] cities = pj.Cities();
                entrys = new CityEntry[cities.Length];
                for (int i = 0; i < cities.Length; ++i)
                    entrys[i] = new CityEntry(cities[i]);
                Array.Sort(entrys);
                lstCities.Items.AddRange(entrys);
            }
        }
        public ContentLouMyPlayer()
        {
            InitializeComponent();
            lpb.Location = new Point(0, 0);
            lpb.BackgroundImageLayout = ImageLayout.Zoom;
            lpb.Enabled = false;
            lpb.Size = new Size(768, 480);
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
        private void LoadCity(LoUCityInfo c)
        {
            btnRename.Enabled = true;
            txtRename.Visible = false;
            btnRenameCancel.Visible = false;
            btnRenameSave.Visible = false;
            sep1.Visible = true;
            sep2.Visible = true;
            sep3.Visible = true;
            btnShowCurrent.Visible = true;
            btnShowCurrent.BackColor = SystemColors.Highlight;
            KeyValuePair<string, string> notes = c.GetCityNote();
            int i = notes.Value.IndexOf("http://www.lou-fcp.co.uk/map.php?map=");

            if (i > -1)
            {
                string s = notes.Value;
                try
                {
                    m_PlannedLayout = s.Substring(i, 331);
                }
                catch (ArgumentOutOfRangeException)
                {
                    m_PlannedLayout = s.Substring(i);
                }
                btnShowPlan.BackColor = Color.White;
                btnShowPlan.Visible = true;
                btnEditLayout.Visible = true;
            }
            else
            {
                m_PlannedLayout = null;
                btnShowPlan.Visible = false;
                btnEditLayout.Visible = false;
            }
            CompleteLayout l = CompleteLayout.GetLayoutFromCity(c);
            m_CurrentLayout = l.GenerateFlashCityPlanner();
            lpb.Import(l);
            sep3.Visible = true;
            btnRename.Visible = true;
            pnlContenu.Controls.Clear();
            pnlContenu.Controls.Add(lpb);
            btnCreateLayout.Visible = true;
        }
        private void lstCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCities.SelectedIndex != -1)
            {
                LoUCityInfo c = ((CityEntry)lstCities.SelectedItem).Info;
                LoadCity(c);
            }
        }

        private void btnEditLayout_Click(object sender, EventArgs e)
        {
            sep2.Visible = false;
            btnShowCurrent.BackColor = Color.White;
            btnShowPlan.BackColor = Color.White;
            btnShowPlan.Visible = false;
            btnShowCurrent.Visible = false;
            btnSaveLayout.Visible = true;
            lstCities.Enabled = false;
            btnEditLayout.Visible = false;
            btnCreateLayout.Visible = false;
            sep3.Visible = false;
            btnRename.Visible = false;
            cl.Import(m_PlannedLayout);
            pnlContenu.Controls.Clear();
            pnlContenu.Controls.Add(cl);
            inEdit = true;
            cl.Dock = DockStyle.Fill;
            btnCloseEditLayout.Visible = true;
        }

        private void btnCloseEditLayout_Click(object sender, EventArgs e)
        {
            sep2.Visible = true;
            btnShowCurrent.Visible = true;
            btnCloseEditLayout.Visible = false;
            pnlContenu.Controls.Clear();
            pnlContenu.Controls.Add(lpb);
            btnCreateLayout.Visible = true;
            btnSaveLayout.Visible = false;
            sep3.Visible = true;
            btnRename.Visible = true;
            if (m_PlannedLayout != null)
            {
                btnEditLayout.Visible = true;
                btnShowPlan.Visible = true;
            }
            inEdit = false;
            lstCities.Enabled = true;
            btnShowCurrent_Click(sender,e);
        }
        public void FireKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (inEdit)
                cl.ContentLayout_KeyDown(this,e);
        }

        private void btnShowCurrent_Click(object sender, EventArgs e)
        {
            btnShowCurrent.BackColor = SystemColors.Highlight;
            btnShowPlan.BackColor = Color.White;
            lpb.Import(m_CurrentLayout);
        }

        private void btnShowPlan_Click(object sender, EventArgs e)
        {
            btnShowCurrent.BackColor = Color.White;
            btnShowPlan.BackColor = SystemColors.Highlight;
            lpb.Import(m_PlannedLayout);
        }

        private void btnCreateLayout_Click(object sender, EventArgs e)
        {
            sep3.Visible = false;
            btnRename.Visible = false;
            btnSaveLayout.Visible = true;
            sep2.Visible = false;
            btnShowCurrent.BackColor = Color.White;
            btnShowPlan.BackColor = Color.White;
            btnShowPlan.Visible = false;
            btnShowCurrent.Visible = false;
            lstCities.Enabled = false;
            btnEditLayout.Visible = false;
            btnCreateLayout.Visible = false;
            cl.Import(m_CurrentLayout);
            pnlContenu.Controls.Clear();
            pnlContenu.Controls.Add(cl);
            inEdit = true;
            cl.Dock = DockStyle.Fill;
            btnCloseEditLayout.Visible = true;
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            sep2.Visible = true;
            btnShowCurrent.Visible = true;
            btnCloseEditLayout.Visible = false;
            pnlContenu.Controls.Clear();
            pnlContenu.Controls.Add(lpb);
            btnCreateLayout.Visible = true;
            btnSaveLayout.Visible = false;
            if (m_PlannedLayout != null)
            {
                btnEditLayout.Visible = true;
                btnShowPlan.Visible = true;
            }
            inEdit = false;
            lstCities.Enabled = true;
            LoUCityInfo c = ((CityEntry)lstCities.SelectedItem).Info;
            int i = -1;
            KeyValuePair<string, string> notes = c.GetCityNote();
            string s = notes.Value;
            while ((i = s.IndexOf("http://www.lou-fcp.co.uk/map.php?map=")) > -1)
            {
                string plan = "";
                try
                {
                    plan = s.Substring(i, 331);
                }
                catch (ArgumentOutOfRangeException)
                {
                    plan = s.Substring(i);
                }
                s = s.Replace(plan, "");
            }
            c.SetCityNote(notes.Key, cl.GenerateFlashCityPlanner() + " " + s);
            LoadCity(c);
            btnShowPlan_Click(sender, e);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            sep1.Visible = false;
            sep2.Visible = false;
            btnShowCurrent.Visible = false;
            btnShowPlan.Visible = false;
            btnEditLayout.Visible = false;
            btnCreateLayout.Visible = false;
            btnRename.Enabled = false;
            txtRename.Visible = true;
            btnRenameCancel.Visible = true;
            btnRenameSave.Visible = true;
            LoUCityInfo c = ((CityEntry)lstCities.SelectedItem).Info;
            txtRename.Text = c.Name;
            txtRename.Focus();
        }

        private void btnRenameSave_Click(object sender, EventArgs e)
        {
            if (txtRename.Text.Length > 2)
            {
                CityEntry et = (CityEntry)lstCities.SelectedItem;
                lstCities.SelectedIndex = -1;
                LoUCityInfo c = et.Info;
                c.Rename(txtRename.Text);
                Array.Sort(entrys);
                lstCities.Items.Clear();
                lstCities.Items.AddRange(entrys);
                lstCities.SelectedItem = et;
            }
        }

        private void btnRenameCancel_Click(object sender, EventArgs e)
        {
            LoUCityInfo c = ((CityEntry)lstCities.SelectedItem).Info;
            LoadCity(c);
        }
    }
}
