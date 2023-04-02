using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaverLauncherRecreation.forms
{
    public partial class Keys : Form
    {

 
        public Keys()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string username = userNameBox.Text;
            if(username == "")
            {
                return;
            }
            username.ToUpper();
            if(username.Length > 15)
            {
                return;
            }
      

            username = username.ToUpper();

           keyBox.Text = CreateKey(username);


        }
        private static string CreateKey(string username)
        {
            
            return "not implemented";
        }
    }
}
