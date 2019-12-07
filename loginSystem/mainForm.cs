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
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace loginSystem
{
    public partial class mainForm : Form
    {
        private const string userInfoFilePath = @"C:\Users\21921\Desktop\new.txt";
        private const string userPicturePath = @"C:\Users\21921\Desktop\new.bin";

        Socket clientSocket;
        IPAddress ip;

        List<OnlineUser> onlineUserList = new List<OnlineUser>();
        private Boolean isExit = false;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loadUserInfo();
            createConnect();
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

        private void createConnect()
        {
            try
            {
                ip = IPAddress.Parse("10.126.15.131");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("IP地址不正确");
                clientSocket = null;
                ip = null;
            }
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint port = new IPEndPoint(ip, 1234);
            clientSocket.Connect(port);
            MessageBox.Show("连接成功!");

            Thread threadReceive = new Thread(new ThreadStart(receiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        private void receiveData()
        {
            while (!isExit)
            {
                byte[] msg = new byte[1024];
                try
                {
                    int receiveLength = clientSocket.Receive(msg, 0, 1024, SocketFlags.None);
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                var receivedJson = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(msg));
                if ((int)receivedJson.cmd == 4)
                {
                    var userArrayData = receivedJson.list;
                    foreach (var item in userArrayData)
                    {
                        OnlineUser user = new OnlineUser(item["uid"].ToString(), item["username"].ToString());
                        onlineUserList.Add(user);
                    }
                }
            }
        }

        private class OnlineUser
        {
            public string uid;
            public string username;
            public OnlineUser(string uid,string username)
            {
                this.username = username;
                this.uid = uid;
            }
        }
    }
}
