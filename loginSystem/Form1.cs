using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace loginSystem
{
    public partial class Form1 : Form
    {
        //MARK: property
        private const string userInfoFilePath = @"C:\Users\21921\Desktop\new.txt";
        private const string userPicturePath = @"C:\Users\21921\Desktop\new.bin";
        Client client = new Client();
        User newUser;
        byte[] userPicturebytes; //save the userPicture
        private Boolean isRegister;   //judge whether user is register or sign in
        private Boolean isChangeUserInfo = false; //judge whether user choose to change userInfo

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { 
            isRegister = File.Exists(userInfoFilePath) ? false : true;
            readUserInfo();
        }

        //If exist userinfo, then read it into the textbox
        public void readUserInfo()
        {
                if (!isRegister)
            {
                StreamReader sr = null;
                sr = File.OpenText(userInfoFilePath);
                while (sr.Peek() != -1)
                {
                    string userInfoText = sr.ReadLine();
                    string[] userInfoTextArray = System.Text.RegularExpressions.Regex.Split(userInfoText, @"\s{1,}");
                    if(userInfoTextArray[0] == "@username")
                    {
                        usernameTextbox.Text = userInfoTextArray[1];
                    }
                    if(userInfoTextArray[0] == "@password")
                    {
                        codeTextbox.Text = userInfoTextArray[1];
                        rememberCodeCheckBox.Checked = true;
                    }
                    if (userInfoTextArray[0] == "@autoSign")
                    {
                        MessageBox.Show("自动登录");
                    }
                    
                }
                sr.Close();
                //load the image
                FileStream fs = new FileStream(userPicturePath, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int length = Convert.ToInt32(br.BaseStream.Length);
                userPicturebytes = br.ReadBytes(length);
                br.Close();
                fs.Close();
                MemoryStream ms = new MemoryStream(userPicturebytes);
                userPictureBox.Image = Image.FromStream(ms);
                //change UI
                choosePictureButton.Visible = false;
                usernameTextbox.ReadOnly = true;
                changeUserInfoButton.Visible = true;
            } else
            {
                titleLabel.Text = "注册";
            }
        }

        //MARK:Action
        private void submitButton_Click(object sender, EventArgs e)
        {
            //register user
            newUser = new User(usernameTextbox.Text, codeTextbox.Text, userPicturebytes);
            //check whether the input info is legal
            if (newUser.username == "")
            {
                MessageBox.Show("用户名不得为空！");
                return;
            }
            if (newUser.password == "")
            {
                MessageBox.Show("密码不得为空！");
                return;
            }
            if(newUser.userPicture == null)
            {
                MessageBox.Show("请上传头像！");
            }
            if (!isRegister)
            {
                newUser.cmd = "02";
            }
            if(isChangeUserInfo)
            {
                newUser.cmd = "03";
            }
            newUser.saveUserInfo(rememberCodeCheckBox.Checked, autoSignCheckBox.Checked);
            //client.register(newUser);


            //go to the next Form
            mainForm mf = new mainForm();
            mf.Show();
            this.Hide();
        }

        //checkbox to show the code
        private void showCodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCodeCheckBox.Checked == true)
            {
                codeTextbox.PasswordChar = new char();
            }
            else
            {
                codeTextbox.PasswordChar = '*';
            }
        }

        //choose the userPicture to show 
        private void choosePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "jpg图片|*.jpg|gif图片|*.gif|png图片|*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(file.FileName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    int lenth = Convert.ToInt32(br.BaseStream.Length);
                    userPicturebytes = br.ReadBytes(lenth);
                    using (FileStream fs1 = new FileStream(userPicturePath, FileMode.Create))
                    {
                        BinaryWriter bw = new BinaryWriter(fs1);
                        for(int i = 0; i < userPicturebytes.Length; i++)
                        {
                            bw.Write(userPicturebytes[i]);
                        }
                        bw.Close();
                    }
                    br.Close();
                    fs.Close();
                    MemoryStream ms = new MemoryStream(userPicturebytes);
                    userPictureBox.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void changeUserInfoButton_Click(object sender, EventArgs e)
        {
            usernameTextbox.ReadOnly = false;
            choosePictureButton.Visible = true;
            changeUserInfoButton.Visible = false;
            isChangeUserInfo = true;
            titleLabel.Text = "修改";
        }

        //MARK:Custom class
        public class User
        {
            public string cmd = "01"; 
            public string username;
            public string password;
            public byte[] userPicture;
            public User(string username, string password, byte[] userPhoto)
            {
                this.username = username;
                this.password = password;
                this.userPicture = userPhoto;
            }

            //save the userinfo
            public void saveUserInfo(Boolean isSaveCode, Boolean isAutoSign)
            {
                StreamWriter sw;
                try
                {
                    sw = File.CreateText(userInfoFilePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show("文件创建失败");
                    Console.WriteLine(e);
                    return;
                }
                sw.WriteLine($"@username {username}");
                if (isSaveCode)
                {
                    sw.WriteLine($"@password {password}");
                }
                if (isAutoSign)
                {
                    sw.WriteLine("@autoSign");
                }
                sw.Close();
            }
        }

        public class Client
        {
            public Boolean register(User newuser)
            {
                //if all input are legal, then send them to the server
                Socket clientSocket;
                IPAddress ip;
                //convert info into JSON
                string registerMessgae = JsonConvert.SerializeObject(newuser);
                //then convert JSON to byte
                byte[] message = Encoding.UTF8.GetBytes(registerMessgae);
                Console.WriteLine(registerMessgae);
                //create connect to the server
                try
                {
                    ip = IPAddress.Parse("127.0.0.1");
                }
                catch(System.FormatException)
                {
                    MessageBox.Show("IP地址不正确");
                    clientSocket = null;
                    ip = null;
                    return false;
                }
                try
                {
                    //send message to the server
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint port = new IPEndPoint(ip, 1234);
                    clientSocket.Connect(port);
                    clientSocket.Send(message);
                    byte[] msg = new byte[256];
                    //recieve the message from the server
                    while (true)
                    {
                        try
                        {
                            clientSocket.Receive(msg, 0, 256, SocketFlags.None);
                            String data = Encoding.UTF8.GetString(msg);
                            return true;
                        }
                        catch (SocketException)
                        {
                            MessageBox.Show("服务器意外断开了连接");
                            clientSocket.Close();
                            clientSocket = null;
                            ip = null;
                            return false;
                        }
                    }
                }
                catch (SocketException)
                {
                    MessageBox.Show("套接字异常");
                    clientSocket = null;
                    ip = null;
                    return false;
                }
            }
        }

    }
}
