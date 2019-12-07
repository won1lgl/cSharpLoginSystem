using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace loginSystem
{
    public partial class mainForm : Form
    {
        private const string userInfoFilePath = @"C:\Users\21921\Desktop\new.txt";
        private const string userPicturePath = @"C:\Users\21921\Desktop\new.bin";

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loadUserInfo();
        }

        private void loadUserInfo()
        {
            StreamReader sr = null;
            sr = File.OpenText(userInfoFilePath);
            while (sr.Peek() != -1)
            {
                string userInfoText = sr.ReadLine();
                string[] userInfoTextArray = System.Text.RegularExpressions.Regex.Split(userInfoText, @"\s{1,}");
                if (userInfoTextArray[0] == "@username")
                {
                    userNameLabel.Text = userInfoTextArray[1];
                }
                if (userInfoTextArray[0] == "@uid")
                {
                    userIdLabel.Text += userInfoTextArray[1];
                }


            }
            sr.Close();
            //load the image

            FileStream fs = new FileStream(userPicturePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int length = Convert.ToInt32(br.BaseStream.Length);
            byte[] userPicturebytes = br.ReadBytes(length);
            br.Close();
            fs.Close();
            MemoryStream ms = new MemoryStream(userPicturebytes);
            userPictureBox.Image = Image.FromStream(ms);
        }
    }
}
