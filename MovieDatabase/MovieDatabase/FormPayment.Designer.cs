namespace MovieDatabase
{
    partial class FormPayment
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
            paymentTitleLbl = new Label();
            fullnameLbl = new Label();
            fullNameTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            backBtn = new Button();
            payBtn = new Button();
            SuspendLayout();
            // 
            // paymentTitleLbl
            // 
            paymentTitleLbl.AutoSize = true;
            paymentTitleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentTitleLbl.Location = new Point(264, 9);
            paymentTitleLbl.Name = "paymentTitleLbl";
            paymentTitleLbl.Size = new Size(150, 45);
            paymentTitleLbl.TabIndex = 0;
            paymentTitleLbl.Text = "Payment";
            // 
            // fullnameLbl
            // 
            fullnameLbl.AutoSize = true;
            fullnameLbl.Location = new Point(87, 87);
            fullnameLbl.Name = "fullnameLbl";
            fullnameLbl.Size = new Size(106, 15);
            fullnameLbl.TabIndex = 1;
            fullnameLbl.Text = "Card Holder Name";
            // 
            // fullNameTB
            // 
            fullNameTB.Enabled = false;
            fullNameTB.Location = new Point(200, 84);
            fullNameTB.Name = "fullNameTB";
            fullNameTB.Size = new Size(233, 23);
            fullNameTB.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 137);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 3;
            label1.Text = "Card Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 194);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 4;
            label2.Text = "CVV";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 194);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Expiry Date";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(209, 191);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(382, 189);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(51, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(201, 137);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(232, 23);
            textBox3.TabIndex = 8;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(205, 277);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 9;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // payBtn
            // 
            payBtn.Location = new Point(358, 277);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(75, 23);
            payBtn.TabIndex = 10;
            payBtn.Text = "Pay";
            payBtn.UseVisualStyleBackColor = true;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(payBtn);
            Controls.Add(backBtn);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fullNameTB);
            Controls.Add(fullnameLbl);
            Controls.Add(paymentTitleLbl);
            Name = "FormPayment";
            Text = "frmPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label paymentTitleLbl;
        private Label fullnameLbl;
        private TextBox fullNameTB;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button backBtn;
        private Button payBtn;
    }
}