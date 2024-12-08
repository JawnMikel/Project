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
            titleLbl.Location = new Point(168, 9);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(118, 65);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Title";
            // 
            // reviewTB
            // 
            reviewTB.Location = new Point(108, 167);
            reviewTB.Name = "reviewTB";
            reviewTB.Size = new Size(573, 227);
            reviewTB.TabIndex = 1;
            reviewTB.Text = "";
            // 
            // ratingBtn
            // 
            ratingBtn.AutoSize = true;
            ratingBtn.Location = new Point(305, 111);
            ratingBtn.Name = "ratingBtn";
            ratingBtn.Size = new Size(75, 25);
            ratingBtn.TabIndex = 2;
            ratingBtn.Text = "Ratings:";
            // 
            // ratingTB
            // 
            ratingTB.Location = new Point(397, 108);
            ratingTB.Name = "ratingTB";
            ratingTB.Size = new Size(68, 31);
            ratingTB.TabIndex = 3;
            // 
            // postBtn
            // 
            postBtn.Location = new Point(359, 404);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(112, 34);
            postBtn.TabIndex = 4;
            postBtn.Text = "Post";
            postBtn.UseVisualStyleBackColor = true;
            postBtn.Click += postBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(38, 24);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(124, 34);
            backBtn.TabIndex = 5;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(630, 24);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 6;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormWriteReview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(postBtn);
            Controls.Add(ratingTB);
            Controls.Add(ratingBtn);
            Controls.Add(reviewTB);
            Controls.Add(titleLbl);
            Name = "FormWriteReview";
            Text = "FormWriteReview";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Updates the language by using the ResourceManager
        /// </summary>
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