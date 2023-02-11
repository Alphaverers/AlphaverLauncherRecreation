using System;
using System.Windows.Forms;

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
            if (this.progressBar.Value == 100)
            {
                this.Close();
            }

        }


    }
}
