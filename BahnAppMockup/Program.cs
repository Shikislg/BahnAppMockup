using BahnAppMockup.API.Functions;
using BahnAppMockup.API.Interfaces;
using BahnAppMockup.API.Services;
using BahnAppMockup.Logic;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahnAppMockup
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(BahnAppMockup.Main.GetInstance());//Switched from Form1 to Main

        }    
    }
}
