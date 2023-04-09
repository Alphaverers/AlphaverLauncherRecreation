using AlphaverLauncherRecreation.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaverLauncherRecreation
{
    internal class Logger
    {
        string logFileName;

        public void CreateNewLog(string name)
        {
            logFileName = name;
            if (!Directory.Exists(Path.GetDirectoryName(name))) Directory.CreateDirectory(Path.GetDirectoryName(name));
            using (StreamWriter log = new StreamWriter(logFileName))
            {
                log.WriteLine("Log Start");
                log.WriteLine($"Launcher version: v{Program.version}, OS Version: {Environment.OSVersion}");
                log.Close();
            }

        }

        public void UpdateLog(string logText)
        {


            try
            {
                using (StreamWriter log = new StreamWriter(logFileName, true))
                {
                    log.WriteLine(logText);
                    log.Close();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
