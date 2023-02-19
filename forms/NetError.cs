using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlphaverLauncherRecreation
{
    public partial class NetError : Form
    {
        public NetError()
        {
            InitializeComponent();
            InitializeComponent();
            this.timer.Start();
            this.label1.Text = "test";
            this.label2.Text = "test";
            this.button1.Visible = true;
            this.progressBar1.Visible = false;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(10);
            if (this.progressBar1.Value == 100)
            {
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NetError_Load(object sender, EventArgs e)
        {

        }
    }
}
