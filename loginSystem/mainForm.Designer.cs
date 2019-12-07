namespace loginSystem
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.userImageList = new System.Windows.Forms.ImageList(this.components);
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.userTalkRichBox = new System.Windows.Forms.RichTextBox();
            this.sendMessageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sendMessageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userImageList
            // 
            this.userImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("userImageList.ImageStream")));
            this.userImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.userImageList.Images.SetKeyName(0, "63304069_p0.png");
            this.userImageList.Images.SetKeyName(1, "65519341_p0.png");
            this.userImageList.Images.SetKeyName(2, "68126525_p0.png");
            this.userImageList.Images.SetKeyName(3, "68126525_p0.png");
            this.userImageList.Images.SetKeyName(4, "70144410_p0.png");
            this.userImageList.Images.SetKeyName(5, "69908078_p0.jpg");
            this.userImageList.Images.SetKeyName(6, "70434228_p0.png");
            // 
            // userPictureBox
            // 
            this.userPictureBox.Location = new System.Drawing.Point(39, 21);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(60, 60);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPictureBox.TabIndex = 0;
            this.userPictureBox.TabStop = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameLabel.Location = new System.Drawing.Point(113, 21);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 24);
            this.userNameLabel.TabIndex = 1;
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(118, 55);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(39, 15);
            this.userIdLabel.TabIndex = 2;
            this.userIdLabel.Text = "uid:";
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 15;
            this.userListBox.Location = new System.Drawing.Point(39, 118);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(134, 274);
            this.userListBox.TabIndex = 3;
            this.userListBox.SelectedIndexChanged += new System.EventHandler(this.userListBox_SelectedIndexChanged);
            // 
            // userTalkRichBox
            // 
            this.userTalkRichBox.Location = new System.Drawing.Point(221, 100);
            this.userTalkRichBox.Name = "userTalkRichBox";
            this.userTalkRichBox.ReadOnly = true;
            this.userTalkRichBox.Size = new System.Drawing.Size(532, 202);
            this.userTalkRichBox.TabIndex = 0;
            this.userTalkRichBox.Text = "";
            // 
            // sendMessageTextBox
            // 
            this.sendMessageTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendMessageTextBox.Location = new System.Drawing.Point(221, 344);
            this.sendMessageTextBox.Multiline = true;
            this.sendMessageTextBox.Name = "sendMessageTextBox";
            this.sendMessageTextBox.Size = new System.Drawing.Size(426, 40);
            this.sendMessageTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "在线用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "聊天内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "发送消息";
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendMessageButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendMessageButton.Location = new System.Drawing.Point(679, 344);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 40);
            this.sendMessageButton.TabIndex = 8;
            this.sendMessageButton.Text = "发送";
            this.sendMessageButton.UseVisualStyleBackColor = false;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendMessageTextBox);
            this.Controls.Add(this.userTalkRichBox);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.userPictureBox);
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList userImageList;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.RichTextBox userTalkRichBox;
        private System.Windows.Forms.TextBox sendMessageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendMessageButton;
    }
}