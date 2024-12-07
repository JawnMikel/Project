using System.Resources;

namespace MovieDatabase
{
    partial class FormWriteReview
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
            titleLbl = new Label();
            reviewTB = new RichTextBox();
            ratingBtn = new Label();
            ratingTB = new TextBox();
            postBtn = new Button();
            backBtn = new Button();
            langBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.Location = new Point(118, 5);
            titleLbl.Margin = new Padding(2, 0, 2, 0);
            titleLbl.MaximumSize = new Size(300, 0);
            titleLbl.MinimumSize = new Size(300, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(300, 45);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Title";
            titleLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // reviewTB
            // 
            reviewTB.Location = new Point(75, 164);
            reviewTB.Margin = new Padding(2);
            reviewTB.Name = "reviewTB";
            reviewTB.Size = new Size(402, 138);
            reviewTB.TabIndex = 1;
            reviewTB.Text = "";
            // 
            // ratingBtn
            // 
            ratingBtn.AutoSize = true;
            ratingBtn.Location = new Point(213, 131);
            ratingBtn.Margin = new Padding(2, 0, 2, 0);
            ratingBtn.Name = "ratingBtn";
            ratingBtn.Size = new Size(49, 15);
            ratingBtn.TabIndex = 2;
            ratingBtn.Text = "Ratings:";
            // 
            // ratingTB
            // 
            ratingTB.Location = new Point(277, 129);
            ratingTB.Margin = new Padding(2);
            ratingTB.Name = "ratingTB";
            ratingTB.Size = new Size(49, 23);
            ratingTB.TabIndex = 3;
            // 
            // postBtn
            // 
            postBtn.Location = new Point(250, 306);
            postBtn.Margin = new Padding(2);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(78, 20);
            postBtn.TabIndex = 4;
            postBtn.Text = "Post";
            postBtn.UseVisualStyleBackColor = true;
            postBtn.Click += postBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(27, 14);
            backBtn.Margin = new Padding(2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(87, 20);
            backBtn.TabIndex = 5;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(441, 14);
            langBtn.Margin = new Padding(2);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(78, 20);
            langBtn.TabIndex = 6;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormWriteReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 374);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(postBtn);
            Controls.Add(ratingTB);
            Controls.Add(ratingBtn);
            Controls.Add(reviewTB);
            Controls.Add(titleLbl);
            Margin = new Padding(2);
            Name = "FormWriteReview";
            Text = "FormWriteReview";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages",typeof(Program).Assembly);
            ratingBtn.Text = rm.GetString("Rating");
            postBtn.Text = rm.GetString("Post");
            backBtn.Text = rm.GetString("BackButton");
            langBtn.Text = rm.GetString("Lanbutton");
        }

        #endregion

        private Label titleLbl;
        private RichTextBox reviewTB;
        private Label ratingBtn;
        private TextBox ratingTB;
        private Button postBtn;
        private Button backBtn;
        private Button langBtn;
    }
}