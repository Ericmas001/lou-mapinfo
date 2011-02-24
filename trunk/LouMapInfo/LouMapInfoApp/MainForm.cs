using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using EricUtility.Windows.Forms;
using System.IO;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfoApp
{
    public partial class MainForm : Form
    {
        private LoUSessionInfo m_Session = null;
        private Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public MainForm()
        {
            InitializeComponent();
            CustomTabControl tctl = new CustomTabControl();
            tctl.Controls.Add(this.tpageLive);
            tctl.Controls.Add(this.tpageContinent);
            tctl.Controls.Add(this.tpageWorld);
            tctl.DisplayStyle = EricUtility.Windows.Forms.TabStyle.Chrome;
            // 
            tctl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            tctl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            tctl.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.White;
            tctl.DisplayStyleProvider.FocusTrack = false;
            tctl.DisplayStyleProvider.HotTrack = true;
            tctl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tctl.DisplayStyleProvider.Opacity = 1F;
            tctl.DisplayStyleProvider.Overlap = 16;
            tctl.DisplayStyleProvider.Padding = new System.Drawing.Point(15, 5);
            tctl.DisplayStyleProvider.Radius = 16;
            tctl.DisplayStyleProvider.ShowTabCloser = false;
            tctl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            tctl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            tctl.Dock = System.Windows.Forms.DockStyle.Fill;
            tctl.HotTrack = true;
            tctl.Location = new System.Drawing.Point(0, 0);
            tctl.Name = "tctl";
            tctl.SelectedIndex = 0;
            tctl.Size = new System.Drawing.Size(707, 468);
            tctl.TabIndex = 0;
            panel1.Controls.Remove(tabControl1);
            panel1.Controls.Add(tctl);

            continentView.Worlds = worlds;
            worldView.Worlds = worlds;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string title = "LoU Map Info 3.1";
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            sw.WriteLine(title);
            sw.WriteLine("http://code.google.com/p/lou-mapinfo/");
            sw.WriteLine();
            sw.WriteLine("Made by Eric (ericmas001@hotmail.com)");
            sw.WriteLine("2010-2011");
            sw.WriteLine();
            sw.WriteLine("Lord of Ultima http://www.lordofultima.com");
            sw.WriteLine("Created by Dirnahm for:");
            sw.WriteLine("  - Nighthawks on World 10");
            sw.WriteLine("  - Shadow_Warriors on World 21");
            sw.WriteLine();
            sw.WriteLine("Special thanks to lou-map  http://www.lou-map.com/");
            sw.WriteLine("Their JSONs were more than useful");
            sw.WriteLine();
            sw.WriteLine("Special thanks to LoU Empire overview http://empire.lou-tools.com/");
            sw.WriteLine("Their clean code was a big reference !");
            MessageBox.Show(sb.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            sw.WriteLine("Q: Should I be worried about giving my e-mail and password ?");
            sw.WriteLine("A: Well, you should always verify where you write those things. In this case, you can read the open-source code and see for yourself that I only use it to retrieve a sessionId.");
            sw.WriteLine();

            sw.WriteLine("Q: Why the animated loading image is going counter-clockwise ? It's driving me crazy !");
            sw.WriteLine("A: It's killing me too, but I made this image a while ago and too lazy to do it again :)");
            sw.WriteLine();

            MessageBox.Show(sb.ToString(), "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
        }
    }
}
