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
            label1 = new Label();
            textBox1 = new TextBox();
            postBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.Location = new Point(353, 9);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 111);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 2;
            label1.Text = "Ratings:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(397, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(68, 31);
            textBox1.TabIndex = 3;
            // 
            // postBtn
            // 
            postBtn.Location = new Point(353, 400);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(112, 34);
            postBtn.TabIndex = 4;
            postBtn.Text = "Post";
            postBtn.UseVisualStyleBackColor = true;
            postBtn.Click += postBtn_Click;
            // 
            // FormWriteReview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(postBtn);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(reviewTB);
            Controls.Add(titleLbl);
            Name = "FormWriteReview";
            Text = "FormWriteReview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
        private RichTextBox reviewTB;
        private Label label1;
        private TextBox textBox1;
        private Button postBtn;
    }
}