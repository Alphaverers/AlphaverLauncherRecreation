using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaverLauncherRecreation
{
    public partial class Popup : Form
    {
        public Popup(string text1,string text2,bool progressBar, bool button )
        {
            InitializeComponent();
            label1.Text = text1;
            label2.Text = text2;
            progressBar1.Visible = progressBar;
            button1.Visible = button;

        }

        private void loadingText_Click(object sender, EventArgs e)
        {

        }
    }
}
