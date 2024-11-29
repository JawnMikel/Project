using System.Resources;

namespace MovieDatabase
{
    partial class FormPaymentSignUp
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
            cardNumLbl = new Label();
            cvvLbl = new Label();
            expiryDateLbl = new Label();
            expiryDateTB = new TextBox();
            cvvTB = new TextBox();
            cardNumberTB = new TextBox();
            backBtn = new Button();
            payBtn = new Button();
            langBtn = new Button();
            SuspendLayout();
            // 
            // paymentTitleLbl
            // 
            paymentTitleLbl.AutoSize = true;
            paymentTitleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentTitleLbl.Location = new Point(474, 9);
            paymentTitleLbl.Margin = new Padding(4, 0, 4, 0);
            paymentTitleLbl.Name = "paymentTitleLbl";
            paymentTitleLbl.Size = new Size(226, 65);
            paymentTitleLbl.TabIndex = 0;
            paymentTitleLbl.Text = "Payment";
            // 
            // fullnameLbl
            // 
            fullnameLbl.AutoSize = true;
            fullnameLbl.Location = new Point(256, 135);
            fullnameLbl.Margin = new Padding(4, 0, 4, 0);
            fullnameLbl.Name = "fullnameLbl";
            fullnameLbl.Size = new Size(160, 25);
            fullnameLbl.TabIndex = 1;
            fullnameLbl.Text = "Card Holder Name";
            // 
            // fullNameTB
            // 
            fullNameTB.Location = new Point(418, 130);
            fullNameTB.Margin = new Padding(4, 5, 4, 5);
            fullNameTB.Name = "fullNameTB";
            fullNameTB.Size = new Size(331, 31);
            fullNameTB.TabIndex = 2;
            // 
            // cardNumLbl
            // 
            cardNumLbl.AutoSize = true;
            cardNumLbl.Location = new Point(295, 218);
            cardNumLbl.Margin = new Padding(4, 0, 4, 0);
            cardNumLbl.Name = "cardNumLbl";
            cardNumLbl.Size = new Size(119, 25);
            cardNumLbl.TabIndex = 3;
            cardNumLbl.Text = "Card Number";
            // 
            // cvvLbl
            // 
            cvvLbl.AutoSize = true;
            cvvLbl.Location = new Point(628, 313);
            cvvLbl.Margin = new Padding(4, 0, 4, 0);
            cvvLbl.Name = "cvvLbl";
            cvvLbl.Size = new Size(45, 25);
            cvvLbl.TabIndex = 4;
            cvvLbl.Text = "CVV";
            // 
            // expiryDateLbl
            // 
            expiryDateLbl.AutoSize = true;
            expiryDateLbl.Location = new Point(328, 313);
            expiryDateLbl.Margin = new Padding(4, 0, 4, 0);
            expiryDateLbl.Name = "expiryDateLbl";
            expiryDateLbl.Size = new Size(101, 25);
            expiryDateLbl.TabIndex = 5;
            expiryDateLbl.Text = "Expiry Date";
            // 
            // expiryDateTB
            // 
            expiryDateTB.Location = new Point(431, 308);
            expiryDateTB.Margin = new Padding(4, 5, 4, 5);
            expiryDateTB.Name = "expiryDateTB";
            expiryDateTB.Size = new Size(101, 31);
            expiryDateTB.TabIndex = 6;
            // 
            // cvvTB
            // 
            cvvTB.Location = new Point(678, 305);
            cvvTB.Margin = new Padding(4, 5, 4, 5);
            cvvTB.Name = "cvvTB";
            cvvTB.Size = new Size(71, 31);
            cvvTB.TabIndex = 7;
            // 
            // cardNumberTB
            // 
            cardNumberTB.Location = new Point(419, 218);
            cardNumberTB.Margin = new Padding(4, 5, 4, 5);
            cardNumberTB.Name = "cardNumberTB";
            cardNumberTB.Size = new Size(330, 31);
            cardNumberTB.TabIndex = 8;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(425, 452);
            backBtn.Margin = new Padding(4, 5, 4, 5);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(107, 38);
            backBtn.TabIndex = 9;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // payBtn
            // 
            payBtn.Location = new Point(643, 452);
            payBtn.Margin = new Padding(4, 5, 4, 5);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(107, 38);
            payBtn.TabIndex = 10;
            payBtn.Text = "Pay";
            payBtn.UseVisualStyleBackColor = true;
            payBtn.Click += payBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(803, 36);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 11;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormPaymentSignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(langBtn);
            Controls.Add(payBtn);
            Controls.Add(backBtn);
            Controls.Add(cardNumberTB);
            Controls.Add(cvvTB);
            Controls.Add(expiryDateTB);
            Controls.Add(expiryDateLbl);
            Controls.Add(cvvLbl);
            Controls.Add(cardNumLbl);
            Controls.Add(fullNameTB);
            Controls.Add(fullnameLbl);
            Controls.Add(paymentTitleLbl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormPaymentSignUp";
            Text = "frmPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            fullnameLbl.Text = rm.GetString("CardHolderName");
            cardNumLbl.Text = rm.GetString("CardNumber");
            cvvLbl.Text = rm.GetString("CVV");
            backBtn.Text = rm.GetString("BackButton");
            payBtn.Text = rm.GetString("PayButton");
            langBtn.Text = rm.GetString("Lanbutton");
            expiryDateLbl.Text = rm.GetString("ExpiryDate");
            paymentTitleLbl.Text = rm.GetString("Payment");

        }

        #endregion

        private Label paymentTitleLbl;
        private Label fullnameLbl;
        private TextBox fullNameTB;
        private Label cardNumLbl;
        private Label cvvLbl;
        private Label expiryDateLbl;
        private TextBox expiryDateTB;
        private TextBox cvvTB;
        private TextBox cardNumberTB;
        private Button backBtn;
        private Button payBtn;
        private Button langBtn;
    }
}