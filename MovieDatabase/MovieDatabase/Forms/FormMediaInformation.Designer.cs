using MovieDatabase.Utils;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace MovieDatabase
{
    partial class FormMediaInformation
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
            langBtn = new Button();
            backBtn = new Button();
            releaseDate = new DateTimePicker();
            mediaPicture = new PictureBox();
            ratingLbl = new Label();
            giveReviewBtn = new Button();
            viewReviewBtn = new Button();
            watchlistCheckBox = new CheckBox();
            directorsLbl = new Label();
            directorPanel = new FlowLayoutPanel();
            synopsisTB = new RichTextBox();
            actorsLbl = new Label();
            actorPanel = new FlowLayoutPanel();
            genrePanel = new FlowLayoutPanel();
            episodePanel = new FlowLayoutPanel();
            episodeLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)mediaPicture).BeginInit();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.Location = new Point(8, 5);
            titleLbl.Margin = new Padding(2, 0, 2, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(74, 41);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Title";
            // 
            // langBtn
            // 
            langBtn.Location = new Point(881, 30);
            langBtn.Margin = new Padding(2, 2, 2, 2);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(78, 20);
            langBtn.TabIndex = 1;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(788, 30);
            backBtn.Margin = new Padding(2, 2, 2, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(78, 20);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // releaseDate
            // 
            releaseDate.Enabled = false;
            releaseDate.Location = new Point(8, 43);
            releaseDate.Margin = new Padding(2, 2, 2, 2);
            releaseDate.Name = "releaseDate";
            releaseDate.Size = new Size(211, 23);
            releaseDate.TabIndex = 3;
            // 
            // mediaPicture
            // 
            mediaPicture.Location = new Point(57, 172);
            mediaPicture.Margin = new Padding(2, 2, 2, 2);
            mediaPicture.Name = "mediaPicture";
            mediaPicture.Size = new Size(169, 151);
            mediaPicture.TabIndex = 5;
            mediaPicture.TabStop = false;
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Location = new Point(8, 326);
            ratingLbl.Margin = new Padding(2, 0, 2, 0);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(44, 15);
            ratingLbl.TabIndex = 6;
            ratingLbl.Text = "Rating:";
            // 
            // giveReviewBtn
            // 
            giveReviewBtn.Location = new Point(822, 85);
            giveReviewBtn.Margin = new Padding(2, 2, 2, 2);
            giveReviewBtn.Name = "giveReviewBtn";
            giveReviewBtn.Size = new Size(113, 20);
            giveReviewBtn.TabIndex = 7;
            giveReviewBtn.Text = "Write a review";
            giveReviewBtn.UseVisualStyleBackColor = true;
            giveReviewBtn.Click += giveReviewBtn_Click;
            // 
            // viewReviewBtn
            // 
            viewReviewBtn.Location = new Point(822, 126);
            viewReviewBtn.Margin = new Padding(2, 2, 2, 2);
            viewReviewBtn.Name = "viewReviewBtn";
            viewReviewBtn.Size = new Size(113, 20);
            viewReviewBtn.TabIndex = 8;
            viewReviewBtn.Text = "View reviews";
            viewReviewBtn.UseVisualStyleBackColor = true;
            viewReviewBtn.Click += viewReviewBtn_Click;
            // 
            // watchlistCheckBox
            // 
            watchlistCheckBox.AutoSize = true;
            watchlistCheckBox.Location = new Point(822, 172);
            watchlistCheckBox.Margin = new Padding(2, 2, 2, 2);
            watchlistCheckBox.Name = "watchlistCheckBox";
            watchlistCheckBox.Size = new Size(112, 19);
            watchlistCheckBox.TabIndex = 9;
            watchlistCheckBox.Text = "Add to watchlist";
            watchlistCheckBox.UseVisualStyleBackColor = true;
            watchlistCheckBox.CheckedChanged += watchlistCheckBox_CheckedChanged;
            // 
            // directorsLbl
            // 
            directorsLbl.AutoSize = true;
            directorsLbl.Location = new Point(372, 67);
            directorsLbl.Margin = new Padding(2, 0, 2, 0);
            directorsLbl.Name = "directorsLbl";
            directorsLbl.Size = new Size(54, 15);
            directorsLbl.TabIndex = 10;
            directorsLbl.Text = "Directors";
            // 
            // directorPanel
            // 
            directorPanel.AutoScroll = true;
            directorPanel.AutoSize = true;
            directorPanel.FlowDirection = FlowDirection.TopDown;
            directorPanel.Location = new Point(304, 94);
            directorPanel.Margin = new Padding(2, 2, 2, 2);
            directorPanel.Name = "directorPanel";
            directorPanel.Size = new Size(174, 458);
            directorPanel.TabIndex = 11;
            // 
            // synopsisTB
            // 
            synopsisTB.Enabled = false;
            synopsisTB.Location = new Point(8, 65);
            synopsisTB.Margin = new Padding(2, 2, 2, 2);
            synopsisTB.Name = "synopsisTB";
            synopsisTB.Size = new Size(293, 105);
            synopsisTB.TabIndex = 12;
            synopsisTB.Text = "";
            // 
            // actorsLbl
            // 
            actorsLbl.AutoSize = true;
            actorsLbl.Location = new Point(591, 67);
            actorsLbl.Margin = new Padding(2, 0, 2, 0);
            actorsLbl.Name = "actorsLbl";
            actorsLbl.Size = new Size(41, 15);
            actorsLbl.TabIndex = 13;
            actorsLbl.Text = "Actors";
            // 
            // actorPanel
            // 
            actorPanel.AutoScroll = true;
            actorPanel.Location = new Point(494, 92);
            actorPanel.Margin = new Padding(2, 2, 2, 2);
            actorPanel.Name = "actorPanel";
            actorPanel.Size = new Size(283, 467);
            actorPanel.TabIndex = 14;
            // 
            // genrePanel
            // 
            genrePanel.Location = new Point(8, 357);
            genrePanel.Margin = new Padding(2, 2, 2, 2);
            genrePanel.Name = "genrePanel";
            genrePanel.Size = new Size(292, 76);
            genrePanel.TabIndex = 15;
            // 
            // episodePanel
            // 
            episodePanel.AutoScroll = true;
            episodePanel.Location = new Point(781, 251);
            episodePanel.Margin = new Padding(2, 2, 2, 2);
            episodePanel.Name = "episodePanel";
            episodePanel.Size = new Size(252, 308);
            episodePanel.TabIndex = 16;
            // 
            // episodeLbl
            // 
            episodeLbl.AutoSize = true;
            episodeLbl.Location = new Point(862, 227);
            episodeLbl.Margin = new Padding(2, 0, 2, 0);
            episodeLbl.Name = "episodeLbl";
            episodeLbl.Size = new Size(53, 15);
            episodeLbl.TabIndex = 17;
            episodeLbl.Text = "Episodes";
            episodeLbl.Visible = false;
            // 
            // FormMediaInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 559);
            Controls.Add(episodeLbl);
            Controls.Add(episodePanel);
            Controls.Add(genrePanel);
            Controls.Add(actorPanel);
            Controls.Add(actorsLbl);
            Controls.Add(synopsisTB);
            Controls.Add(directorPanel);
            Controls.Add(directorsLbl);
            Controls.Add(watchlistCheckBox);
            Controls.Add(viewReviewBtn);
            Controls.Add(giveReviewBtn);
            Controls.Add(ratingLbl);
            Controls.Add(mediaPicture);
            Controls.Add(releaseDate);
            Controls.Add(backBtn);
            Controls.Add(langBtn);
            Controls.Add(titleLbl);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormMediaInformation";
            Text = "FormMediaLoad";
            ((System.ComponentModel.ISupportInitialize)mediaPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Updates the language by using the ResourceManager and reloads the genres for their translation if they have one
        /// </summary>
        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages",typeof(Program).Assembly);
            langBtn.Text = rm.GetString("Lanbutton");
            backBtn.Text = rm.GetString("BackButton");
            ratingLbl.Text = rm.GetString("Rating");
            giveReviewBtn.Text = rm.GetString("WriteReview");
            viewReviewBtn.Text = rm.GetString("ViewReviews");
            watchlistCheckBox.Text = rm.GetString("AddToWatchList");
            directorsLbl.Text = rm.GetString("Director");
            actorsLbl.Text = rm.GetString("Actor");
            episodeLbl.Text = rm.GetString("Episode");

            LoadGenres(media);
        }

        #endregion

        private Label titleLbl;
        private Button langBtn;
        private Button backBtn;
        private DateTimePicker releaseDate;
        private PictureBox mediaPicture;
        private Label ratingLbl;
        private Button giveReviewBtn;
        private Button viewReviewBtn;
        private CheckBox watchlistCheckBox;
        private Label directorsLbl;
        private FlowLayoutPanel directorPanel;
        private RichTextBox synopsisTB;
        private Label actorsLbl;
        private FlowLayoutPanel actorPanel;
        private FlowLayoutPanel genrePanel;
        private FlowLayoutPanel episodePanel;
        private Label episodeLbl;
    }
}