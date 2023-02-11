using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace AlphaverLauncherRecreation
{

    partial class SettingsForm : Form
    {

        Settings settings = new Settings();

        //gets launcher so we can update the "logged in as x" text
        Launcher launcher = Application.OpenForms.OfType<Launcher>().Single();

        public SettingsForm()
        {
            InitializeComponent();


            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            updateModsBox(versionBox.Text);



            //update boxes to reflect whats in settings.txt
            usernameBox.Text = settings.username;
            versionBox.Text = settings.version;
            minecraftPathBox.Text = settings.minecraftPath;
            argumentsBox.Text = settings.arguments;
            modBox.Text = settings.mod;
            javaPathBox.Text = settings.javaPath;



            string jsonString = JsonConvert.SerializeObject(settings);


        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(File.Open("settings.json", FileMode.Create));


            settings.username = usernameBox.Text;
            settings.version = versionBox.Text;
            settings.minecraftPath = minecraftPathBox.Text;
            settings.arguments = argumentsBox.Text;
            settings.mod = modBox.Text;
            settings.javaPath = javaPathBox.Text;

            writer.Write(JsonConvert.SerializeObject(settings));

            writer.Close();


            launcher.UpdateUsername(usernameBox.Text);
            this.Close();
        }

        private void versionBox_TextChanged(object sender, EventArgs e)
        {

            updateModsBox(versionBox.Text);

        }

        void updateModsBox(string version)
        {
            modBox.Items.Clear();
            modBox.Items.Add("vanilla");

            switch (version)
            {
                case "lilypad_qa":
                    //   modBox.Items.Add("afterglow");
                    modBox.Items.Add("rosepad");
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

    }





    public class Settings
    {
        public string username;
        public string version;
        public string minecraftPath;
        public string javaPath;
        public string arguments;
        public string mod;
        public Mod[] mods;

    }

    public class Mod
    {
        public string version;
        public string name;
    }
}
