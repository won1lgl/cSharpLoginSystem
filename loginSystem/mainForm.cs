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

        private const string userPicturePath = @"C:\Users\21921\Desktop\new.bin";

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loadImageList();
            loadListView();
        }

        private void loadImageList()
        {
            FileStream fs = new FileStream(userPicturePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int length = Convert.ToInt32(br.BaseStream.Length);
            byte[] userPicturebytes = br.ReadBytes(length);
            br.Close();
            fs.Close();
            MemoryStream ms = new MemoryStream(userPicturebytes);
            for (int i = 0; i < 100; i++)
            {
                userImageList.Images.Add(Image.FromStream(ms));
            }
        }

        private void loadListView()
        {
            userListView.SmallImageList = userImageList;
            userListView.BeginUpdate();
            for(int i=0; i<5; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = "item" + i;
                userListView.Items.Add(lvi);
            }
            userListView.EndUpdate();
        }
    }
}
