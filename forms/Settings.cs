using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            discordRPCCheckBox.Checked = settings.discordRPC;
            loadingCheckBox.Checked = settings.loadingBar;
            consoleCheckBox.Checked = settings.consoleWindow;

            string versionString = "V" + Program.version.ToString();
            if (isDebugMode) versionString += " Debug Build";

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

            }

        }

        private void UpdateCreditText()
        {
            if ((new[] { "rosepad", "badblock", "afterglow" }).Contains(modBox.Text, StringComparer.OrdinalIgnoreCase)) creditText.Show();
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
            javaPathBox.Text = OpenFileDialog("Java Binaries (*.exe)|");
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
    }





    public class Settings
    {
        public int launcherVersion;
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

    }
}
