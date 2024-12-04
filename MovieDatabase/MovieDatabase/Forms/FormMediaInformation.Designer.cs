using System.Resources;

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
            titleLbl.Location = new Point(12, 9);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(108, 60);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Title";
            // 
            // langBtn
            // 
            langBtn.Location = new Point(1258, 50);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 1;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(1126, 50);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(112, 34);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // releaseDate
            // 
            releaseDate.Enabled = false;
            releaseDate.Location = new Point(12, 72);
            releaseDate.Name = "releaseDate";
            releaseDate.Size = new Size(300, 31);
            releaseDate.TabIndex = 3;
            // 
            // mediaPicture
            // 
            mediaPicture.Location = new Point(96, 287);
            mediaPicture.Name = "mediaPicture";
            mediaPicture.Size = new Size(242, 251);
            mediaPicture.TabIndex = 5;
            mediaPicture.TabStop = false;
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Location = new Point(12, 544);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(67, 25);
            ratingLbl.TabIndex = 6;
            ratingLbl.Text = "Rating:";
            // 
            // giveReviewBtn
            // 
            giveReviewBtn.Location = new Point(1209, 137);
            giveReviewBtn.Name = "giveReviewBtn";
            giveReviewBtn.Size = new Size(161, 34);
            giveReviewBtn.TabIndex = 7;
            giveReviewBtn.Text = "Write a review";
            giveReviewBtn.UseVisualStyleBackColor = true;
            giveReviewBtn.Click += giveReviewBtn_Click;
            // 
            // viewReviewBtn
            // 
            viewReviewBtn.Location = new Point(1209, 216);
            viewReviewBtn.Name = "viewReviewBtn";
            viewReviewBtn.Size = new Size(161, 34);
            viewReviewBtn.TabIndex = 8;
            viewReviewBtn.Text = "View reviews";
            viewReviewBtn.UseVisualStyleBackColor = true;
            viewReviewBtn.Click += viewReviewBtn_Click;
            // 
            // watchlistCheckBox
            // 
            watchlistCheckBox.AutoSize = true;
            watchlistCheckBox.Location = new Point(1209, 283);
            watchlistCheckBox.Name = "watchlistCheckBox";
            watchlistCheckBox.Size = new Size(167, 29);
            watchlistCheckBox.TabIndex = 9;
            watchlistCheckBox.Text = "Add to watchlist";
            watchlistCheckBox.UseVisualStyleBackColor = true;
            watchlistCheckBox.CheckedChanged += watchlistCheckBox_CheckedChanged;
            // 
            // directorsLbl
            // 
            directorsLbl.AutoSize = true;
            directorsLbl.Location = new Point(532, 112);
            directorsLbl.Name = "directorsLbl";
            directorsLbl.Size = new Size(83, 25);
            directorsLbl.TabIndex = 10;
            directorsLbl.Text = "Directors";
            // 
            // directorPanel
            // 
            directorPanel.AutoScroll = true;
            directorPanel.AutoSize = true;
            directorPanel.FlowDirection = FlowDirection.TopDown;
            directorPanel.Location = new Point(435, 156);
            directorPanel.Name = "directorPanel";
            directorPanel.Size = new Size(248, 764);
            directorPanel.TabIndex = 11;
            // 
            // synopsisTB
            // 
            synopsisTB.Enabled = false;
            synopsisTB.Location = new Point(12, 109);
            synopsisTB.Name = "synopsisTB";
            synopsisTB.Size = new Size(417, 172);
            synopsisTB.TabIndex = 12;
            synopsisTB.Text = "";
            // 
            // actorsLbl
            // 
            actorsLbl.AutoSize = true;
            actorsLbl.Location = new Point(844, 112);
            actorsLbl.Name = "actorsLbl";
            actorsLbl.Size = new Size(63, 25);
            actorsLbl.TabIndex = 13;
            actorsLbl.Text = "Actors";
            // 
            // actorPanel
            // 
            actorPanel.Location = new Point(706, 154);
            actorPanel.Name = "actorPanel";
            actorPanel.Size = new Size(404, 778);
            actorPanel.TabIndex = 14;
            // 
            // genrePanel
            // 
            genrePanel.Location = new Point(12, 595);
            genrePanel.Name = "genrePanel";
            genrePanel.Size = new Size(417, 126);
            genrePanel.TabIndex = 15;
            // 
            // episodePanel
            // 
            episodePanel.Location = new Point(1116, 419);
            episodePanel.Name = "episodePanel";
            episodePanel.Size = new Size(360, 513);
            episodePanel.TabIndex = 16;
            // 
            // episodeLbl
            // 
            episodeLbl.AutoSize = true;
            episodeLbl.Location = new Point(1232, 378);
            episodeLbl.Name = "episodeLbl";
            episodeLbl.Size = new Size(83, 25);
            episodeLbl.TabIndex = 17;
            episodeLbl.Text = "Episodes";
            episodeLbl.Visible = false;
            // 
            // FormMediaInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1472, 932);
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
            Name = "FormMediaInformation";
            Text = "FormMediaLoad";
            ((System.ComponentModel.ISupportInitialize)mediaPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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