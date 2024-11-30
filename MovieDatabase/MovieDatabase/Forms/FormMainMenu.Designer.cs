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
            langBtn = new Button();
            SuspendLayout();
            // 
            // recBtn
            // 
            recBtn.Location = new Point(17, 16);
            recBtn.Margin = new Padding(2, 2, 2, 2);
            recBtn.Name = "recBtn";
            recBtn.Size = new Size(118, 22);
            recBtn.TabIndex = 0;
            recBtn.Text = "Recommendation";
            recBtn.UseVisualStyleBackColor = true;
            recBtn.Click += recBtn_Click;
            // 
            // top10Btn
            // 
            top10Btn.Location = new Point(139, 15);
            top10Btn.Margin = new Padding(2, 2, 2, 2);
            top10Btn.Name = "top10Btn";
            top10Btn.Size = new Size(78, 23);
            top10Btn.TabIndex = 1;
            top10Btn.Text = "Top 10";
            top10Btn.UseVisualStyleBackColor = true;
            top10Btn.Click += top10Btn_Click;
            // 
            // moviesBtn
            // 
            moviesBtn.Location = new Point(221, 15);
            moviesBtn.Margin = new Padding(2, 2, 2, 2);
            moviesBtn.Name = "moviesBtn";
            moviesBtn.Size = new Size(57, 26);
            moviesBtn.TabIndex = 2;
            moviesBtn.Text = "Movies";
            moviesBtn.UseVisualStyleBackColor = true;
            moviesBtn.Click += moviesBtn_Click;
            // 
            // tvshowBtn
            // 
            tvshowBtn.Location = new Point(282, 16);
            tvshowBtn.Margin = new Padding(2, 2, 2, 2);
            tvshowBtn.Name = "tvshowBtn";
            tvshowBtn.Size = new Size(78, 25);
            tvshowBtn.TabIndex = 3;
            tvshowBtn.Text = "Tv Shows";
            tvshowBtn.UseVisualStyleBackColor = true;
            tvshowBtn.Click += tvshowBtn_Click;
            // 
            // searchTB
            // 
            searchTB.Location = new Point(519, 16);
            searchTB.Margin = new Padding(2, 2, 2, 2);
            searchTB.Name = "searchTB";
            searchTB.Size = new Size(161, 23);
            searchTB.TabIndex = 5;
            searchTB.TextChanged += searchTB_TextChanged;
            // 
            // profileBtn
            // 
            profileBtn.Location = new Point(684, 11);
            profileBtn.Margin = new Padding(2, 2, 2, 2);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(128, 30);
            profileBtn.TabIndex = 6;
            profileBtn.UseVisualStyleBackColor = true;
            profileBtn.Click += profileBtn_Click;
            // 
            // genreBox
            // 
            genreBox.FormattingEnabled = true;
            genreBox.Items.AddRange(new object[] { "ACTION", "ANIMATION", "COMEDY", "CRIME", "DOCUMENTARY", "DRAMA", "FANTASY", "HORROR", "MUSICAL", "MYSTERY", "ROMANCE", "SCI_FI", "SUPERHERO", "THRILLER", "WAR" });
            genreBox.Location = new Point(372, 16);
            genreBox.Margin = new Padding(2, 2, 2, 2);
            genreBox.Name = "genreBox";
            genreBox.Size = new Size(129, 23);
            genreBox.TabIndex = 7;
            genreBox.SelectedIndexChanged += genreBox_SelectedIndexChanged;
            // 
            // mediaLayout
            // 
            mediaLayout.AutoScroll = true;
            mediaLayout.Dock = DockStyle.Bottom;
            mediaLayout.Location = new Point(0, 70);
            mediaLayout.Margin = new Padding(2, 2, 2, 2);
            mediaLayout.Name = "mediaLayout";
            mediaLayout.Size = new Size(823, 318);
            mediaLayout.TabIndex = 8;
            // 
            // button1
            // 
            langBtn.Location = new Point(687, 42);
            langBtn.Name = "button1";
            langBtn.Size = new Size(124, 23);
            langBtn.TabIndex = 9;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 388);
            Controls.Add(langBtn);
            Controls.Add(mediaLayout);
            Controls.Add(genreBox);
            Controls.Add(profileBtn);
            Controls.Add(searchTB);
            Controls.Add(tvshowBtn);
            Controls.Add(moviesBtn);
            Controls.Add(top10Btn);
            Controls.Add(recBtn);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormMainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            recBtn.Text = rm.GetString("Recommendation");
            moviesBtn.Text = rm.GetString("Movies");
            tvshowBtn.Text = rm.GetString("TvShows");
            langBtn.Text = rm.GetString("Lanbutton");
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
        private Button langBtn;
    }
}