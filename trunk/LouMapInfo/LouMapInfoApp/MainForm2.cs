using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;

namespace LouMapInfoApp
{
    public partial class MainForm2 : Form
    {
        private Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public MainForm2()
        {
            InitializeComponent();
            continentView.Worlds = worlds;
            worldView.Worlds = worlds;
        }
    }
}
