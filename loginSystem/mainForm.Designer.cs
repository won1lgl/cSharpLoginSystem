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
            this.userListView = new System.Windows.Forms.ListView();
            this.userImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // userListView
            // 
            this.userListView.HideSelection = false;
            this.userListView.Location = new System.Drawing.Point(37, 50);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(171, 363);
            this.userListView.TabIndex = 0;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.View = System.Windows.Forms.View.SmallIcon;
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userListView);
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.ImageList userImageList;
    }
}