using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;

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
            recBtn.Location = new Point(24, 27);
            recBtn.Name = "recBtn";
            recBtn.Size = new Size(169, 37);
            recBtn.TabIndex = 0;
            recBtn.Text = "Recommendation";
            recBtn.UseVisualStyleBackColor = true;
            recBtn.Click += recBtn_Click;
            // 
            // top10Btn
            // 
            top10Btn.Location = new Point(199, 25);
            top10Btn.Name = "top10Btn";
            top10Btn.Size = new Size(111, 38);
            top10Btn.TabIndex = 1;
            top10Btn.Text = "Top 10";
            top10Btn.UseVisualStyleBackColor = true;
            top10Btn.Click += top10Btn_Click;
            // 
            // moviesBtn
            // 
            moviesBtn.Location = new Point(316, 25);
            moviesBtn.Name = "moviesBtn";
            moviesBtn.Size = new Size(81, 43);
            moviesBtn.TabIndex = 2;
            moviesBtn.Text = "Movies";
            moviesBtn.UseVisualStyleBackColor = true;
            moviesBtn.Click += moviesBtn_Click;
            // 
            // tvshowBtn
            // 
            tvshowBtn.Location = new Point(403, 27);
            tvshowBtn.Name = "tvshowBtn";
            tvshowBtn.Size = new Size(111, 42);
            tvshowBtn.TabIndex = 3;
            tvshowBtn.Text = "Tv Shows";
            tvshowBtn.UseVisualStyleBackColor = true;
            tvshowBtn.Click += tvshowBtn_Click;
            // 
            // searchTB
            // 
            searchTB.Location = new Point(741, 27);
            searchTB.Name = "searchTB";
            searchTB.Size = new Size(228, 31);
            searchTB.TabIndex = 5;
            searchTB.TextChanged += searchTB_TextChanged;
            // 
            // profileBtn
            // 
            profileBtn.Location = new Point(977, 18);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(183, 50);
            profileBtn.TabIndex = 6;
            profileBtn.UseVisualStyleBackColor = true;
            profileBtn.Click += profileBtn_Click;
            // 
            // genreBox
            // 
            genreBox.FormattingEnabled = true;
            genreBox.Items.AddRange(new object[] { "ACTION", "ANIMATION", "COMEDY", "CRIME", "DOCUMENTARY", "DRAMA", "FANTASY", "HORROR", "MUSICAL", "MYSTERY", "ROMANCE", "SCI_FI", "SUPERHERO", "THRILLER", "WAR" });
            genreBox.Location = new Point(531, 27);
            genreBox.Name = "genreBox";
            genreBox.Size = new Size(183, 33);
            genreBox.TabIndex = 7;
            genreBox.SelectedIndexChanged += genreBox_SelectedIndexChanged;
            // 
            // mediaLayout
            // 
            mediaLayout.AutoScroll = true;
            mediaLayout.Dock = DockStyle.Bottom;
            mediaLayout.Location = new Point(0, 117);
            mediaLayout.Name = "mediaLayout";
            mediaLayout.Size = new Size(1254, 530);
            mediaLayout.TabIndex = 8;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(981, 70);
            langBtn.Margin = new Padding(4, 5, 4, 5);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(177, 38);
            langBtn.TabIndex = 9;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 647);
            Controls.Add(langBtn);
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

        /// <summary>
        /// Updates the language using ResourceManger and the genres in the combo box
        /// </summary>
        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            recBtn.Text = rm.GetString("Recommendation");
            moviesBtn.Text = rm.GetString("Movies");
            tvshowBtn.Text = rm.GetString("TvShows");
            langBtn.Text = rm.GetString("Lanbutton");

            var genreTranslations = Utils.Util.GenerateGenreTranslations();

            genreBox.Items.Clear();
            foreach (var genre in genreTranslations.Keys)
            {
                genreBox.Items.Add(genre);
            }
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