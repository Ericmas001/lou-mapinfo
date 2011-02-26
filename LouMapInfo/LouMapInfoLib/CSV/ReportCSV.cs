using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LouMapInfo.CSV
{
    public abstract class ReportCSV
    {
        bool m_Silent = true;
        protected virtual void LoadFiles()
        {
        }

        protected virtual void BuildData()
        {
        }

        protected virtual void WriteCSV(StreamWriter sw)
        {
        }

        public virtual string RawFile()
        {
            return "";
        }

        public void ProduceReport(string filename, bool silent)
        {
            m_Silent = silent;
            Log("Loading Entities ...", ConsoleColor.White);
            LoadFiles();
            LogLine(" done !", ConsoleColor.Green);
            LogLine("Building Data ...", ConsoleColor.White);
            BuildData();
            Log("Building  & Saving CSV file ...", ConsoleColor.White);
            StreamWriter sw = File.CreateText(filename);
            WriteCSV(sw);
            sw.Close();
            LogLine(" done !", ConsoleColor.Green);
        }
        protected void Log(string msg, ConsoleColor color)
        {
            if (!m_Silent)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(msg);
                Console.ForegroundColor = oldColor;
            }
        }
        protected void LogLine(string msg, ConsoleColor color)
        {
            if (!m_Silent)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
