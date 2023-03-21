using CmlLib.Core;
using CmlLib.Core.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;

namespace AlphaverLauncherRecreation
{
    public partial class Launcher : Form
    {

        public Settings settings = new Settings();
        public DiscordRpcClient client;
        string defaultUsername = "Player";
        Popup downloadPopup = new Popup("Downloading..", "", true, false, false);
        string[] libraries = { "jinput.jar", "lwjgl.jar", "lwjgl_util.jar" };


        public Launcher()
        {

            InitializeComponent();

            //check if settings file exists if not create a settings.json
            if (!File.Exists("settings.json"))
            {
                settings.username = defaultUsername;
                settings.folderStructure.gameDirectory = "./.minecraft";
                settings.arguments = "-Xmx2G";
                settings.discordRPC = true;
                settings.loadingBar = true;
                settings.folderStructure.libraries = ".\\bin\\";
                settings.folderStructure.jars = "./jars";
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

            client = new DiscordRpcClient("1078921998094307348");
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

            if (File.Exists($"{settings.folderStructure.jars}/{version}.jar"))
            {

                UpdateRPC("Ingame", $"Playing {version}", Timestamps.Now);
                //open loader  so it looks cool
                if (settings.loadingBar) ShowLoadingBar(version);
                playButton.Text = "Launched";
               // playButton.Enabled = false;
                //  await LaunchGame(settings.username, version, settings.minecraftPath, settings.arguments, settings.javaPath);
                if (AreLibrariesInstalled(settings.folderStructure.libraries,libraries)) { BetterLaunch($"{settings.folderStructure.jars}/{version}.jar"); }
                else
                {
                    InstallLibraries();
                }
                  
            }
            else
            {



                Directory.CreateDirectory($"{settings.folderStructure.jars}");



                if (isItVanilla)
                {
                    Downloader($"{settings.folderStructure.jars}/{version}.jar", new Uri($"https://github.com/Gnawmon/AlphaverLauncherRecreation/raw/main/files/jars/{version}.jar")).Start();

                }
                else
                {
                    string latestBuildLink;
                    switch (version)
                    {
                        case "rosepad":
                            latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/rosepadmc/rosepad/releases");
                            Downloader($"{settings.folderStructure.jars}/rosepad.jar", new Uri(latestBuildLink)).Start();
                            break;
                        case "afterglow":
                            latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/AfterglowMC/AfterglowMC/releases");
                            Downloader($"{settings.folderStructure.jars}/afterglow.jar", new Uri(latestBuildLink)).Start();
                            break;
                        case "badblock":
                            latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/Alphaverers/Badblock/releases");
                            Downloader($"{settings.folderStructure.jars}/badblock.jar", new Uri(latestBuildLink)).Start();
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

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "java";
            startInfo.Arguments = "-Xms512m -Xmx1024m -Djava.library.path=\"./bin/natives\"-cp \"minecraft.jar\";\"./bin/jinput.jar\";\"./bin/lwjgl.jar\";\"./bin/lwjgl_util.jar\" net.minecraft.client.Minecraft  ";

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
            UpdateRPC("Version is set to " + version, "Idle");
            playButton.Text = "Launch";
            playButton.Enabled = true;
        }

        private static void ShowLoadingBar(string version)
        {
            var loader = new Loader();
            loader.Show();
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
            if (settings.discordRPC)
            {
                client = new DiscordRpcClient("1078921998094307348");

                //Set the logger
                client.OnReady += (sender, e) =>
                {
                    Console.WriteLine("Set presence for {0}", e.User.Username);
                };
                client.Initialize();

                //Set the rich presence
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
            else
            {
                client.Dispose();

            }
        }
        void UpdateRPC(string state, string details, Timestamps timeStamp)
        {
            if (settings.discordRPC)
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
            else
            {
                client.Dispose();

            }
        }

        public void UpdateRPC(string state, string details)
        {
            if (settings.discordRPC)
            {
                client.SetPresence(new RichPresence()
                {
                    State = state,
                    Details = details,
                    Assets = new Assets()
                    {
                        LargeImageKey = "alphaver",
                    }
                });
            }
            else
            {
                client.Dispose();

            }
        }
        void BetterLaunch(string version)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            process.StartInfo.FileName = settings.javaPath;

            process.StartInfo.Arguments = GenerateArguments("-Xms512m -Xmx1024m", "./bin/natives", version, libraries, "net.minecraft.client.Minecraft");


            Console.WriteLine($"{settings.javaPath} {process.StartInfo.Arguments}");
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.OutputDataReceived += WriteOutputToConsole;
            process.ErrorDataReceived += WriteOutputToConsole;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();


        }
        string GenerateArguments(string minecraftArguments, string natives, string jar, string[] libraries, string mainClass)
        {
            string libraryStrings = "";
            foreach (string lib in libraries)
            {

                libraryStrings += $"{settings.folderStructure.libraries}{lib};";

            }
            string arguments = $"{minecraftArguments} -Djava.library.path=\"{natives}\" -cp \"{jar}\";{libraryStrings} {mainClass} ";

            return arguments;
        }
        void InstallLibraries()
        {
            foreach (string lib in libraries)
            {
                if (!File.Exists($"{settings.folderStructure.libraries}{lib}"))
                {
                    Directory.CreateDirectory($"{settings.folderStructure.libraries}\\natives");

                    switch (lib)
                    {
                        case "lwjgl.jar":
                         
                            using (var client = new WebClient())
                            {
                        
                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl/2.9.0/lwjgl-2.9.0.jar", $"{settings.folderStructure.libraries}{lib}");
                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl-platform/2.9.0/lwjgl-platform-2.9.0-natives-windows.jar", "lwjglnatives.zip");

                            }

                            ZipFile.ExtractToDirectory("lwjglnatives.zip", $"{settings.folderStructure.libraries}\\natives");
                            break;
                        case "jinput.jar":
                            using (var client = new WebClient())
                            {
                                client.DownloadFile("https://libraries.minecraft.net/net/java/jinput/jinput-platform/2.0.5/jinput-platform-2.0.5-natives-windows.jar", $"{settings.folderStructure.libraries}{lib}");
                            }
                            break;
                        case "lwjgl_util.jar":
                            using (var client = new WebClient())
                            {
                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl_util/2.9.1-nightly-20130708-debug3/lwjgl_util-2.9.1-nightly-20130708-debug3.jar", $"{settings.folderStructure.libraries}{lib}");
                            }


                            break;
                    }
                    Console.WriteLine($"Downloading {lib}.");
                }
            }
        }
        bool AreLibrariesInstalled(string libfolder, string[] requiredLibraries)
        {
            foreach (string lib in requiredLibraries)
            {
                if (!File.Exists($"{settings.folderStructure.libraries}{lib}"))
                {
                return false;
                }
            }
            return true;
        }
    }
}