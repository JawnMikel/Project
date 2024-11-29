using System.Resources;

namespace MovieDatabase
{
    partial class FormCreateAcc
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
            createAccLbl = new Label();
            firstNameLbl = new Label();
            firstNameTB = new TextBox();
            lastNameLbl = new Label();
            lastNameTB = new TextBox();
            dobPicker = new DateTimePicker();
            langBtn = new Button();
            dobLbl = new Label();
            usernameLbl = new Label();
            usernameTB = new TextBox();
            passwordTB = new TextBox();
            passwordLbl = new Label();
            membershipCB = new ComboBox();
            membershipLbl = new Label();
            backBtn = new Button();
            nextBtn = new Button();
            passwordBox = new CheckBox();
            SuspendLayout();
            // 
            // createAccLbl
            // 
            createAccLbl.AutoSize = true;
            createAccLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccLbl.Location = new Point(347, 15);
            createAccLbl.Margin = new Padding(4, 0, 4, 0);
            createAccLbl.Name = "createAccLbl";
            createAccLbl.Size = new Size(441, 65);
            createAccLbl.TabIndex = 0;
            createAccLbl.Text = "Create an Account";
            // 
            // firstNameLbl
            // 
            firstNameLbl.AutoSize = true;
            firstNameLbl.Location = new Point(33, 148);
            firstNameLbl.Margin = new Padding(4, 0, 4, 0);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(97, 25);
            firstNameLbl.TabIndex = 1;
            firstNameLbl.Text = "First Name";
            // 
            // firstNameTB
            // 
            firstNameTB.Location = new Point(133, 143);
            firstNameTB.Margin = new Padding(4, 5, 4, 5);
            firstNameTB.Name = "firstNameTB";
            firstNameTB.Size = new Size(185, 31);
            firstNameTB.TabIndex = 2;
            // 
            // lastNameLbl
            // 
            lastNameLbl.AutoSize = true;
            lastNameLbl.Location = new Point(326, 148);
            lastNameLbl.Margin = new Padding(4, 0, 4, 0);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(95, 25);
            lastNameLbl.TabIndex = 3;
            lastNameLbl.Text = "Last Name";
            // 
            // lastNameTB
            // 
            lastNameTB.Location = new Point(490, 145);
            lastNameTB.Margin = new Padding(4, 5, 4, 5);
            lastNameTB.Name = "lastNameTB";
            lastNameTB.Size = new Size(190, 31);
            lastNameTB.TabIndex = 4;
            // 
            // dobPicker
            // 
            dobPicker.Location = new Point(727, 145);
            dobPicker.Margin = new Padding(4, 5, 4, 5);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new Size(284, 31);
            dobPicker.TabIndex = 5;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(837, 48);
            langBtn.Margin = new Padding(4, 5, 4, 5);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(139, 38);
            langBtn.TabIndex = 6;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // dobLbl
            // 
            dobLbl.AutoSize = true;
            dobLbl.Location = new Point(816, 113);
            dobLbl.Margin = new Padding(4, 0, 4, 0);
            dobLbl.Name = "dobLbl";
            dobLbl.Size = new Size(113, 25);
            dobLbl.TabIndex = 7;
            dobLbl.Text = "Date of birth";
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(168, 262);
            usernameLbl.Margin = new Padding(4, 0, 4, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(91, 25);
            usernameLbl.TabIndex = 8;
            usernameLbl.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(323, 260);
            usernameTB.Margin = new Padding(4, 5, 4, 5);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(173, 31);
            usernameTB.TabIndex = 9;
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(688, 259);
            passwordTB.Margin = new Padding(4, 5, 4, 5);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(175, 31);
            passwordTB.TabIndex = 10;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(553, 263);
            passwordLbl.Margin = new Padding(4, 0, 4, 0);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(87, 25);
            passwordLbl.TabIndex = 11;
            passwordLbl.Text = "Password";
            // 
            // membershipCB
            // 
            membershipCB.DisplayMember = "d";
            membershipCB.FormattingEnabled = true;
            membershipCB.Items.AddRange(new object[] { "Regular", "Premium" });
            membershipCB.Location = new Point(429, 388);
            membershipCB.Margin = new Padding(4, 5, 4, 5);
            membershipCB.Name = "membershipCB";
            membershipCB.Size = new Size(171, 33);
            membershipCB.TabIndex = 12;
            membershipCB.SelectedIndexChanged += membershipCB_SelectedIndexChanged;
            // 
            // membershipLbl
            // 
            membershipLbl.AutoSize = true;
            membershipLbl.Location = new Point(441, 358);
            membershipLbl.Margin = new Padding(4, 0, 4, 0);
            membershipLbl.Name = "membershipLbl";
            membershipLbl.Size = new Size(154, 25);
            membershipLbl.TabIndex = 13;
            membershipLbl.Text = "Membership Type";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(353, 530);
            backBtn.Margin = new Padding(4, 5, 4, 5);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(107, 38);
            backBtn.TabIndex = 14;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(573, 530);
            nextBtn.Margin = new Padding(4, 5, 4, 5);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(107, 38);
            nextBtn.TabIndex = 15;
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // passwordBox
            // 
            passwordBox.AutoSize = true;
            passwordBox.Location = new Point(881, 262);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(164, 29);
            passwordBox.TabIndex = 16;
            passwordBox.Text = "Show password";
            passwordBox.UseVisualStyleBackColor = true;
            passwordBox.CheckedChanged += passwordBox_CheckedChanged;
            // 
            // FormCreateAcc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(passwordBox);
            Controls.Add(nextBtn);
            Controls.Add(backBtn);
            Controls.Add(membershipLbl);
            Controls.Add(membershipCB);
            Controls.Add(passwordLbl);
            Controls.Add(passwordTB);
            Controls.Add(usernameTB);
            Controls.Add(usernameLbl);
            Controls.Add(dobLbl);
            Controls.Add(langBtn);
            Controls.Add(dobPicker);
            Controls.Add(lastNameTB);
            Controls.Add(lastNameLbl);
            Controls.Add(firstNameTB);
            Controls.Add(firstNameLbl);
            Controls.Add(createAccLbl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormCreateAcc";
            Text = "frmCreateAcc";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages",typeof(Program).Assembly);
            createAccLbl.Text = rm.GetString("CreateAccount");
            langBtn.Text = rm.GetString("Lanbutton");
            firstNameLbl.Text = rm.GetString("FirstName");
            lastNameLbl.Text = rm.GetString("LastName");
            dobLbl.Text = rm.GetString("DOB");
            usernameLbl.Text = rm.GetString("Username");
            passwordLbl.Text = rm.GetString("Password");
            membershipLbl.Text = rm.GetString("MembershipType");
            passwordBox.Text = rm.GetString("ShowPassword");
            backBtn.Text = rm.GetString("BackButton");
        }

        #endregion

        private Label createAccLbl;
        private Label firstNameLbl;
        private TextBox firstNameTB;
        private Label lastNameLbl;
        private TextBox lastNameTB;
        private DateTimePicker dobPicker;
        private Button langBtn;
        private Label dobLbl;
        private Label usernameLbl;
        private TextBox usernameTB;
        private TextBox passwordTB;
        private Label passwordLbl;
        private ComboBox membershipCB;
        private Label membershipLbl;
        private Button backBtn;
        private Button nextBtn;
        private CheckBox passwordBox;
    }
}