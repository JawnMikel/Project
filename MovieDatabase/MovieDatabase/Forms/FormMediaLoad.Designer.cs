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
            mediaLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(11, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(121, 38);
            backBtn.TabIndex = 0;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // mediaLayout
            // 
            mediaLayout.AutoScroll = true;
            mediaLayout.Location = new Point(0, 56);
            mediaLayout.Name = "mediaLayout";
            mediaLayout.Size = new Size(917, 517);
            mediaLayout.TabIndex = 1;
            // 
            // FormMediaLoad
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 573);
            Controls.Add(mediaLayout);
            Controls.Add(backBtn);
            Name = "FormMediaLoad";
            Text = "FormMediaLoad";
            ResumeLayout(false);
        }

        #endregion

        private Button backBtn;
        private FlowLayoutPanel mediaLayout;
    }
}