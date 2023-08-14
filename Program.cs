using System;
using System.Windows.Forms;

namespace AlphaverLauncherRecreation
{
    internal static class Program
    {
        public static string version = "4-rc1";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());

        }
    }

}
