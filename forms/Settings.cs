using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
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
            
            updateModsBox(versionBox.Text);
            
            settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));

            


            //update boxes to reflect whats in settings.txt
            usernameBox.Text = settings.username;
            versionBox.Text = settings.version;
            minecraftPathBox.Text = settings.minecraftPath;
            argumentsBox.Text = settings.arguments;
            modsBox.Text = settings.mods;
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
            settings.mods = modsBox.Text;
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
            modsBox.Items.Clear();
            modsBox.Items.Add("vanilla");
            if (version == "lilypad_qa")
            {
               
                modsBox.Items.Add("afterglow");
               
            }
            modsBox.Text = "vanilla";
        }

    }

    public class Settings
    {
        public string username;
        public string version;
        public string minecraftPath;
        public string javaPath;
        public string arguments;
        public string mods;
    }
}
