using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.OfficialLOU
{
    public class AllianceInfo : AbstractLoadingTuple
    {
        private readonly string m_Name;
        private readonly int m_Id;

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }

        public AllianceInfo(string name, int id)
            : base()
        {
            m_Name = name;
            m_Id = id;
        }
        protected override void OnLoad()
        {

        }
    }
}
