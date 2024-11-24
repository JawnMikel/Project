namespace MovieDatabase
{
    partial class FormCrewMemberInformation
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
            nameLbl = new Label();
            ratingLbl = new Label();
            backBtn = new Button();
            langBtn = new Button();
            wirteReviewBtn = new Button();
            viewReviewBtn = new Button();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameLbl.Location = new Point(12, 9);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(154, 65);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Name";
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Location = new Point(32, 93);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(67, 25);
            ratingLbl.TabIndex = 1;
            ratingLbl.Text = "Rating:";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(672, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(112, 34);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(841, 12);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // wirteReviewBtn
            // 
            wirteReviewBtn.Location = new Point(797, 106);
            wirteReviewBtn.Name = "wirteReviewBtn";
            wirteReviewBtn.Size = new Size(156, 34);
            wirteReviewBtn.TabIndex = 4;
            wirteReviewBtn.Text = "Write a review";
            wirteReviewBtn.UseVisualStyleBackColor = true;
            wirteReviewBtn.Click += wirteReviewBtn_Click;
            // 
            // viewReviewBtn
            // 
            viewReviewBtn.Location = new Point(797, 212);
            viewReviewBtn.Name = "viewReviewBtn";
            viewReviewBtn.Size = new Size(156, 34);
            viewReviewBtn.TabIndex = 5;
            viewReviewBtn.Text = "View reviews";
            viewReviewBtn.UseVisualStyleBackColor = true;
            viewReviewBtn.Click += viewReviewBtn_Click;
            // 
            // FormCrewMemberInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 592);
            Controls.Add(viewReviewBtn);
            Controls.Add(wirteReviewBtn);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(ratingLbl);
            Controls.Add(nameLbl);
            Name = "FormCrewMemberInformation";
            Text = "CrewMemberInformation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLbl;
        private Label ratingLbl;
        private Button backBtn;
        private Button langBtn;
        private Button wirteReviewBtn;
        private Button viewReviewBtn;
    }
}