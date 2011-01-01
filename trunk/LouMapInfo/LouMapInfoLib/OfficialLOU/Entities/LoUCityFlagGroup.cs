using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUCityFlagGroup
    {
        private LoUCityFlag flag = LoUCityFlag.None;

        public bool Allow(LoUCityFlag f)
        {
            return (flag & f) != 0;
        }

        public void SetFlag(LoUCityFlag f, bool value)
        {
            if (value)
                flag |= f;
            else
                flag &= ~f;
        }

        public LoUCityFlag Flag { get { return flag; } }
    }
}
