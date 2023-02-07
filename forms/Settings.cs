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

namespace AlphaverLauncherRecreation
{
    public partial class Settings : Form
    {
        //gets launcher so we can update the "logged in as x" text
        Launcher launcher = Application.OpenForms.OfType<Launcher>().Single();

        public Settings()
        {
            InitializeComponent();
            
             List<string> lines = System.IO.File.ReadLines("settings.txt").ToList();

            //update boxes to reflect whats in settings.txt
            usernameBox.Text = lines[0];
            versionBox.Text = lines[1];
            minecraftLocationBox.Text = lines[2];
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(File.Open("settings.txt", FileMode.Create));

            writer.Write($"{usernameBox.Text}\n{versionBox.Text}\n{minecraftLocationBox.Text}");
       
            writer.Close();

            
            launcher.UpdateUsername(usernameBox.Text);
            this.Close();
        }
    }
}
