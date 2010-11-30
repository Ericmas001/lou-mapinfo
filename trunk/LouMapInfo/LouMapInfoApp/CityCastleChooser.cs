using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp
{
    public partial class CityCastleChooser : UserControl
    {
        public CityCastleType Value
        {
            get
            {
                if (!chkCity.Checked && chkCastles.Checked)
                    return CityCastleType.Castle;
                if (chkCity.Checked && !chkCastles.Checked)
                    return CityCastleType.City;
                if (chkCity.Checked && chkCastles.Checked)
                    return CityCastleType.Both;
                return CityCastleType.None;
            }
            set
            {
                chkCity.Checked = (value == CityCastleType.Both || value == CityCastleType.City);
                chkCastles.Checked = (value == CityCastleType.Both || value == CityCastleType.Castle);
            }
        }
        public bool City
        {
            get { return chkCity.Checked; }
            set { chkCity.Checked = value; }
        }
        public bool Castle
        {
            get { return chkCastles.Checked; }
            set { chkCastles.Checked = value; }
        }
        public CityCastleChooser()
        {
            InitializeComponent();
        }
    }
}
