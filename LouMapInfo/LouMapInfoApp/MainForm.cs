using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfoApp.Tools;
using LouMapInfoApp.LouMap;
using LouMapInfo.Entities;
using LouMapInfoApp.LouOfficial;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Zeus;
using LouMapInfoApp.Zeus;
using LouMapInfoApp.LouOfficial.Empire;

namespace LouMapInfoApp
{
    public partial class MainForm : Form
    {
        private LoUSessionInfo m_Session = null;
        private ZeusSessionInfo m_ZeusSession = null;

        public LoUSessionInfo Session
        {
            get { return m_Session; }
            set { m_Session = value; }
        }
        public ZeusSessionInfo ZeusSession
        {
            get { return m_ZeusSession; }
            set { m_ZeusSession = value; }
        }
        private Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public Dictionary<string, PanelEntry> tabs = new Dictionary<string, PanelEntry>();
        public MainForm()
        {
            InitializeComponent();
            menuButton_CheckedChanged(btnMenuOfficial, new EventArgs());

            //TEMP:
            btnMenuTools.Checked = true;
        }

        private void menuButton_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            lstSubItems.Items.Clear();
            RadioButton btn = (RadioButton)sender;
            int buttonY = btn.Top;
            int lstOldY = lstSubItems.Top;
            foreach (Control c in btn.Parent.Controls)
                if (c is RadioButton)
                {
                    if (c.Top > buttonY && c.Top < lstOldY)
                    {
                        c.Location = new Point(c.Left, c.Top + lstSubItems.Height);
                        c.Anchor = (AnchorStyles)(AnchorStyles.Right | AnchorStyles.Bottom);
                    }
                    else if (c.Top <= buttonY && c.Top > lstOldY)
                    {
                        c.Location = new Point(c.Left, c.Top - lstSubItems.Height);
                        c.Anchor = (AnchorStyles)(AnchorStyles.Right | AnchorStyles.Top);
                    }
                }
            int lstNewY = btn.Bottom - 1;
            lstSubItems.Location = new Point(lstSubItems.Left, lstNewY);
            FillItems(btn);
            if (lstSubItems.Items.Count > 0)
                lstSubItems.SelectedIndex = 0;
        }
        private void FillItems(RadioButton btn)
        {
            if (btn == btnMenuOfficial)
            {
                FillOfficial(false);
            }
            else if (btn == btnMenuZeus)
            {
                FillZeus(false);
            }
            else if (btn == btnMenuEmpire)
            {
                FillEmpire(false);
            }
            else if (btn == btnMenuMap)
            {
                AddSubItem(btn, "Continent View", new ContentLMContinent(worlds));
                AddSubItem(btn, "World View", new ContentLMWorld(worlds));
            }
            else if (btn == btnMenuTools)
            {
                AddSubItem(btn, "Layout", new ContentLayout());
                AddSubItem(btn, "About", new ContentAbout());
                AddSubItem(btn, "FAQ", new ContentFAQ());
            }
        }
        const string CONNECT = "Connection";

        public void FillZeus()
        {
            FillZeus(true);
        }
        private void FillZeus(bool remove)
        {
            lstSubItems.Items.Clear();
            if (remove)
            {
                string[] keys = new string[tabs.Keys.Count];
                tabs.Keys.CopyTo(keys, 0);
                foreach (string k in keys)
                    if (k.StartsWith(btnMenuZeus.Name) && k != (btnMenuZeus.Name + "_" + CONNECT))
                        tabs.Remove(k);
            }
            if (m_ZeusSession == null)
            {
                AddSubItem(btnMenuZeus, CONNECT, new ContentZeusConnection(this));
            }
            else
            {
                AddSubItem(btnMenuZeus, "Account", new ContentZeus(this, new ContentZeusAccount()));
            }
            if (lstSubItems.Items.Count > 0)
                lstSubItems.SelectedIndex = 0;

        }

