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
using System.Collections.Generic;
using Microsoft.Win32;
using DiscordRPC.Logging;

namespace AlphaverLauncherRecreation
{
    public partial class Launcher : Form
    {

        public Settings settings = new Settings();
        public DiscordRpcClient client;
        string defaultUsername = "Player";
        Popup downloadPopup = new Popup("Downloading..", "", true, false, false);
        string[] libraries = { "jinput.jar", "lwjgl.jar", "lwjgl_util.jar" };
        Logger logger = new Logger();

        public Launcher()
        {

            InitializeComponent();

            //check if settings file exists if not create a settings.json
            if (!File.Exists("settings.json"))
            {
                settings.username = defaultUsername;
                settings.folderStructure.gameDirectory = ".\\";
                settings.arguments = "-Xmx2G";
                settings.discordRPC = true;
                settings.loadingBar = true;
                settings.consoleWindow = true;
                settings.folderStructure.libraries = ".\\bin";
                settings.folderStructure.jars = ".\\jars";
                settings.folderStructure.logs = ".\\logs";

                settings.launchDelay = 15;
                settings.mods = new List<Mod>();
                StreamWriter writer = new StreamWriter(File.Open("settings.json", FileMode.Create));
                writer.Write(JsonConvert.SerializeObject(settings));
                writer.Close();

            }

            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            DateTime now = DateTime.Now;
            logger.CreateNewLog($"{Path.GetFullPath(settings.folderStructure.logs)}\\{now.DayOfYear}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}-{now.Second}.txt");

            UpdateUsername(settings.username);
            if (!settings.consoleWindow) ConsoleExtension.Hide();

            //checks internet. copied from here lol https://gist.github.com/yemrekeskin/df052c9a464cb0c9a4e2
            //REMOVED due to some issues
            if (CheckInternetConnection())
                Console.WriteLine("Internet ok");
            else
            {
                Console.WriteLine("Opening internet error dialog");
                Popup popup = new Popup("Server connection failed", "Make sure you are connected to the internet, then try again.", false, true, true);
                popup.Show();
            }

            client = new DiscordRpcClient("1078921998094307348");
            if (settings.discordRPC) InitializeRPC(settings.version);


        }

        public static bool CheckInternetConnection()
        {
            try
            {
                return true;
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
                if (AreLibrariesInstalled(settings.folderStructure.libraries, libraries))
                {
                    UpdateRPC("Ingame", $"Playing {version}", Timestamps.Now);
                    if (settings.loadingBar)
                    {
                        ShowLoadingBar(version);
                        await Task.Delay(settings.launchDelay * 1000);
                    }
                    BetterLaunch(settings.username, settings.folderStructure.gameDirectory, $"{settings.folderStructure.jars}/{version}.jar", settings.arguments, settings.javaPath);
                }
                else
                {
                    Console.WriteLine("Downloading Libraries.");
                    logger.UpdateLog("Downloading Libraries.");
                    InstallLibraries();

                }

            }
            else
            {
                Thread t = DownloadVersion(version, isItVanilla);
                t.Start();
                t.Join();

                playButton.PerformClick();

            }



        }

