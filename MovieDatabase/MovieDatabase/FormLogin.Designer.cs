namespace MovieDatabase
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginBtn = new Button();
            usernameTB = new TextBox();
            usernameLbl = new Label();
            langBtn = new Button();
            loginTitleLbl = new Label();
            passwordLbl = new Label();
            passwordTB = new TextBox();
            createAccBtn = new Button();
            errorLbl = new Label();
            passwordBox = new CheckBox();
            SuspendLayout();
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(657, 390);
            loginBtn.Margin = new Padding(4, 5, 4, 5);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(153, 38);
            loginBtn.TabIndex = 0;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(540, 158);
            usernameTB.Margin = new Padding(4, 5, 4, 5);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(184, 31);
            usernameTB.TabIndex = 1;
            usernameTB.MouseClick += usernameTB_MouseClick;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(443, 163);
            usernameLbl.Margin = new Padding(4, 0, 4, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(91, 25);
            usernameLbl.TabIndex = 2;
            usernameLbl.Text = "Username";
            // 
            // langBtn
            // 
            langBtn.Location = new Point(884, 53);
            langBtn.Margin = new Padding(4, 5, 4, 5);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(130, 38);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            // 
            // loginTitleLbl
            // 
            loginTitleLbl.AutoSize = true;
            loginTitleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginTitleLbl.Location = new Point(553, 20);
            loginTitleLbl.Margin = new Padding(4, 0, 4, 0);
            loginTitleLbl.Name = "loginTitleLbl";
            loginTitleLbl.Size = new Size(155, 65);
            loginTitleLbl.TabIndex = 4;
            loginTitleLbl.Text = "Login";
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(445, 223);
            passwordLbl.Margin = new Padding(4, 0, 4, 0);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(87, 25);
            passwordLbl.TabIndex = 5;
            passwordLbl.Text = "Password";
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(540, 220);
            passwordTB.Margin = new Padding(4, 5, 4, 5);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(184, 31);
            passwordTB.TabIndex = 6;
            passwordTB.UseSystemPasswordChar = true;
            passwordTB.MouseClick += passwordTB_MouseClick;
            // 
            // createAccBtn
            // 
            createAccBtn.Location = new Point(401, 390);
            createAccBtn.Margin = new Padding(4, 5, 4, 5);
            createAccBtn.Name = "createAccBtn";
            createAccBtn.Size = new Size(153, 38);
            createAccBtn.TabIndex = 7;
            createAccBtn.Text = "Create Account";
            createAccBtn.UseVisualStyleBackColor = true;
            createAccBtn.Click += createAccBtn_Click;
            // 
            // errorLbl
            // 
            errorLbl.AutoSize = true;
            errorLbl.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            errorLbl.ForeColor = Color.Red;
            errorLbl.Location = new Point(356, 307);
            errorLbl.Margin = new Padding(4, 0, 4, 0);
            errorLbl.Name = "errorLbl";
            errorLbl.Size = new Size(580, 32);
            errorLbl.TabIndex = 8;
            errorLbl.Text = "Username or password do not match! Please try again";
            // 
            // passwordBox
            // 
            passwordBox.AutoSize = true;
            passwordBox.Location = new Point(553, 275);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(164, 29);
            passwordBox.TabIndex = 9;
            passwordBox.Text = "Show password";
            passwordBox.UseVisualStyleBackColor = true;
            passwordBox.CheckedChanged += passwordBox_CheckedChanged;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(passwordBox);
            Controls.Add(errorLbl);
            Controls.Add(createAccBtn);
            Controls.Add(passwordTB);
            Controls.Add(passwordLbl);
            Controls.Add(loginTitleLbl);
            Controls.Add(langBtn);
            Controls.Add(usernameLbl);
            Controls.Add(usernameTB);
            Controls.Add(loginBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginBtn;
        private TextBox usernameTB;
        private Label usernameLbl;
        private Button langBtn;
        private Label loginTitleLbl;
        private Label passwordLbl;
        private TextBox passwordTB;
        private Button createAccBtn;
        private Label errorLbl;
        private CheckBox passwordBox;
    }
}
