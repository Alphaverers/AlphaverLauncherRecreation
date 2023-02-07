using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Net;

namespace AlphaverLauncherRecreation
{
    public partial class Launcher : Form
    {

        List<string> settings;
        string defaultUsername = "Player";

        public Launcher()
        {
            InitializeComponent();
            //check if settings file exists if not create a settings.txt
            if (File.Exists("settings.txt"))
            {
                settings = File.ReadLines("settings.txt").ToList();
                UpdateUsername(settings[0]);
            }
            else
            {
                StreamWriter writer = new StreamWriter(File.Open("settings.txt", FileMode.Create));

                writer.Write($"{defaultUsername}\n\n./.minecraft");
                UpdateUsername(defaultUsername);
                writer.Close();
            }

           
        }


        //i have no idea how this library is used
        private async void playButton_ClickAsync(object sender, EventArgs e)
        {
            settings = File.ReadLines("settings.txt").ToList();
            if (settings[1] == "")
            {
                MessageBox.Show("Please set version.", "");
                return;
            }

            //download the version if it doesnt exist
            if (!Directory.Exists($"{settings[2]}/versions"))
            {
                MessageBox.Show("Downloading files...", "");
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://dl.dropbox.com/s/tat1zaxzvej4gu0/versions.zip", "versions.zip");     
                }
                System.IO.Compression.ZipFile.ExtractToDirectory("versions.zip", $"{settings[2]}/versions");
                File.Delete("versions.zip");
                MessageBox.Show("Launcher will now restart.", "");
              
                Application.Exit();
            }

            //open loader  so it looks cool
            var loader = new Loader();
            loader.Show();





            //set minecraft path to location in settings file
            var launcher = new CMLauncher(settings[2]);




            var launchOptions = new MLaunchOption
            {
                //gonna add this to settings
                MaximumRamMb = 1024,
                //set username
                Session = MSession.GetOfflineSession(settings[0])

            };

            var process = await launcher.CreateProcessAsync(settings[1], launchOptions);

            process.Start();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var settings = new Settings();
            settings.Show();
        }

        /// <summary>
        /// Updates the text on launcher.
        /// </summary>
        /// <param name="username"></param>
        public void UpdateUsername(string username)
        {
            logintext.Text = "Logged in as " + username;
        }

    }
}
