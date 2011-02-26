using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;
using System.Windows.Forms;

namespace LouMapInfoApp.LouOfficial
{
    public interface ILouContent : IContainerControl
    {
        LoUSessionInfo Session { get;}
        ContentLoUOfficial Frame { get; set; }
    }
}
