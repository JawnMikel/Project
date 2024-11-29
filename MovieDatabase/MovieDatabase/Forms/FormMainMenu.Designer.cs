using System.Resources;

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
            searchTB = new TextBox();
            profileBtn = new Button();
            genreBox = new ComboBox();
            mediaLayout = new FlowLayoutPanel();
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
            recBtn.Click += recBtn_Click;
            // 
            // top10Btn
            // 
            top10Btn.Location = new Point(198, 12);
            top10Btn.Name = "top10Btn";
            top10Btn.Size = new Size(112, 34);
            top10Btn.TabIndex = 1;
            top10Btn.Text = "Top 10";
            top10Btn.UseVisualStyleBackColor = true;
            top10Btn.Click += top10Btn_Click;
            // 
            // moviesBtn
            // 
            moviesBtn.Location = new Point(316, 11);
            moviesBtn.Name = "moviesBtn";
            moviesBtn.Size = new Size(82, 35);
            moviesBtn.TabIndex = 2;
            moviesBtn.Text = "Movies";
            moviesBtn.UseVisualStyleBackColor = true;
            moviesBtn.Click += moviesBtn_Click;
            // 
            // tvshowBtn
            // 
            tvshowBtn.Location = new Point(414, 12);
            tvshowBtn.Name = "tvshowBtn";
            tvshowBtn.Size = new Size(112, 34);
            tvshowBtn.TabIndex = 3;
            tvshowBtn.Text = "Tv Shows";
            tvshowBtn.UseVisualStyleBackColor = true;
            tvshowBtn.Click += tvshowBtn_Click;
            // 
            // searchTB
            // 
            searchTB.Location = new Point(730, 13);
            searchTB.Name = "searchTB";
            searchTB.Size = new Size(228, 31);
            searchTB.TabIndex = 5;
            searchTB.TextChanged += searchTB_TextChanged;
            // 
            // profileBtn
            // 
            profileBtn.Location = new Point(981, 13);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(183, 34);
            profileBtn.TabIndex = 6;
            profileBtn.UseVisualStyleBackColor = true;
            profileBtn.Click += profileBtn_Click;
            // 
            // genreBox
            // 
            genreBox.FormattingEnabled = true;
            genreBox.Items.AddRange(new object[] { "ACTION", "ANIMATION", "COMEDY", "CRIME", "DOCUMENTARY", "DRAMA", "FANTASY", "HORROR", "MUSICAL", "MYSTERY", "ROMANCE", "SCI_FI", "SUPERHERO", "THRILLER", "WAR" });
            genreBox.Location = new Point(532, 14);
            genreBox.Name = "genreBox";
            genreBox.Size = new Size(182, 33);
            genreBox.TabIndex = 7;
            genreBox.SelectedIndexChanged += genreBox_SelectedIndexChanged;
            // 
            // mediaLayout
            // 
            mediaLayout.AutoScroll = true;
            mediaLayout.Dock = DockStyle.Bottom;
            mediaLayout.Location = new Point(0, 63);
            mediaLayout.Name = "mediaLayout";
            mediaLayout.Size = new Size(1176, 530);
            mediaLayout.TabIndex = 8;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 593);
            Controls.Add(mediaLayout);
            Controls.Add(genreBox);
            Controls.Add(profileBtn);
            Controls.Add(searchTB);
            Controls.Add(tvshowBtn);
            Controls.Add(moviesBtn);
            Controls.Add(top10Btn);
            Controls.Add(recBtn);
            Name = "FormMainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
            PerformLayout();
        }
        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages",typeof(Program).Assembly);
            recBtn.Text = rm.GetString("Recommendation");
            moviesBtn.Text = rm.GetString("Movies");
            tvshowBtn.Text = rm.GetString("TvShows");
        }

        #endregion

        private Button recBtn;
        private Button top10Btn;
        private Button moviesBtn;
        private Button tvshowBtn;
        private TextBox searchTB;
        private Button profileBtn;
        private ComboBox genreBox;
        private FlowLayoutPanel mediaLayout;
    }
}