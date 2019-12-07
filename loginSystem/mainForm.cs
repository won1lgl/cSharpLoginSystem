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

        //与服务器建立连接
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
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint port = new IPEndPoint(ip, 1234);
                clientSocket.Connect(port);
                MessageBox.Show("连接成功!");
            }
            catch(Exception e)
            {
                MessageBox.Show("连接失败" + e.Message);
                clientSocket = null;
            }

            //开启接收消息的后台进程
            Thread threadReceive = new Thread(new ThreadStart(receiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        //接收消息的方法
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
                    MessageBox.Show("与服务器断开了连接");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    clientSocket = null;
                }
                var receivedJson = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(msg));
                //接收的消息为在线人列表
                if ((int)receivedJson.cmd == 4)
                {
                    onlineUserList.Clear();
                    var userArrayData = receivedJson.list;
                    foreach (var item in userArrayData)
                    {
                        OnlineUser user = new OnlineUser(item["uid"].ToString(), item["username"].ToString());
                        onlineUserList.Add(user);
                    }
                    UpdateUserBoxList d = new UpdateUserBoxList(updateOnlineUserList);
                    userListBox.Invoke(d);
                }
                //接收的消息为一般的消息
                if((int)receivedJson.cmd == 5)
                {
                    string message = (string)receivedJson.message;
                    string user = (string)receivedJson.user;
                    string finalMessage = $"{user}说：{message}";
                    AddTalkMessageDelegate d = new AddTalkMessageDelegate(AddTalkMessage);
                    userTalkRichBox.Invoke(d, finalMessage);
                }
            }
        }

        //更新在线用户列表的方法
        private delegate void UpdateUserBoxList();

        private void updateOnlineUserList()
        {
            if (userListBox.InvokeRequired)
            {
                UpdateUserBoxList d = new UpdateUserBoxList(updateOnlineUserList);
                userListBox.Invoke(d);
            }
            else
            {
                userListBox.Items.Clear();
                foreach (OnlineUser user in onlineUserList)
                {
                    userListBox.Items.Add(user.username);
                }
            }
        }

        //接收一般消息的方法
        private delegate void AddTalkMessageDelegate(string message);

        private void AddTalkMessage(string message)
        {
            if (userTalkRichBox.InvokeRequired)
            {
                AddTalkMessageDelegate d = new AddTalkMessageDelegate(AddTalkMessage);
                userTalkRichBox.Invoke(d, new object[] { message });
            }
            else
            {
                userTalkRichBox.AppendText(message);
                userTalkRichBox.ScrollToCaret();
            }
        }

        //单击发送按钮触发的方法
        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            if(clientSocket == null)
            {
                MessageBox.Show("你还未建立起网络连接！");
                return;
            }
            if(sendMessageTextBox.Text == null)
            {
                MessageBox.Show("不能发送空消息!");
                return;
            }
            string sendMessage = JsonConvert.SerializeObject(new SendMessage(userNameLabel.Text, sendMessageTextBox.Text));
            clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
        }

        //读取当前用户的信息
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

        private string findUserIdByUsername(string username)
        {
            foreach (OnlineUser user in onlineUserList)
            {
                if(user.username == username)
                {
                    return user.uid;
                }
            }
            return "";
        }

        //接收消息列表的单个用户类
        private class OnlineUser
        {
            public string uid;
            public string username;
            public OnlineUser(string uid, string username)
            {
                this.username = username;
                this.uid = uid;
            }
        }

        //发送消息时的消息类
        private class SendMessage
        {
            public string cmd = "5";
            public string username;
            public string message;
            public SendMessage(string username, string message)
            {
                this.username = username;
                this.message = message;
            }
        }
    }
}
