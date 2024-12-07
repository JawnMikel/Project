using System.Data.Entity;
using System.Resources;

namespace MovieDatabase
{
    partial class FormViewReview
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
            reviewsTB = new RichTextBox();
            backBtn = new Button();
            langBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.Location = new Point(121, 9);
            titleLbl.Margin = new Padding(2, 0, 2, 0);
            titleLbl.MaximumSize = new Size(300, 0);
            titleLbl.MinimumSize = new Size(300, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(300, 41);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Reviews:";
            titleLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // reviewsTB
            // 
            reviewsTB.Enabled = false;
            reviewsTB.Location = new Point(78, 154);
            reviewsTB.Margin = new Padding(2, 2, 2, 2);
            reviewsTB.Name = "reviewsTB";
            reviewsTB.Size = new Size(434, 226);
            reviewsTB.TabIndex = 1;
            reviewsTB.Text = "";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(29, 13);
            backBtn.Margin = new Padding(2, 2, 2, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(78, 20);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(434, 11);
            langBtn.Margin = new Padding(2, 2, 2, 2);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(78, 20);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormViewReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 436);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(reviewsTB);
            Controls.Add(titleLbl);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormViewReview";
            Text = "ViewReview";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            backBtn.Text = rm.GetString("BackButton");
            langBtn.Text = rm.GetString("Lanbutton");
            titleLbl.Text = rm.GetString("Reviews") + " ";
            // For Media
            if (media != null)
            {
                titleLbl.Text += media.Title;
            }
            else
            {
                titleLbl.Text += crewMember.FirstName + " " + crewMember.LastName;
            }
        }

        #endregion

        private Label titleLbl;
        private RichTextBox reviewsTB;
        private Button backBtn;
        private Button langBtn;
    }
}