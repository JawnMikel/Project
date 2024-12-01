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
            titleLbl.Location = new Point(150, 9);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(189, 60);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Reviews:";
            // 
            // reviewsTB
            // 
            reviewsTB.Enabled = false;
            reviewsTB.Location = new Point(105, 88);
            reviewsTB.Name = "reviewsTB";
            reviewsTB.Size = new Size(618, 374);
            reviewsTB.TabIndex = 1;
            reviewsTB.Text = "";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(41, 21);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(112, 34);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(620, 18);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormViewReview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 519);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(reviewsTB);
            Controls.Add(titleLbl);
            Name = "FormViewReview";
            Text = "ViewReview";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            titleLbl.Text = rm.GetString("Reviews");
            backBtn.Text = rm.GetString("BackButton");
            langBtn.Text = rm.GetString("Lanbutton");
        }

        #endregion

        private Label titleLbl;
        private RichTextBox reviewsTB;
        private Button backBtn;
        private Button langBtn;
    }
}