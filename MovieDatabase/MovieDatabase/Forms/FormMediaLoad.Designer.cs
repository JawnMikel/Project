namespace MovieDatabase
{
    partial class FormMediaLoad
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
            backBtn = new Button();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(8, 7);
            backBtn.Margin = new Padding(2, 2, 2, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(85, 23);
            backBtn.TabIndex = 0;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // FormMediaLoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(backBtn);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormMediaLoad";
            Text = "FormMediaLoad";
            ResumeLayout(false);
        }

        #endregion

        private Button backBtn;
    }
}