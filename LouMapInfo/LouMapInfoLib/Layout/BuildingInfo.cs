using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Layout
{
    public class BuildingInfo
    {
        private BuildingType m_BType;

        public BuildingType BType
        {
            get { return m_BType; }
            set { m_BType = value; }
        }
        private String m_Name;

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private char m_LetterFlashPlanner;

        public char LetterFlashPlanner
        {
            get { return m_LetterFlashPlanner; }
            set { m_LetterFlashPlanner = value; }
        }
        private char m_LetterShareString;

        public char LetterShareString
        {
            get { return m_LetterShareString; }
            set { m_LetterShareString = value; }
        }
        public BuildingInfo(BuildingType t, string n, char lfcp, char lss)
        {
            m_BType = t;
            m_Name = n;
            m_LetterFlashPlanner = lfcp;
            m_LetterShareString = lss;
            
        }


        /* **************************************
         * 
         * 
         *      S T A T I C 
         *      
         * 
         * *************************************/

        private static bool m_Loaded = false;
        private static List<BuildingInfo> m_AllOfThem = new List<BuildingInfo>();
        private static Dictionary<BuildingType, BuildingInfo> m_ByType = new Dictionary<BuildingType, BuildingInfo>();
        private static Dictionary<char, BuildingInfo> m_ByLetterFlashPlanner = new Dictionary<char, BuildingInfo>();
        private static Dictionary<char, BuildingInfo> m_ByLetterShareString = new Dictionary<char, BuildingInfo>();

        public static Dictionary<BuildingType, BuildingInfo> ByType
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return BuildingInfo.m_ByType;
            }
        }
        public static Dictionary<char, BuildingInfo> ByLetterFlashPlanner
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return BuildingInfo.m_ByLetterFlashPlanner;
            }
        }
        public static Dictionary<char, BuildingInfo> ByLetterShareString
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return BuildingInfo.m_ByLetterShareString;
            }
        }
        private static void Load()
        {
            m_Loaded = true;
            m_AllOfThem.Add(new BuildingInfo(BuildingType.None, "Destroy", '0', '-'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.ResWood, "Wood", 'A', '.'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.ResStone, "Stone", 'B', ':'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.ResIron, "Iron", 'C', ','));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.ResFood, "Food", 'D', ';'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.WoodcutterOld, "Woodcutter's hut (old)", 'F', 'W'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.QuarryOld, "Quarry (old)", 'G', 'Q'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.IronMineOld, "Iron Mine (old)", 'H', 'I'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.FarmOld, "Farm (old)", 'I', 'F'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Woodcutter, "Woodcutter's hut", '2', '2'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Quarry, "Quarry", '3', '3'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.IronMine, "Iron Mine", '4', '4'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Farm, "Farm", '5', '1'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Sawmill, "Sawmill", 'K', 'L'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Stonemasson, "Stonemasson", 'L', 'A'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Foundry, "Foundry", 'M', 'D'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Mill, "Mill", 'N', 'M'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Warehouse, "Warehouse", 'Z', 'S'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Cottage, "Cottage", 'O', 'C'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Hideout, "Hideout", '1', 'H'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Marketplace, "Marketplace", 'J', 'P'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Townhouse, "Townhouse", 'E', 'U'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Barracks, "Barracks", 'P', 'B'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.CityGuardHouse, "CityGuardHouse", 'S', 'K'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.TrainingGround, "Training Ground", 'Q', 'G'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Stable, "Stable", 'U', 'E'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.MoonglowTower, "Moonglow Tower", 'R', 'J'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.TrinsicTemple, "Trinsic Temple", 'W', 'Z'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Workshop, "Workshop", 'V', 'Y'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Harbor, "Harbor", 'T', 'R'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Shipyard, "Shipyard", 'Y', 'V'));
            m_AllOfThem.Add(new BuildingInfo(BuildingType.Castle, "Castle", 'X', 'X'));
            foreach (BuildingInfo bi in m_AllOfThem)
            {
                m_ByType.Add(bi.BType, bi);
                m_ByLetterFlashPlanner.Add(bi.LetterFlashPlanner, bi);
                m_ByLetterShareString.Add(bi.LetterShareString, bi);
            }
        }
        

    }
}
