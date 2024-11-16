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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            usernameTB = new TextBox();
            dobLbl = new Label();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            upgradeBtn = new Button();
            SuspendLayout();
            // 
            // profileLbl
            // 
            profileLbl.AutoSize = true;
            profileLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileLbl.Location = new Point(353, 9);
            profileLbl.Name = "profileLbl";
            profileLbl.Size = new Size(176, 65);
            profileLbl.TabIndex = 0;
            profileLbl.Text = "Profile";
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(723, 12);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(138, 34);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // watchlistBtn
            // 
            watchlistBtn.Location = new Point(28, 12);
            watchlistBtn.Name = "watchlistBtn";
            watchlistBtn.Size = new Size(142, 34);
            watchlistBtn.TabIndex = 2;
            watchlistBtn.Text = "Watch list";
            watchlistBtn.UseVisualStyleBackColor = true;
            watchlistBtn.Click += watchlistBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 122);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 3;
            label1.Text = "Full Name: ";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(386, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 31);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 179);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Enabled = false;
            usernameTB.Location = new Point(386, 176);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(177, 31);
            usernameTB.TabIndex = 6;
            // 
            // dobLbl
            // 
            dobLbl.AutoSize = true;
            dobLbl.Location = new Point(268, 228);
            dobLbl.Name = "dobLbl";
            dobLbl.Size = new Size(112, 25);
            dobLbl.TabIndex = 7;
            dobLbl.Text = "Date of Birth";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(386, 288);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 31);
            textBox2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(386, 228);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 294);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 10;
            label3.Text = "Membership";
            // 
            // upgradeBtn
            // 
            upgradeBtn.Location = new Point(386, 367);
            upgradeBtn.Name = "upgradeBtn";
            upgradeBtn.Size = new Size(112, 34);
            upgradeBtn.TabIndex = 11;
            upgradeBtn.Text = "Upgrade";
            upgradeBtn.UseVisualStyleBackColor = true;
            upgradeBtn.Click += upgradeBtn_Click;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 506);
            Controls.Add(upgradeBtn);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(dobLbl);
            Controls.Add(usernameTB);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(watchlistBtn);
            Controls.Add(logoutBtn);
            Controls.Add(profileLbl);
            Name = "FormProfile";
            Text = "FormProfile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label profileLbl;
        private Button logoutBtn;
        private Button watchlistBtn;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox usernameTB;
        private Label dobLbl;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Button upgradeBtn;
    }
}