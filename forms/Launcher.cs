using CmlLib.Core;
using CmlLib.Core.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


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

            //check if settings file exists if not create a settings.json
            if (!File.Exists("settings.json"))
            {
                settings.username = defaultUsername;
                settings.minecraftPath = "./.minecraft";
                settings.arguments = "-Xmx2G";
                StreamWriter writer = new StreamWriter(File.Open("settings.json", FileMode.Create));
                writer.Write(JsonConvert.SerializeObject(settings));
                writer.Close();

            }

            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));
            UpdateUsername(settings.username);





        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        private async void playButton_ClickAsync(object sender, EventArgs e)
        {
            string version = settings.version;

            bool isItVanilla = settings.mod == "vanilla";

            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            if (settings.version == "" || settings.version == null)
            {
                Popup popup = new Popup("", "Please set version", false, true);
                popup.Show();
                return;
            }


            //if its not vanilla change which jar to launch
            if (!isItVanilla)
            {
                version = settings.mod;
            }

            if (File.Exists($"{settings.minecraftPath}/versions/{version}/{version}.jar") && File.Exists($"{settings.minecraftPath}/versions/{version}/{version}.json"))
            {
                await LaunchGame(settings.username, version, settings.minecraftPath, settings.arguments, settings.javaPath);
            }
            else
            {
                
                if (!isItVanilla)
                {
                   
                    Directory.CreateDirectory($"{settings.minecraftPath}/versions/{version}");
                    string jsonFile = $"{settings.minecraftPath}/versions/{version}/{version}.json";

                    //it copies default version json file to jars directory 
                    if (!File.Exists(jsonFile))
                    {

                        File.Copy("default.json", jsonFile);
                        File.WriteAllText(jsonFile, File.ReadAllText(jsonFile).Replace("versionname", version));
                        Console.WriteLine("Created json file.");
                    }


                }
                string latestBuildLink;
                switch (version)
                {

                    case "lilypad_qa":
                    case "v1605_preview":
                    case "v1605_unrpreview2":
                        Downloader("versions.zip", new Uri("https://github.com/Gnawmon/AlphaverLauncherRecreation/raw/main/files/versions.zip")).Start();
                        break;


                    case "rosepad":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/rosepadmc/rosepad/releases");
                        Downloader($"{settings.minecraftPath}/versions/rosepad/rosepad.jar", new Uri(latestBuildLink)).Start();
                        break;
                    case "afterglow":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/AfterglowMC/AfterglowMC/releases");


                        Downloader($"{settings.minecraftPath}/versions/afterglow/afterglow.jar", new Uri(latestBuildLink)).Start();

                        break;

                }

            }



        }

        private static string GetLatestGithubBuild(string apiReleasesLink)
        {
            WebClient client = new WebClient();
            //set the user agent so github doesnt return 403
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5393.187 Safari/537.36");
            var json = client.DownloadString(apiReleasesLink);
            JArray o = JArray.Parse(json);
            //get latest build
            string link = (string)o.SelectToken("[0].assets[0].browser_download_url").ToString();
            return link;
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

        private Thread Downloader(string filename, Uri link)
        {

            downloadPopup.Show();

            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
                client.DownloadFileAsync(link, filename);
            });
            return thread;



        }

        //i stole these from stackoverflow lol
        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                Console.WriteLine("Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive);
                downloadPopup.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());

            });
        }
        void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                Console.WriteLine("Completed");
                if (File.Exists("versions.zip"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory("versions.zip", $"{settings.minecraftPath}/versions");
                    File.Delete("versions.zip");
                }

                downloadPopup.Hide();

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




    }
}
