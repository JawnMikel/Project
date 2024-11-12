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
            SuspendLayout();
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(460, 234);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(107, 23);
            loginBtn.TabIndex = 0;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(378, 95);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(130, 23);
            usernameTB.TabIndex = 1;
            usernameTB.MouseClick += usernameTB_MouseClick;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(310, 98);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(60, 15);
            usernameLbl.TabIndex = 2;
            usernameLbl.Text = "Username";
            // 
            // langBtn
            // 
            langBtn.Location = new Point(619, 32);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(91, 23);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            // 
            // loginTitleLbl
            // 
            loginTitleLbl.AutoSize = true;
            loginTitleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginTitleLbl.Location = new Point(387, 12);
            loginTitleLbl.Name = "loginTitleLbl";
            loginTitleLbl.Size = new Size(104, 45);
            loginTitleLbl.TabIndex = 4;
            loginTitleLbl.Text = "Login";
            loginTitleLbl.Click += loginTitleLbl_Click;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(310, 154);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(57, 15);
            passwordLbl.TabIndex = 5;
            passwordLbl.Text = "Password";
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(378, 146);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(130, 23);
            passwordTB.TabIndex = 6;
            passwordTB.MouseClick += passwordTB_MouseClick;
            // 
            // createAccBtn
            // 
            createAccBtn.Location = new Point(281, 234);
            createAccBtn.Name = "createAccBtn";
            createAccBtn.Size = new Size(107, 23);
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
            errorLbl.Location = new Point(249, 184);
            errorLbl.Name = "errorLbl";
            errorLbl.Size = new Size(387, 21);
            errorLbl.TabIndex = 8;
            errorLbl.Text = "Username or password do not match! Please try again";
            errorLbl.Click += label1_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(errorLbl);
            Controls.Add(createAccBtn);
            Controls.Add(passwordTB);
            Controls.Add(passwordLbl);
            Controls.Add(loginTitleLbl);
            Controls.Add(langBtn);
            Controls.Add(usernameLbl);
            Controls.Add(usernameTB);
            Controls.Add(loginBtn);
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
    }
}
