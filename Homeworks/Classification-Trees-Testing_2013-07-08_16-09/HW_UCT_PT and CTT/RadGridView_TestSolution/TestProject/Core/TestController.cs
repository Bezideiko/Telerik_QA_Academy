using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ArtOfTest.WebAii.Core;

namespace TestProject
{
	public static class TestController
	{
		public static void CleanUpTest()
		{
            foreach (var browser in Manager.Current.Browsers)
            {
                browser.Close();
            }
            Manager.Current.Dispose();
            KillAllZombieIEProcesses();
        }

        internal static void KillAllZombieIEProcesses()
        {
            Process[] ieProcesses = Process.GetProcessesByName("iexplore");
            foreach (Process ie in ieProcesses)
            {
                ie.Kill();
            }
        }
    }
}
