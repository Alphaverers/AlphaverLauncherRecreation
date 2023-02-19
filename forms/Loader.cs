using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlphaverLauncherRecreation
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            this.timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar.Increment(1);
            //we have not seen this one in the video, this is just speculation
            if (this.progressBar.Value == 20)
            {
                this.loadingText.Text = "Loading libraries...";
            }
            //we have seen these :)
            if (this.progressBar.Value == 65)
            {
                this.loadingText.Text = "Checking system compability...";
            }
            if (this.progressBar.Value == 75)
            {
                this.loadingText.Text = "Checking unique signatures...";
            }
            if (this.progressBar.Value == 85)
            {
                this.loadingText.Text = "Updating suspension list...";
            }
            if (this.progressBar.Value == 90)
            {
                this.loadingText.Text = "Launching game...";
            }

            if (this.progressBar.Value == 100)
            {
                this.Close();
            }

        }
    }
}
