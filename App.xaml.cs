using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;

namespace CIS.Born
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            sPathes = new List<string>();
            bDeleteCompilator = true;
            if (e.Args.Length == 0) return;
            else
            {
                bProgrammoid = true;
                for (int i = 0; i < e.Args.Length; i++)
                {
                    if (e.Args[i].StartsWith("/s:")) App.sPathes.Add(e.Args[i].Substring(3));
                    if (e.Args[i].StartsWith("/d")) bDeleteCompilator = true;
                }
            }
        }

        public static List<string> sPathes;
        public static List<string> sCode;
        public static bool bDeleteCompilator;
        public static bool bProgrammoid;
    }
}
