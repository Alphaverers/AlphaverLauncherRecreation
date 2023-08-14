using AlphaverLauncherRecreation.forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlphaverLauncherRecreation
{

    partial class SettingsForm : Form
    {

        public Settings settings = new Settings();

        //gets launcher so we can update the "logged in as x" text
        Launcher launcher = Application.OpenForms.OfType<Launcher>().Single();
        bool isDebugMode = false;


        public SettingsForm()
        {
            InitializeComponent();

#if DEBUG
            isDebugMode = true;
#endif

            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            updateModsBox(versionBox.Text);



            //update boxes to reflect whats in settings.json
            usernameBox.Text = settings.username;
            versionBox.Text = settings.version;

            argumentsBox.Text = settings.arguments;
            modBox.Text = settings.mod;
            javaPathBox.Text = settings.javaPath;
            launchDelayBox.Text = settings.launchDelay.ToString();

            librariesPathBox.Text = settings.folderStructure.libraries;
            jarPathBox.Text = settings.folderStructure.jars;
            minecraftPathBox.Text = settings.folderStructure.gameDirectory;
            logsPathBox.Text = settings.folderStructure.logs;

            discordRPCCheckBox.Checked = settings.discordRPC;
            loadingCheckBox.Checked = settings.loadingBar;
            consoleCheckBox.Checked = settings.consoleWindow;

            string versionString = "V" + Program.version;
            if (isDebugMode) {
                Console.WriteLine(versionString);
                Console.WriteLine(isDebugMode);
                versionString += " Debug Build";
            }

            launcherVersionText.Text = versionString;

            string jsonString = JsonConvert.SerializeObject(settings);


        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(File.Open("settings.json", FileMode.Create));

            settings.launcherVersion = Program.version;
            settings.username = usernameBox.Text;
            settings.version = versionBox.Text;
            settings.launchDelay = Int32.Parse(launchDelayBox.Text);

            settings.arguments = argumentsBox.Text;
            settings.mod = modBox.Text;
            settings.javaPath = javaPathBox.Text;

            settings.discordRPC = discordRPCCheckBox.Checked;
            settings.loadingBar = loadingCheckBox.Checked;
            settings.consoleWindow = consoleCheckBox.Checked;

            settings.folderStructure.jars = jarPathBox.Text;
            settings.folderStructure.libraries = librariesPathBox.Text;
            settings.folderStructure.gameDirectory = minecraftPathBox.Text;
            settings.folderStructure.logs = logsPathBox.Text;


            writer.Write(JsonConvert.SerializeObject(settings));

            writer.Close();

            UpdateCreditText();
            launcher.UpdateUsername(usernameBox.Text);
            launcher.UpdateRPC("Version is set to " + settings.version, "Idle");

            this.Close();
        }

        private void versionBox_TextChanged(object sender, EventArgs e)
        {

            updateModsBox(versionBox.Text);

        }

        public void updateModsBox(string version)
        {
            modBox.Items.Clear();
            modBox.Items.Add("vanilla");

            switch (version)
            {
                case "lilypad_qa":
                    modBox.Items.Add("afterglow");
                    modBox.Items.Add("rosepad");
                    modBox.Items.Add("badblock");
                    modBox.Items.Add("lpuj");
                    break;
                case "":
                    break;

            }
            if (settings.mods != null)
            {
                foreach (Mod mod in settings.mods)
                {
                    if (mod.version == version) modBox.Items.Add(mod.name);

                }
            }


            modBox.Text = "vanilla";
        }

        private void loginTypeBox_TextChanged(object sender, EventArgs e)
        {
            usernameBox.Enabled = true;

        }

        private void modBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCreditText();
        }

        private void creditText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (modBox.Text)
            {
                case "rosepad":

                    System.Diagnostics.Process.Start("https://github.com/RosepadMC/Rosepad");
                    break;
                case "afterglow":
                    System.Diagnostics.Process.Start("https://github.com/AfterglowMC/AfterglowMC");
                    break;
                case "badblock":
                    System.Diagnostics.Process.Start("https://github.com/Alphaverers/BadBlock");
                    break;
                case "lpuj":
                    System.Diagnostics.Process.Start("https://github.com/AlphaVerUnofficialJars/LilypadClient");
                    break;

            }

        }

        private void UpdateCreditText()
        {
            if ((new[] { "rosepad", "badblock", "afterglow", "lpuj" }).Contains(modBox.Text, StringComparer.OrdinalIgnoreCase)) creditText.Show();
            switch (modBox.Text)
            {

                case "rosepad":
                    creditText.Text = "Rosepad github repository";
                    break;
                case "afterglow":
                    creditText.Text = "Afterglow github repository";
                    break;
                case "badblock":
                    creditText.Text = "Badblock github repository";
                    break;
                case "lpuj":
                    creditText.Text = "LilypadClient github repository";
                    break;

                case "vanilla":
                case null:
                case "":
                    creditText.Hide();
                    break;

            }

        }
        /// <summary>
        /// Opens a windows file dialog.
        /// </summary>
        /// <returns>File path</returns>
        string OpenFileDialog(string filter)
        {
            var filePath = string.Empty;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = filter;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
            }
            return filePath;
        }

        /// <summary>
        /// Opens a windows file dialog.
        /// </summary>
        /// <returns>Path</returns>
        string OpenBrowseFolderDialog()
        {
            var path = string.Empty;
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            }
            return path;
        }

        private void javaFileSelectButton_Click(object sender, EventArgs e)
        {
            javaPathBox.Text = OpenFileDialog("Java Binaries (*.jar)|");
        }

        private void minecraftPathSelectButton_Click(object sender, EventArgs e)
        {
            minecraftPathBox.Text = OpenBrowseFolderDialog();
        }

        private void githubRepoButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Alphaverers/AlphaverLauncherRecreation");
        }

        private void alphaverChannelButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@MinecraftAlphaVersions");
        }

        private void addModButton_Click(object sender, EventArgs e)
        {
            forms.ModAdder modAdder = new forms.ModAdder();
            modAdder.Show();

        }

        private void jarsPathSelectButton_Click(object sender, EventArgs e)
        {
            jarPathBox.Text = OpenBrowseFolderDialog();
        }

        private void librariesPathSelectButton_Click(object sender, EventArgs e)
        {
            librariesPathBox.Text = OpenBrowseFolderDialog();
        }

        private void keysButton_Click(object sender, EventArgs e)
        {
            forms.Keys keys = new forms.Keys();
            keys.Show();
        }

        private void replaceTerrainButton_Click(object sender, EventArgs e)
        {
            //string newTerrain = OpenFileDialog("PNG files (*.png)|");
            //ReplaceFileInJar("terrain.png", newTerrain);
        }
        private void replaceGuiButton_Click(object sender, EventArgs e)
        {
            //string newGui = OpenFileDialog("PNG files (*.png)|");
            //ReplaceFileInJar("gui/gui.png", newGui);
        }

        private void ReplaceFileInJar(string oldFile, string newFile)
        {
            string version;

            if (modBox.Text != "vanilla")
            {
                version = modBox.Text;
            }

            if (!File.Exists($"{settings.folderStructure.jars}/{settings.version}.jar"))
            {

                Thread t = launcher.DownloadVersion(settings.version, true);
                t.Start();
                t.Join();
            }

            string zipFilePath = $"{settings.folderStructure.jars}/{settings.version}.jar";


            // Create a temporary file for the new zip archive
            string tempFilePath = Path.GetTempFileName();

            try
            {
                using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
                {
                    // Find the existing entry to replace
                    ZipArchiveEntry entryToRemove = archive.GetEntry(oldFile);

                    // Remove the existing entry
                    entryToRemove.Delete();

                    // Add the new file with the same name
                    ZipArchiveEntry newEntry = archive.CreateEntryFromFile(newFile, oldFile);
                }
            }
            catch (Exception ex)
            {
                new Popup($"{ex.Data} Exception caught, please report this message to our github page", "", false, true, false).Show();
                Console.WriteLine(ex.Data + ":" + ex.Message);

            }

        }
        private void logsSelectButton_Click(object sender, EventArgs e)
        {
            logsPathBox.Text = OpenBrowseFolderDialog();
        }

        private void replaceItemsButton_Click(object sender, EventArgs e)
        {
            string newItems = OpenFileDialog("PNG files (*.png)|");
            ReplaceFileInJar("gui/items.png", newItems);
        }

        private void qakeygen_Click(object sender, EventArgs e)
        {
            var f = new AlphaverLauncherRecreation.forms.Keys();
            f.Show();
        }
    }





    public class Settings
    {
        public string launcherVersion;
        public string username;
        public string version;
        public string javaPath;
        public string arguments;
        public FolderStructure folderStructure = new FolderStructure();
        public string mod;
        public List<Mod> mods;
        public bool discordRPC;
        public bool loadingBar;
        public bool consoleWindow;
        public int launchDelay;
    }

    public class Mod
    {
        public string version;
        public string name;
    }
    public class FolderStructure
    {
        public string jars;
        public string libraries;
        public string gameDirectory;
        public string logs;

    }
}
