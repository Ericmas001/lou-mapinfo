using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class PlayerExtendedInfo : PlayerInfo
    {

        public PlayerExtendedInfo(WorldInfo world, string name, int id, AllianceInfo alliance, int score, int rank, int nbCities)
            : base(world, name, id, alliance, score, rank, nbCities)
        {
        }
        protected override void OnLoad()
        {
            base.OnLoad();
        }
    }
}
