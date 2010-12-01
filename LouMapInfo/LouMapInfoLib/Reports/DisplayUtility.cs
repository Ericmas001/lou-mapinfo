using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports
{
    public static class DisplayUtility
    {
        public static string Cont(int c)
        {
            return String.Format("C{0:00}", c);
        }
        public static string Score(int i)
        {
            string s = "[score]";
            s += (i > 10000 ? String.Format("{0:0,0,0,0,0}", i) : (i > 1000 ? String.Format("{0:0,0}", i) : "" + i));
            s += "[/score]";
            return s;
        }
    }
}
