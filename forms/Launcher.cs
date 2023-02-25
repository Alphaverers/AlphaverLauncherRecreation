using CmlLib.Core;
using CmlLib.Core.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;

namespace AlphaverLauncherRecreation
{
    public partial class Launcher : Form
    {

        Settings settings = new Settings();
        string defaultUsername = "Player";
        Popup downloadPopup = new Popup("Downloading..", "", true, false, false);
        public DiscordRpcClient client;


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


            //checks internet. copied from here lol https://gist.github.com/yemrekeskin/df052c9a464cb0c9a4e2
            if (CheckInternetConnection())
                Console.WriteLine("Internet ok");
            else
            {
                Console.WriteLine("Opening internet error dialog");
                Popup popup = new Popup("Server connection failed", "Make sure you are connected to the internet, then try again.", false, true, true);
                popup.Show();
            }

            InitializeRPC(settings.version);
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
            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            string version = settings.version;

            bool isItVanilla = settings.mod == "vanilla";



            if (settings.version == "" || settings.version == null)
            {
                Popup popup = new Popup("", "Please set version", false, true, false);
                popup.Show();
                return;
            }
            if (!CheckInternetConnection())
            {
                Popup popup = new Popup("Server connection failed", "Make sure you are connected to the internet, then try again.", false, true, true);
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

                UpdateRPC("Ingame", $"Playing {version}", Timestamps.Now);
                await LaunchGame(settings.username, version, settings.minecraftPath, settings.arguments, settings.javaPath);
            }
            else
            {



                Directory.CreateDirectory($"{settings.minecraftPath}/versions/{version}");
                string jsonFile = $"{settings.minecraftPath}/versions/{version}/{version}.json";

                //it copies default version json file to jars directory
                if (!File.Exists(jsonFile))
                {
                    CreateJsonFile(version, jsonFile);
                }


                if (isItVanilla)
                {
                    Downloader($"{settings.minecraftPath}/versions/{version}/{version}.jar", new Uri($"https://github.com/Gnawmon/AlphaverLauncherRecreation/raw/main/files/jars/{version}.jar")).Start();

                }
                else
                {
                    string latestBuildLink;
                    switch (version)
                    {
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



        }

        private static void CreateJsonFile(string version, string jsonFile)
        {
            File.Copy("default.json", jsonFile);
            File.WriteAllText(jsonFile, File.ReadAllText(jsonFile).Replace("versionname", version));
            Console.WriteLine("Created json file.");
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

            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.OutputDataReceived += WriteOutputToConsole;
            process.ErrorDataReceived += WriteOutputToConsole;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();






            process.WaitForExit();
            client.Dispose();
            InitializeRPC(version);
        }

        void WriteOutputToConsole(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
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

       public void InitializeRPC(string version)
        {
            /*
            Create a Discord client
            NOTE:   If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("1078921998094307348");

            //Set the logger


            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Set presence for {0}", e.User.Username);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                State = "Version is set to " + version,
                Details = "Idle",
                Assets = new Assets()
                {
                    LargeImageKey = "alphaver",
                }
            });
        }
        void UpdateRPC(string state, string details, Timestamps timeStamp)
        {
            client.SetPresence(new RichPresence()
            {
                State = state,
                Details = details,
                Timestamps = timeStamp,
                Assets = new Assets()
                {
                    LargeImageKey = "alphaver",
                }
            });
        }


    }
}