using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfoApp.V4.Tools;
using LouMapInfoApp.V4.LouMap;
using LouMapInfo.Entities;

namespace LouMapInfoApp.V4
{
    public partial class MainForm : Form
    {
        private Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public Dictionary<string, PanelEntry> tabs = new Dictionary<string, PanelEntry>();
        public MainForm()
        {
            InitializeComponent();
            menuButton_CheckedChanged(btnMenuOfficial, new EventArgs());
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
                        c.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Bottom);
                    }
                    else if (c.Top <= buttonY && c.Top > lstOldY)
                    {
                        c.Location = new Point(c.Left, c.Top - lstSubItems.Height);
                        c.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top);
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

            }
            else if (btn == btnMenuZeus)
            {

            }
            else if (btn == btnMenuMap)
            {
                AddSubItem(btn, "Continent View", new ContentLMContinent(worlds));
                AddSubItem(btn, "World View", new ContentLMWorld(worlds));
            }
            else if (btn == btnMenuTools)
            {
                AddSubItem(btn, "About", new ContentAbout());
                AddSubItem(btn, "FAQ", new ContentFAQ());
            }
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
    }
}
