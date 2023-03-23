using System;
using System.IO;
using System.Linq;

using System.Windows.Forms;

namespace AlphaverLauncherRecreation.forms
{
    public partial class ModAdder : Form
    {

        public string jarLocation;

        public ModAdder()
        {
            InitializeComponent();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = Application.OpenForms.OfType<SettingsForm>().Single();

            File.Copy(jarLocation, $"{settings.settings.folderStructure.jars}\\{nameBox.Text}.jar");

            Mod modToAdd = new Mod();
            modToAdd.version = versionBox.Text;
            modToAdd.name = nameBox.Text;
            settings.settings.mods.Add(modToAdd);
            settings.updateModsBox(versionBox.Name);
            this.Close();
            
        }

        private void selectJarButton_Click(object sender, EventArgs e)
        {
            jarLocation = OpenFileDialog("Minecraft Jar Files (*.jar)|");
        }


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
    }
}
