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
        public int uid;
        private Boolean isRegister;   //judge whether user is register or sign in
        private Boolean isChangeUserInfo = false; //judge whether user choose to change userInfo
        private Boolean isAutoSignIn = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { 
            isRegister = File.Exists(userInfoFilePath) ? false : true;
            readUserInfo();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // 设置隐藏
            if (isAutoSignIn)
            {
                MessageBox.Show("自动登录中!，请稍后！");
                mainForm fm = new mainForm();
                fm.Show();
                this.Hide();
            }
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
                    if(userInfoTextArray[0] == "@uid")
                    {
                        uid = Convert.ToInt32(userInfoTextArray[1]);
                    }
                    if (userInfoTextArray[0] == "@autoSign")
                    {
                        isAutoSignIn = true;
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
            Boolean isSuccessValidate;
            newUser = new User(usernameTextbox.Text, codeTextbox.Text);
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
            if (userPicturebytes == null)
            {
                MessageBox.Show("请选择您的头像");
                return;
            }
            if (isChangeUserInfo || isRegister)
            {
                //register user
                if (isChangeUserInfo)
                {
                    newUser.cmd = "3";
                }
                //isSuccessValidate = client.register(newUser);
                newUser.saveUserInfo(rememberCodeCheckBox.Checked, autoSignCheckBox.Checked);
            }
            else //when user choose to sign up
            {
                SignupUser user = new SignupUser(uid, codeTextbox.Text);
                //isSuccessValidate = client.register(user);
                //if (isSuccessValidate)
                {
                    newUser.saveUserInfo(rememberCodeCheckBox.Checked, autoSignCheckBox.Checked);
                }
            }
            //if (isSuccessValidate)
            {
                mainForm mf = new mainForm();
                mf.Show();
                this.Hide();
            }
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
            public string cmd = "1"; 
            public string username;
            public string password;
            public int uid;
            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
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
                sw.WriteLine($"@uid {uid}");
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

            public void addUid(int userUid)
            {
                this.uid = userUid;
            }
        }

        public class SignupUser
        {
            public string cmd = "2";
            public int uid;
            public string passsword;

            public SignupUser(int userUid, string userPassword)
            {
                this.uid = userUid;
                this.passsword = userPassword;
            }
        }

        public class Client
        {
            public Boolean register(Object newuser)
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
                    ip = IPAddress.Parse("10.126.15.131");
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
                    //recieve the message from the server
                    while (true)
                    {
                        try
                        {
                            byte[] msg = new byte[1024];
                            clientSocket.Receive(msg, 0, 1024, SocketFlags.None);//接受服务器消息
                            var receivedJson = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(msg));
                            msg = null;

                            switch ((int)receivedJson.cmd)
                            {
                                case 1:
                                    User user = newuser as User;
                                    if ((string)receivedJson.res == "success")
                                    {
                                        user.addUid((int)receivedJson.uid);
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("注册失败");
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        return false;
                                    }
                                case 2:
                                    if ((string)receivedJson.res == "success")
                                    {
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        return true;
                                    }
                                    else
                                    {
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        MessageBox.Show("登陆失败，密码错误！");
                                        return false;
                                    }
                                default:
                                    if ((string)receivedJson.res == "success")
                                    {
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        return true;
                                    }
                                    else
                                    {
                                        clientSocket.Shutdown(SocketShutdown.Both);
                                        clientSocket.Close();
                                        MessageBox.Show("修改账户信息失败！");
                                        return false;
                                    }
                            }
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
