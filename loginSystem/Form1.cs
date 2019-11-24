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
        private const string userInfoFilePath = @"C:\Users\21921\Desktop\new.txt";
        Client client = new Client();
        User newUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readUserInfo();
        }

        //if exist userinfo, then read it into the textbox
        public void readUserInfo()
        {
            if (File.Exists(userInfoFilePath))
            {
                StreamReader sr = null;
                sr = File.OpenText(userInfoFilePath);
                string[] userInfo = new string[3];
                int i = 0;
                while (sr.Peek() != -1)
                {
                    userInfo[i++] = sr.ReadLine();
                }
                sr.Close();
                usernameTextbox.Text = userInfo[0];
                codeTextbox.Text = userInfo[1];
                if(userInfo[1] != "")
                {
                    rememberCodeCheckBox.Checked = true;
                }
                if(userInfo[2] == "autoSign")
                {
                    MessageBox.Show("自动登录");
                    newUser = new User(userInfo[0], userInfo[1]);
                    //client.register(newUser);
                }
            } else
            {
                titleLabel.Text = "注册";
            }
        }

        //MARK:Action

        private void submitButton_Click(object sender, EventArgs e)
        {

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
            newUser.saveUserInfo(rememberCodeCheckBox.Checked, autoSignCheckBox.Checked);
            //client.register(newUser);
        }

        //MARK:Custom class
        public class User
        {
            public string cmd = "01"; 
            public string username;
            public string password;
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
                catch
                {
                    MessageBox.Show("文件创建失败");
                    return;
                }
                sw.WriteLine(username);
                if (isSaveCode)
                {
                    sw.WriteLine(password);
                }
                if (isAutoSign)
                {
                    sw.WriteLine("autoSign");
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
                    return true;
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

        //checkbox to show the code
        private void showCodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCodeCheckBox.Checked == true)
            {
                codeTextbox.PasswordChar = new char();
            } else
            {
                codeTextbox.PasswordChar = '*';
            }
        }
    }
}
