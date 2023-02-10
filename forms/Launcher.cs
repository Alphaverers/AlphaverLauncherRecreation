using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Net;
using CmlLib.Core.Version;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaverLauncherRecreation
{
    public partial class Launcher : Form
    {

        Settings settings = new Settings();
        string defaultUsername = "Player";
        Popup downloadPopup = new Popup("Downloading..", "", true, false);
        public Launcher()
        {
            InitializeComponent();
           
            //check if settings file exists if not create a settings.txt
            if (File.Exists("settings.json"))
            {
                settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));
                UpdateUsername(settings.username);
            }
            else
            {
                Settings defaultSettings = new Settings();

               
                defaultSettings.username = defaultUsername;
                defaultSettings.minecraftPath = "./.minecraft";
                defaultSettings.arguments = "-Xmx2G";

                StreamWriter writer = new StreamWriter(File.Open("settings.json", FileMode.Create));
                writer.Write(JsonConvert.SerializeObject(defaultSettings));
                writer.Close();
                UpdateUsername(defaultUsername);
                
            }

           
        }


        private async void playButton_ClickAsync(object sender, EventArgs e)
        {
            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));
      
            if (settings.version == null)
            {
                MessageBox.Show("Please set version.", "");
                return;
            }
            string version = settings.version;
            if (settings.mods != "vanilla")
            {
                version = settings.mods;
            }
      
            if (Directory.Exists($"{settings.minecraftPath}/versions"))
            {
                await LaunchGame(settings.username, version, settings.minecraftPath, settings.arguments, settings.javaPath);
            }
            else
            {

                DownloadVersions();
            }

          

        }

        private async Task LaunchGame(string username, string version, string gamePath, string javaArguments, string javaPath)
        {
            //open loader  so it looks cool
            var loader = new Loader();
            loader.Show();
            Console.WriteLine($"Launching {version}.");

            //set minecraft path to location in settings file
            var launcher = new CMLauncher(gamePath);


            string[] arguments = { javaArguments };



            var launchOptions = new MLaunchOption
            {
                Session = MSession.GetOfflineSession(username),
                JavaPath = javaPath,
                JVMArguments = arguments

            };

            var process = await launcher.CreateProcessAsync(version, launchOptions);                             


           

            process.Start();



            process.WaitForExit();
        }

        private void DownloadVersions()
        {
        
            downloadPopup.Show();

            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
                client.DownloadFileAsync(new Uri("https://dl.dropbox.com/s/tat1zaxzvej4gu0/versions.zip"), "versions.zip");
            });
            thread.Start();

       
            
        }

        //i stole these from stackoverflow lol
        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
                                                                 
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                Console.WriteLine( "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive);
            downloadPopup.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
      
            });
        }
        void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
               Console.WriteLine("Completed");

                System.IO.Compression.ZipFile.ExtractToDirectory("versions.zip", $"{settings.minecraftPath}/versions");
                File.Delete("versions.zip");
                downloadPopup.Close();
            });


        }


        private void settingsButton_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
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

        private void logintext_Click(object sender, EventArgs e)
        {
            var popUp = new Popup("hello there","", true,false );
            popUp.Show();
        }


    }
}
