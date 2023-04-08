using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private static string CreateKey(string name)
        {
            int[] endBytes = { 39, 86, 26, 72, 13, 91, 23 };
            name = name.ToUpper();
            string encName = "";
            int writtenBytes = 0;
            for (int i = 0; i < name.Length; i++)
            {
                encName += (70 - (26 - (name[i] - 'A'))).ToString();
                writtenBytes++;
            }
            encName += endBytes[new Random().Next(endBytes.Length)].ToString(); ;
            writtenBytes++;
            
            
            Console.WriteLine("Encoded name as: "+ encName);

            string fullNameString = encName;

            while(writtenBytes != 15)
            {
                fullNameString += (10 + (int)Math.Floor(new Random().NextDouble() * 89)).ToString();
                writtenBytes++;
            }
            var checksumFullName = 0;
            for (var i = 0; i < fullNameString.Length; i++)
            {
                checksumFullName += (fullNameString[i] - "0"[0]);
            }
            var checksumName = 0;
            for (var i = 0; i < encName.Length; i++)
            {
                checksumName += (encName[i] - "0"[0]);
            }
            checksumName %= 100;

            Console.WriteLine("checksum of full name: " + checksumFullName);
            int checkSumPart1 = checksumFullName + (4565465 * (999 - checksumFullName));
            var checkSumPart2 = checkSumPart1 - checksumFullName;


            string retStr = "";
            retStr += ("000" + checkSumPart1.ToString()).Substring(Math.Max(("000" + checkSumPart1.ToString()).Length - 3, 0));
            char[] fullNameArr = fullNameString.ToCharArray();
            Array.Reverse(fullNameArr);
            retStr += new string(fullNameArr);
            retStr += ("000" + checkSumPart2.ToString()).Substring(Math.Max(("000" + checkSumPart2.ToString()).Length - 3, 0));
            retStr += ("00" + checksumName.ToString()).Substring(Math.Max(("00" + checksumName.ToString()).Length - 2, 0));


            retStr = retStr.Insert(6, "-");
            retStr = retStr.Insert(15, "-");
            retStr = retStr.Insert(23, "-");
            retStr = retStr.Insert(31, "-");
            retStr = retStr.Insert(36, "-");

            return retStr;
        }
    }
}
