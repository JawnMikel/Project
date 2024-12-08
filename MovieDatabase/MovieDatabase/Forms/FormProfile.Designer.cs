using System.Resources;

namespace MovieDatabase
{
    partial class FormProfile
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
            profileLbl = new Label();
            logoutBtn = new Button();
            watchlistBtn = new Button();
            fullNameLbl = new Label();
            fullNameTB = new TextBox();
            usernameLbl = new Label();
            usernameTB = new TextBox();
            dobLbl = new Label();
            membershipTB = new TextBox();
            dobPicker = new DateTimePicker();
            membershipLbl = new Label();
            upgradeBtn = new Button();
            backBtn = new Button();
            langBtn = new Button();
            SuspendLayout();
            // 
            // profileLbl
            // 
            profileLbl.AutoSize = true;
            profileLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileLbl.Location = new Point(247, 5);
            profileLbl.Margin = new Padding(2, 0, 2, 0);
            profileLbl.Name = "profileLbl";
            profileLbl.Size = new Size(120, 45);
            profileLbl.TabIndex = 0;
            profileLbl.Text = "Profile";
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(501, 7);
            logoutBtn.Margin = new Padding(2, 2, 2, 2);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(102, 20);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // watchlistBtn
            // 
            watchlistBtn.Location = new Point(373, 269);
            watchlistBtn.Margin = new Padding(2, 2, 2, 2);
            watchlistBtn.Name = "watchlistBtn";
            watchlistBtn.Size = new Size(222, 20);
            watchlistBtn.TabIndex = 2;
            watchlistBtn.Text = "Watch list";
            watchlistBtn.UseVisualStyleBackColor = true;
            watchlistBtn.Click += watchlistBtn_Click;
            // 
            // fullNameLbl
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.Location = new Point(173, 73);
            fullNameLbl.Margin = new Padding(2, 0, 2, 0);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Size = new Size(67, 15);
            fullNameLbl.TabIndex = 3;
            fullNameLbl.Text = "Full Name: ";
            // 
            // fullNameTB
            // 
            fullNameTB.Enabled = false;
            fullNameTB.Location = new Point(270, 73);
            fullNameTB.Margin = new Padding(2, 2, 2, 2);
            fullNameTB.Name = "fullNameTB";
            fullNameTB.Size = new Size(147, 23);
            fullNameTB.TabIndex = 4;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(171, 106);
            usernameLbl.Margin = new Padding(2, 0, 2, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(60, 15);
            usernameLbl.TabIndex = 5;
            usernameLbl.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Enabled = false;
            usernameTB.Location = new Point(270, 106);
            usernameTB.Margin = new Padding(2, 2, 2, 2);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(147, 23);
            usernameTB.TabIndex = 6;
            // 
            // dobLbl
            // 
            dobLbl.AutoSize = true;
            dobLbl.Location = new Point(164, 137);
            dobLbl.Margin = new Padding(2, 0, 2, 0);
            dobLbl.Name = "dobLbl";
            dobLbl.Size = new Size(73, 15);
            dobLbl.TabIndex = 7;
            dobLbl.Text = "Date of Birth";
            // 
            // membershipTB
            // 
            membershipTB.Enabled = false;
            membershipTB.Location = new Point(270, 173);
            membershipTB.Margin = new Padding(2, 2, 2, 2);
            membershipTB.Name = "membershipTB";
            membershipTB.Size = new Size(125, 23);
            membershipTB.TabIndex = 8;
            // 
            // dobPicker
            // 
            dobPicker.Enabled = false;
            dobPicker.Location = new Point(270, 137);
            dobPicker.Margin = new Padding(2, 2, 2, 2);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new Size(180, 23);
            dobPicker.TabIndex = 9;
            // 
            // membershipLbl
            // 
            membershipLbl.AutoSize = true;
            membershipLbl.Location = new Point(171, 175);
            membershipLbl.Margin = new Padding(2, 0, 2, 0);
            membershipLbl.Name = "membershipLbl";
            membershipLbl.Size = new Size(74, 15);
            membershipLbl.TabIndex = 10;
            membershipLbl.Text = "Membership";
            // 
            // upgradeBtn
            // 
            upgradeBtn.Location = new Point(238, 214);
            upgradeBtn.Margin = new Padding(2, 2, 2, 2);
            upgradeBtn.Name = "upgradeBtn";
            upgradeBtn.Size = new Size(178, 20);
            upgradeBtn.TabIndex = 11;
            upgradeBtn.Text = "Upgrade Membership";
            upgradeBtn.UseVisualStyleBackColor = true;
            upgradeBtn.Click += upgradeBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(20, 269);
            backBtn.Margin = new Padding(2, 2, 2, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(104, 20);
            backBtn.TabIndex = 12;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(8, 7);
            langBtn.Margin = new Padding(2, 2, 2, 2);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(78, 20);
            langBtn.TabIndex = 13;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 304);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(upgradeBtn);
            Controls.Add(membershipLbl);
            Controls.Add(dobPicker);
            Controls.Add(membershipTB);
            Controls.Add(dobLbl);
            Controls.Add(usernameTB);
            Controls.Add(usernameLbl);
            Controls.Add(fullNameTB);
            Controls.Add(fullNameLbl);
            Controls.Add(watchlistBtn);
            Controls.Add(logoutBtn);
            Controls.Add(profileLbl);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormProfile";
            Text = "FormProfile";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Updates the language by using the ResourceManager
        /// </summary>
        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            profileLbl.Text = rm.GetString("Profile");
            logoutBtn.Text = rm.GetString("LogOut");
            watchlistBtn.Text = rm.GetString("WatchList");
            fullNameLbl.Text = rm.GetString("FullName");
            usernameLbl.Text = rm.GetString("Username");
            dobLbl.Text = rm.GetString("DOB");
            membershipLbl.Text = rm.GetString("Membership");
            upgradeBtn.Text = rm.GetString("UpgradeMembership");
            backBtn.Text = rm.GetString("BackButton");
            langBtn.Text = rm.GetString("Lanbutton");
        }

        #endregion

        private Label profileLbl;
        private Button logoutBtn;
        private Button watchlistBtn;
        private Label fullNameLbl;
        private TextBox fullNameTB;
        private Label usernameLbl;
        private TextBox usernameTB;
        private Label dobLbl;
        private TextBox membershipTB;
        private DateTimePicker dobPicker;
        private Label membershipLbl;
        private Button upgradeBtn;
        private Button backBtn;
        private Button langBtn;
    }
}