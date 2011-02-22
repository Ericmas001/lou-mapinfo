using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp.V4
{
    public class PanelEntry
    {
        private string m_Name;
        private UserControl m_SubPanel;

        public string Name { get { return m_Name; } }
        public UserControl SubPanel { get { return m_SubPanel; } }

        public PanelEntry(string name, UserControl subPanel)
        {
            m_Name = name;
            m_SubPanel = subPanel;
        }
        public override string ToString()
        {
            return m_Name;
        }
    }
}
