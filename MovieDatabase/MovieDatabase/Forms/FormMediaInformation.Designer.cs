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
            listOfCrewLabel = new Label();
            crewLayoutPanel = new FlowLayoutPanel();
            synopsisTB = new RichTextBox();
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
            langBtn.Location = new Point(935, 12);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 1;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(811, 12);
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
            mediaPicture.Location = new Point(77, 287);
            mediaPicture.Name = "mediaPicture";
            mediaPicture.Size = new Size(177, 251);
            mediaPicture.TabIndex = 5;
            mediaPicture.TabStop = false;
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Location = new Point(29, 539);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(67, 25);
            ratingLbl.TabIndex = 6;
            ratingLbl.Text = "Rating:";
            // 
            // giveReviewBtn
            // 
            giveReviewBtn.Location = new Point(886, 172);
            giveReviewBtn.Name = "giveReviewBtn";
            giveReviewBtn.Size = new Size(161, 34);
            giveReviewBtn.TabIndex = 7;
            giveReviewBtn.Text = "Write a review";
            giveReviewBtn.UseVisualStyleBackColor = true;
            giveReviewBtn.Click += giveReviewBtn_Click;
            // 
            // viewReviewBtn
            // 
            viewReviewBtn.Location = new Point(886, 285);
            viewReviewBtn.Name = "viewReviewBtn";
            viewReviewBtn.Size = new Size(151, 34);
            viewReviewBtn.TabIndex = 8;
            viewReviewBtn.Text = "View reviews";
            viewReviewBtn.UseVisualStyleBackColor = true;
            viewReviewBtn.Click += viewReviewBtn_Click;
            // 
            // watchlistCheckBox
            // 
            watchlistCheckBox.AutoSize = true;
            watchlistCheckBox.Location = new Point(880, 435);
            watchlistCheckBox.Name = "watchlistCheckBox";
            watchlistCheckBox.Size = new Size(167, 29);
            watchlistCheckBox.TabIndex = 9;
            watchlistCheckBox.Text = "Add to watchlist";
            watchlistCheckBox.UseVisualStyleBackColor = true;
            watchlistCheckBox.CheckedChanged += watchlistCheckBox_CheckedChanged;
            // 
            // listOfCrewLabel
            // 
            listOfCrewLabel.AutoSize = true;
            listOfCrewLabel.Location = new Point(533, 109);
            listOfCrewLabel.Name = "listOfCrewLabel";
            listOfCrewLabel.Size = new Size(181, 25);
            listOfCrewLabel.TabIndex = 10;
            listOfCrewLabel.Text = "List of crew members";
            // 
            // crewLayoutPanel
            // 
            crewLayoutPanel.AutoSize = true;
            crewLayoutPanel.Location = new Point(444, 156);
            crewLayoutPanel.Name = "crewLayoutPanel";
            crewLayoutPanel.Size = new Size(369, 408);
            crewLayoutPanel.TabIndex = 11;
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
            // FormMediaInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 589);
            Controls.Add(synopsisTB);
            Controls.Add(crewLayoutPanel);
            Controls.Add(listOfCrewLabel);
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
            titleLbl.Text = rm.GetString("Title");
            langBtn.Text = rm.GetString("LanButton");
            backBtn.Text = rm.GetString("BackButton");
            ratingLbl.Text = rm.GetString("Rating");
            giveReviewBtn.Text = rm.GetString("WriteReview");
            viewReviewBtn.Text = rm.GetString("ViewReviews");
            watchlistCheckBox.Text = rm.GetString("AddToWatchList");
            listOfCrewLabel.Text = rm.GetString("ListOfCrewMembers");
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
        private Label listOfCrewLabel;
        private FlowLayoutPanel crewLayoutPanel;
        private RichTextBox synopsisTB;
    }
}