using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUCityInfo : AbstractLoadingTuple, IComparable<LoUCityInfo>
    {
        private readonly LoUPlayerInfo m_Player;
        private readonly LoUWorldInfo m_World;

        private readonly string m_Name;
        private readonly int m_Id;
        private readonly LoUBorderingType m_Bordering;
        private readonly OldLoUCityType m_TypeCity;
        private readonly LoUPt m_Location;

        private int m_Score;
        private int m_VirtueType;
        private int m_PalaceLvl;

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }
        public LoUBorderingType Bordering { get { return m_Bordering; } }
        public OldLoUCityType TypeCity { get { return m_TypeCity; } }
        public LoUPt Location { get { return m_Location; } }
        public LoUPlayerInfo Player { get { return m_Player; } }
        public int Score { get { return m_Score; } }
        public int VirtueType { get { return m_VirtueType; } }
        public int PalaceLvl { get { return m_PalaceLvl; } }

        public LoUCityInfo(LoUWorldInfo world, LoUPlayerInfo player, string name, int id, LoUPt location, LoUBorderingType bordering, OldLoUCityType type, int score)
            : base()
        {
            m_World = world;
            m_Player = player;
            m_Name = name;
            m_Id = id;
            m_Score = score;
            m_Bordering = bordering;
            m_TypeCity = type;
            m_Location = location;
        }
        protected override void OnLoad()
        {
            JsonObjectCollection city = LoUEndPoint.GetPublicCityInfo(m_World.Url, m_World.Session.SessionID, m_Id);
            if (m_TypeCity == OldLoUCityType.Palace)
            {
                m_VirtueType = (int)((JsonNumericValue)city["st"]).Value;
                m_PalaceLvl = (int)((JsonNumericValue)city["pl"]).Value;
            }
        }

        public override string ToString()
        {
            return m_Location.ToString() + "  " + m_Name + " (" + m_Score.ToString("N0") + ")";
        }

        #region IComparable<LoUCityInfo> Members

        public int CompareTo(LoUCityInfo other)
        {
            return m_Score.CompareTo(other.Score);
        }

        #endregion
    }
}
