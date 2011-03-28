using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using System.Windows.Forms;

namespace LouMapInfoApp.LouOfficial
{
    public interface ILouContent : IContainerControl
    {
        SessionInfo Session { get;}
        ContentLoUOfficial Frame { get; set; }
    }
}
