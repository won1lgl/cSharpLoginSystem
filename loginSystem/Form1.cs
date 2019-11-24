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

namespace loginSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //MARK:Action

        private void submitButton_Click(object sender, EventArgs e)
        {
            User newUser = new User(usernameTextbox.Text, codeTextbox.Text);
            Client client = new Client();
            client.register(newUser);
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

        }

        public class Client
        {
            public Boolean register(User newuser)
            {
                //check whether the input info is legal
                if (newuser.username == "")
                {
                    MessageBox.Show("用户名不得为空！");
                    return false;
                }
                if (newuser.password == "")
                {
                    MessageBox.Show("密码不得为空！");
                    return false;
                }

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
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint port = new IPEndPoint(ip, 1234);
                    clientSocket.Connect(port);
                    clientSocket.Send(message);
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
    }
}
