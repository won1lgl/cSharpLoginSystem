namespace loginSystem
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.codeTextbox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.showCodeCheckBox = new System.Windows.Forms.CheckBox();
            this.rememberCodeCheckBox = new System.Windows.Forms.CheckBox();
            this.autoSignCheckBox = new System.Windows.Forms.CheckBox();
            this.choosePictureButton = new System.Windows.Forms.Button();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameLabel.Location = new System.Drawing.Point(53, 231);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(82, 24);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "用户名";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(146, 231);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(196, 25);
            this.usernameTextbox.TabIndex = 1;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeLabel.Location = new System.Drawing.Point(53, 285);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(58, 24);
            this.codeLabel.TabIndex = 2;
            this.codeLabel.Text = "密码";
            // 
            // codeTextbox
            // 
            this.codeTextbox.Location = new System.Drawing.Point(146, 284);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.PasswordChar = '*';
            this.codeTextbox.Size = new System.Drawing.Size(196, 25);
            this.codeTextbox.TabIndex = 3;
            // 
            // submitButton
            // 
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitButton.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submitButton.Location = new System.Drawing.Point(146, 379);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(131, 42);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "确定";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("华文中宋", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(168, 28);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(96, 44);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "登录";
            // 
            // showCodeCheckBox
            // 
            this.showCodeCheckBox.AutoSize = true;
            this.showCodeCheckBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showCodeCheckBox.Location = new System.Drawing.Point(270, 338);
            this.showCodeCheckBox.Name = "showCodeCheckBox";
            this.showCodeCheckBox.Size = new System.Drawing.Size(89, 19);
            this.showCodeCheckBox.TabIndex = 6;
            this.showCodeCheckBox.Text = "显示密码";
            this.showCodeCheckBox.UseVisualStyleBackColor = true;
            this.showCodeCheckBox.CheckedChanged += new System.EventHandler(this.showCodeCheckBox_CheckedChanged);
            // 
            // rememberCodeCheckBox
            // 
            this.rememberCodeCheckBox.AutoSize = true;
            this.rememberCodeCheckBox.Location = new System.Drawing.Point(158, 339);
            this.rememberCodeCheckBox.Name = "rememberCodeCheckBox";
            this.rememberCodeCheckBox.Size = new System.Drawing.Size(89, 19);
            this.rememberCodeCheckBox.TabIndex = 7;
            this.rememberCodeCheckBox.Text = "记住密码";
            this.rememberCodeCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoSignCheckBox
            // 
            this.autoSignCheckBox.AutoSize = true;
            this.autoSignCheckBox.Location = new System.Drawing.Point(46, 339);
            this.autoSignCheckBox.Name = "autoSignCheckBox";
            this.autoSignCheckBox.Size = new System.Drawing.Size(89, 19);
            this.autoSignCheckBox.TabIndex = 8;
            this.autoSignCheckBox.Text = "自动登录";
            this.autoSignCheckBox.UseVisualStyleBackColor = true;
            // 
            // choosePictureButton
            // 
            this.choosePictureButton.Location = new System.Drawing.Point(284, 173);
            this.choosePictureButton.Name = "choosePictureButton";
            this.choosePictureButton.Size = new System.Drawing.Size(84, 30);
            this.choosePictureButton.TabIndex = 10;
            this.choosePictureButton.Text = "选择头像";
            this.choosePictureButton.UseVisualStyleBackColor = true;
            this.choosePictureButton.Click += new System.EventHandler(this.choosePictureButton_Click);
            // 
            // userPictureBox
            // 
            this.userPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPictureBox.Location = new System.Drawing.Point(157, 83);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(120, 120);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPictureBox.TabIndex = 11;
            this.userPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 463);
            this.Controls.Add(this.userPictureBox);
            this.Controls.Add(this.choosePictureButton);
            this.Controls.Add(this.autoSignCheckBox);
            this.Controls.Add(this.rememberCodeCheckBox);
            this.Controls.Add(this.showCodeCheckBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.codeTextbox);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Form1";
            this.Text = "欢迎";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox codeTextbox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.CheckBox showCodeCheckBox;
        private System.Windows.Forms.CheckBox rememberCodeCheckBox;
        private System.Windows.Forms.CheckBox autoSignCheckBox;
        private System.Windows.Forms.Button choosePictureButton;
        private System.Windows.Forms.PictureBox userPictureBox;
    }
}

