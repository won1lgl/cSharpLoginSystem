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
            public void register(User newuser)
            {
                string registerMessgae = JsonConvert.SerializeObject(newuser);
                Console.WriteLine(registerMessgae);
            }
        }
    }
}
