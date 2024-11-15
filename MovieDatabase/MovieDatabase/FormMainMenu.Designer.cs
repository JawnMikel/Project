namespace MovieDatabase
{
    partial class FormMainMenu
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
            recBtn = new Button();
            top10Btn = new Button();
            moviesBtn = new Button();
            tvshowBtn = new Button();
            genreBtn = new Button();
            searchTB = new TextBox();
            profileBtn = new Button();
            SuspendLayout();
            // 
            // recBtn
            // 
            recBtn.Location = new Point(12, 12);
            recBtn.Name = "recBtn";
            recBtn.Size = new Size(168, 34);
            recBtn.TabIndex = 0;
            recBtn.Text = "Recommendation";
            recBtn.UseVisualStyleBackColor = true;
            // 
            // top10Btn
            // 
            top10Btn.Location = new Point(198, 12);
            top10Btn.Name = "top10Btn";
            top10Btn.Size = new Size(112, 34);
            top10Btn.TabIndex = 1;
            top10Btn.Text = "Top 10";
            top10Btn.UseVisualStyleBackColor = true;
            // 
            // moviesBtn
            // 
            moviesBtn.Location = new Point(328, 12);
            moviesBtn.Name = "moviesBtn";
            moviesBtn.Size = new Size(112, 34);
            moviesBtn.TabIndex = 2;
            moviesBtn.Text = "Movies";
            moviesBtn.UseVisualStyleBackColor = true;
            // 
            // tvshowBtn
            // 
            tvshowBtn.Location = new Point(459, 12);
            tvshowBtn.Name = "tvshowBtn";
            tvshowBtn.Size = new Size(112, 34);
            tvshowBtn.TabIndex = 3;
            tvshowBtn.Text = "Tv Shows";
            tvshowBtn.UseVisualStyleBackColor = true;
            // 
            // genreBtn
            // 
            genreBtn.Location = new Point(588, 12);
            genreBtn.Name = "genreBtn";
            genreBtn.Size = new Size(112, 34);
            genreBtn.TabIndex = 4;
            genreBtn.Text = "Genres";
            genreBtn.UseVisualStyleBackColor = true;
            // 
            // searchTB
            // 
            searchTB.Location = new Point(716, 12);
            searchTB.Name = "searchTB";
            searchTB.Size = new Size(228, 31);
            searchTB.TabIndex = 5;
            // 
            // profileBtn
            // 
            profileBtn.Location = new Point(960, 12);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(191, 34);
            profileBtn.TabIndex = 6;
            profileBtn.UseVisualStyleBackColor = true;
            profileBtn.Click += profileBtn_Click;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 593);
            Controls.Add(profileBtn);
            Controls.Add(searchTB);
            Controls.Add(genreBtn);
            Controls.Add(tvshowBtn);
            Controls.Add(moviesBtn);
            Controls.Add(top10Btn);
            Controls.Add(recBtn);
            Name = "FormMainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button recBtn;
        private Button top10Btn;
        private Button moviesBtn;
        private Button tvshowBtn;
        private Button genreBtn;
        private TextBox searchTB;
        private Button profileBtn;
    }
}