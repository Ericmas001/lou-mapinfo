using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EricUtility;

namespace LouMapInfoApp
{
    static class Program
    {

        enum test
        {
            none = 0,
            a = 1,
            b = 2,
            c = 4
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