        public Thread DownloadVersion(string version, bool isItVanilla)
        {
            Directory.CreateDirectory($"{settings.folderStructure.jars}");



            if (isItVanilla)
            {
                if (version=="ext1605_20")
                {
                    // we have to host the r4 jar on another file hosting service since it's larger than 100 mb
                    return Downloader($"{settings.folderStructure.jars}/{version}.jar", new Uri($"http://dl.dropboxusercontent.com/scl/fi/9wda9dh7y7wl84e0euf2c/ext1605_20.jar?rlkey=67ci8p8r7gu3ujdvzameecn98&dl=0"));
                }
                {
                    return Downloader($"{settings.folderStructure.jars}/{version}.jar", new Uri($"https://github.com/Gnawmon/AlphaverLauncherRecreation/raw/main/files/jars/{version}.jar"));
                }
            }
            else
            {
                string latestBuildLink;
                switch (version)
                {
                    case "rosepad":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/rosepadmc/rosepad/releases");
                        return Downloader($"{settings.folderStructure.jars}/rosepad.jar", new Uri(latestBuildLink));

                    case "afterglow":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/AfterglowMC/AfterglowMC-Legacy/releases");
                        return Downloader($"{settings.folderStructure.jars}/afterglow.jar", new Uri(latestBuildLink));

                    case "badblock":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/Alphaverers/Badblock/releases");
                        return Downloader($"{settings.folderStructure.jars}/badblock.jar", new Uri(latestBuildLink));

                    case "lpuj":
                        latestBuildLink = GetLatestGithubBuild("https://api.github.com/repos/AlphaVerUnofficialJars/LilypadClient/releases");
                        return Downloader($"{settings.folderStructure.jars}/lpuj.jar", new Uri(latestBuildLink));

                }
                return null;



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



        private static void ShowLoadingBar(string version)
        {
            var loader = new Loader();
            loader.Show();
        }

        void WriteOutputToConsole(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            logger.UpdateLog(e.Data);
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
                logger.UpdateLog("Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive);
                downloadPopup.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());

            });
        }
        void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                Console.WriteLine("Completed");
                logger.UpdateLog("Completed");

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
        /// //tf is this summary for its not like we are going to make a mod loader....actually lets make a mod loader
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
                    logger.UpdateLog($"Set presence for {0}");
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
        void BetterLaunch(string username, string gamePath, string version, string arguments, string javaExecutable)
        {
            if (javaExecutable == "" || javaExecutable == null) javaExecutable = "javaw";

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo.FileName = javaExecutable;

            process.StartInfo.UseShellExecute = false;
            Directory.CreateDirectory(gamePath + "\\.minecraft");
            process.StartInfo.EnvironmentVariables.Remove("APPDATA");
            process.StartInfo.EnvironmentVariables.Add("APPDATA", Path.GetFullPath(gamePath));
            process.StartInfo.WorkingDirectory = Path.GetFullPath(gamePath + "\\.minecraft");
            process.StartInfo.Arguments = GenerateArguments(Path.GetFullPath(settings.folderStructure.libraries), settings.username, Path.GetFullPath(".\\bin\\natives"), Path.GetFullPath(version), libraries, arguments, "net.minecraft.client.Minecraft");



            Console.WriteLine($"{javaExecutable} {process.StartInfo.Arguments}");
            logger.UpdateLog($"{javaExecutable} {process.StartInfo.Arguments}");
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += WriteOutputToConsole;
            process.ErrorDataReceived += WriteOutputToConsole;


            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();


        }
        string GenerateArguments(string libraryFolder, string username, string natives, string jar, string[] libraries, string additionalArguments, string mainClass)
        {
            string libraryStrings = "";
            foreach (string lib in libraries)
            {

                libraryStrings += $"{libraryFolder}\\{lib};";

            }
            string arguments = $"-Djava.library.path=\"{natives}\" -cp \"{jar}\";{libraryStrings} {additionalArguments} {mainClass} \"{username}\" ";

            return arguments;
        }
        void InstallLibraries()
        {
            Popup popup = new Popup("Downloading libraries", "Downloading libraries", true, false, false);
            popup.Show();
            foreach (string lib in libraries)
            {
                if (!File.Exists($"{settings.folderStructure.libraries}\\{lib}"))
                {
                    Directory.CreateDirectory($"{settings.folderStructure.libraries}\\natives");

                    switch (lib)
                    {
                        case "lwjgl.jar":

                            using (var client = new WebClient())
                            {

                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl/2.9.0/lwjgl-2.9.0.jar", $"{settings.folderStructure.libraries}\\{lib}");
                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl-platform/2.9.0/lwjgl-platform-2.9.0-natives-windows.jar", "lwjglnatives.zip");

                            }
                            Directory.Delete($"{settings.folderStructure.libraries}\\natives");
                            ZipFile.ExtractToDirectory("lwjglnatives.zip", $"{settings.folderStructure.libraries}\\natives");

                            break;
                        case "jinput.jar":
                            using (var client = new WebClient())
                            {
                                client.DownloadFile("https://libraries.minecraft.net/net/java/jinput/jinput-platform/2.0.5/jinput-platform-2.0.5-natives-windows.jar", $"{settings.folderStructure.libraries}\\{lib}");
                            }
                            break;
                        case "lwjgl_util.jar":
                            using (var client = new WebClient())
                            {
                                client.DownloadFile("https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl_util/2.9.1-nightly-20130708-debug3/lwjgl_util-2.9.1-nightly-20130708-debug3.jar", $"{settings.folderStructure.libraries}\\{lib}");
                            }


                            break;
                    }
                    Console.WriteLine($"Downloading {lib}.");
                    logger.UpdateLog($"Downloading {lib}.");
                }
            }
            Console.WriteLine("Installed all required libraries.");
            logger.UpdateLog("Installed all required libraries.");
            playButton.PerformClick();
            ;
        }
        bool AreLibrariesInstalled(string libfolder, string[] requiredLibraries)
        {
            foreach (string lib in requiredLibraries)
            {
                if (!File.Exists($"{settings.folderStructure.libraries}\\{lib}"))
                {

                    return false;
                }
            }
            return true;
        }
    }

}