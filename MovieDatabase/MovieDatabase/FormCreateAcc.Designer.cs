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
            dateTimePicker1 = new DateTimePicker();
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
            SuspendLayout();
            // 
            // createAccLbl
            // 
            createAccLbl.AutoSize = true;
            createAccLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccLbl.Location = new Point(243, 9);
            createAccLbl.Name = "createAccLbl";
            createAccLbl.Size = new Size(293, 45);
            createAccLbl.TabIndex = 0;
            createAccLbl.Text = "Create an Account";
            // 
            // firstNameLbl
            // 
            firstNameLbl.AutoSize = true;
            firstNameLbl.Location = new Point(2, 89);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(64, 15);
            firstNameLbl.TabIndex = 1;
            firstNameLbl.Text = "First Name";
            // 
            // firstNameTB
            // 
            firstNameTB.Location = new Point(72, 86);
            firstNameTB.Name = "firstNameTB";
            firstNameTB.Size = new Size(131, 23);
            firstNameTB.TabIndex = 2;
            // 
            // lastNameLbl
            // 
            lastNameLbl.AutoSize = true;
            lastNameLbl.Location = new Point(209, 89);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(63, 15);
            lastNameLbl.TabIndex = 3;
            lastNameLbl.Text = "Last Name";
            // 
            // lastNameTB
            // 
            lastNameTB.Location = new Point(305, 86);
            lastNameTB.Name = "lastNameTB";
            lastNameTB.Size = new Size(134, 23);
            lastNameTB.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(466, 86);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(586, 29);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(97, 23);
            langBtn.TabIndex = 6;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // dobLbl
            // 
            dobLbl.AutoSize = true;
            dobLbl.Location = new Point(529, 68);
            dobLbl.Name = "dobLbl";
            dobLbl.Size = new Size(73, 15);
            dobLbl.TabIndex = 7;
            dobLbl.Text = "Date of birth";
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(116, 159);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(60, 15);
            usernameLbl.TabIndex = 8;
            usernameLbl.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(226, 156);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(100, 23);
            usernameTB.TabIndex = 9;
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(447, 156);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(100, 23);
            passwordTB.TabIndex = 10;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(364, 159);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(57, 15);
            passwordLbl.TabIndex = 11;
            passwordLbl.Text = "Password";
            // 
            // membershipCB
            // 
            membershipCB.DisplayMember = "d";
            membershipCB.FormattingEnabled = true;
            membershipCB.Items.AddRange(new object[] { "Regular", "Premium" });
            membershipCB.Location = new Point(300, 233);
            membershipCB.Name = "membershipCB";
            membershipCB.Size = new Size(121, 23);
            membershipCB.TabIndex = 12;
            membershipCB.SelectedIndexChanged += membershipCB_SelectedIndexChanged;
            // 
            // membershipLbl
            // 
            membershipLbl.AutoSize = true;
            membershipLbl.Location = new Point(309, 215);
            membershipLbl.Name = "membershipLbl";
            membershipLbl.Size = new Size(101, 15);
            membershipLbl.TabIndex = 13;
            membershipLbl.Text = "Membership Type";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(247, 318);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 14;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(401, 318);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 23);
            nextBtn.TabIndex = 15;
            nextBtn.Text = "button2";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // FormCreateAcc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Controls.Add(dateTimePicker1);
            Controls.Add(lastNameTB);
            Controls.Add(lastNameLbl);
            Controls.Add(firstNameTB);
            Controls.Add(firstNameLbl);
            Controls.Add(createAccLbl);
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
        }

        #endregion

        private Label createAccLbl;
        private Label firstNameLbl;
        private TextBox firstNameTB;
        private Label lastNameLbl;
        private TextBox lastNameTB;
        private DateTimePicker dateTimePicker1;
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
    }
}