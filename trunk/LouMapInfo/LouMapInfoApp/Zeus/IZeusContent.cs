using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using System.Windows.Forms;
using LouMapInfo.Zeus;

namespace LouMapInfoApp.Zeus
{
    public interface IZeusContent : IContainerControl
    {
        ZeusSessionInfo Session { get; }
        ContentZeus Frame { get; set; }
    }
}