        public void FillOfficial()
        {
            FillOfficial(true);
            FillEmpire(true);
            FillItems(btnMenuEmpire.Checked ? btnMenuEmpire : btnMenuOfficial);
        }
        private void FillOfficial(bool remove)
        {
            lstSubItems.Items.Clear();
            if (remove)
            {
                string[] keys = new string[tabs.Keys.Count];
                tabs.Keys.CopyTo(keys, 0);
                foreach (string k in keys)
                    if (k.StartsWith(btnMenuOfficial.Name) && k != (btnMenuOfficial.Name + "_" + CONNECT))
                        tabs.Remove(k);
            }
            if (m_Session == null)
            {
                AddSubItem(btnMenuOfficial, CONNECT, new ContentLouConnection(this));
            }
            else
            {
                /*
                AddSubItem(btnMenuOfficial, m_Session.World.Player(m_Session.PlayerID).Name, new ContentLoUOfficial(this, new ContentLouMyPlayer()));
                if( m_Session.AllianceID > 0 )
                    AddSubItem(btnMenuOfficial, m_Session.World.Alliance(m_Session.AllianceID).Name, new ContentLoUOfficial(this, new ContentLouMyAlliance()));
                */
                AddSubItem(btnMenuOfficial, "Rankings", new ContentLoUOfficial(this, new ContentLouRankings(), Properties.Resources.menu_Official));
                AddSubItem(btnMenuOfficial, "Players", new ContentLoUOfficial(this, new ContentLouPlayers(), Properties.Resources.menu_Official));
                AddSubItem(btnMenuOfficial, "Alliances", new ContentLoUOfficial(this, new ContentLouAlliances(), Properties.Resources.menu_Official));
                AddSubItem(btnMenuOfficial, "Continent", new ContentLoUOfficial(this, new ContentLouContinent(), Properties.Resources.menu_Official));
                AddSubItem(btnMenuOfficial, "Virtues", new ContentLoUOfficial(this, new ContentLouVirtues(), Properties.Resources.menu_Official));
                //TODO: AddSubItem(btnMenuOfficial, "Groups", new ContentLoUOfficial(this, new ContentLouGroups()));
            }
            if (lstSubItems.Items.Count > 0)
                lstSubItems.SelectedIndex = 0;

        }

        public void FillEmpire()
        {
            FillEmpire(true);
        }
        private void FillEmpire(bool remove)
        {
            lstSubItems.Items.Clear();
            if (remove)
            {
                string[] keys = new string[tabs.Keys.Count];
                tabs.Keys.CopyTo(keys, 0);
                foreach (string k in keys)
                    if (k.StartsWith(btnMenuEmpire.Name) && k != (btnMenuEmpire.Name + "_" + CONNECT))
                        tabs.Remove(k);
            }
            if (m_Session == null)
            {
                AddSubItem(btnMenuEmpire, CONNECT, new ContentLouConnection(this));
            }
            else
            {
                AddSubItem(btnMenuOfficial, m_Session.World.Player(m_Session.PlayerID).Name, new ContentLoUOfficial(this, new ContentLouMyPlayer(), Properties.Resources.menu_Empire));
                if (m_Session.AllianceID > 0)
                    AddSubItem(btnMenuOfficial, m_Session.World.Alliance(m_Session.AllianceID).Name, new ContentLoUOfficial(this, new ContentLouMyAlliance(), Properties.Resources.menu_Empire));
            }
            if (lstSubItems.Items.Count > 0)
                lstSubItems.SelectedIndex = 0;

        }
        private void AddSubItem(RadioButton btn, string name, UserControl defaultPanel)
        {
            string key = btn.Name + "_" + name;
            if (!tabs.ContainsKey(key))
                tabs.Add(key, new PanelEntry(name, defaultPanel));
            lstSubItems.Items.Add(tabs[key]);
        }

        private void lstSubItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubItems.SelectedIndex >= 0)
            {
                PanelEntry pe = (PanelEntry)lstSubItems.SelectedItem;
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(pe.SubPanel);
                pe.SubPanel.Dock = DockStyle.Fill;
                pe.SubPanel.BackColor = Color.White;
                pe.SubPanel.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "<")
            {
                splitContainer1.SplitterDistance -= 197;
                button1.Text = ">";
            }
            else
            {
                splitContainer1.SplitterDistance += 197;
                button1.Text = "<";
            }
        }
    }
}
