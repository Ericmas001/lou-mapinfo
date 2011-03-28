using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class CityInfo : AbstractLoadingTuple, IComparable<CityInfo>
    {
        private readonly PlayerInfo m_Player;
        private readonly WorldInfo m_World;

        private string m_Name;
        private readonly int m_Id;
        private readonly BorderingType m_Bordering;
        private readonly CityType m_TypeCity;
        private readonly Pt m_Location;

        private int m_Score;
        private VirtueType m_VirtueType;
        private int m_PalaceLvl;

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }
        public BorderingType Bordering { get { return m_Bordering; } }
        public CityType TypeCity { get { return m_TypeCity; } }
        public Pt Location { get { return m_Location; } }
        public PlayerInfo Player { get { return m_Player; } }
        public int Score { get { return m_Score; } }
        public VirtueType VirtueType { get { return m_VirtueType; } }
        public int PalaceLvl { get { return m_PalaceLvl; } }

        public CityInfo(WorldInfo world, PlayerInfo player, string name, int id, Pt location, BorderingType bordering, CityType type, int score)
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
            JsonObjectCollection city = EndPoint.GetPublicCityInfo(m_World.Url, m_World.Session.SessionID, m_Id);
            if (m_TypeCity == CityType.Palace)
            {
                m_VirtueType = (VirtueType)((JsonNumericValue)city["st"]).Value;
                m_PalaceLvl = (int)((JsonNumericValue)city["pl"]).Value;
            }
        }

        public override string ToString()
        {
            return m_Location.ToString() + "  " + m_Name + " (" + m_Score.ToString("N0") + ")";
        }

        public void Rename(string newName)
        {
            m_Name = newName;
            EndPoint.RenameCity(Player.Alliance.World.Url, Player.Alliance.World.Session.SessionID, Id, newName);
        }

        public void SetCityNote(string title, string text)
        {
            EndPoint.CityNoteSet(Player.Alliance.World.Url, Player.Alliance.World.Session.SessionID, Id, title,text);
        }

        public KeyValuePair<string,string> GetCityNote()
        {
            JsonObjectCollection joc = EndPoint.GetCityInfo(Player.Alliance.World.Url, Player.Alliance.World.Session.SessionID, Id);
            string title = ((JsonStringValue)joc["nr"]).Value;
            string text = ((JsonStringValue)joc["ns"]).Value;
            return new KeyValuePair<string, string>(title,text);
        }

        #region IComparable<LoUCityInfo> Members

        public int CompareTo(CityInfo other)
        {
            return m_Score.CompareTo(other.Score);
        }

        #endregion
    }
}
