using System.Reflection;
using System.Resources;

namespace MovieDatabase
{
    partial class FormCrewMemberInformation
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
            nameLbl = new Label();
            ratingLbl = new Label();
            backBtn = new Button();
            langBtn = new Button();
            writeReviewBtn = new Button();
            viewReviewBtn = new Button();
            portraitFlowPanel = new FlowLayoutPanel();
            mediaFlowPanel = new FlowLayoutPanel();
            listMediaLbl = new Label();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameLbl.Location = new Point(12, 9);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(154, 65);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Name";
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Location = new Point(24, 125);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(67, 25);
            ratingLbl.TabIndex = 1;
            ratingLbl.Text = "Rating:";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(672, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(112, 34);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(841, 12);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(112, 34);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // writeReviewBtn
            // 
            writeReviewBtn.Location = new Point(797, 106);
            writeReviewBtn.Name = "writeReviewBtn";
            writeReviewBtn.Size = new Size(156, 34);
            writeReviewBtn.TabIndex = 4;
            writeReviewBtn.Text = "Write a review";
            writeReviewBtn.UseVisualStyleBackColor = true;
            writeReviewBtn.Click += wirteReviewBtn_Click;
            // 
            // viewReviewBtn
            // 
            viewReviewBtn.Location = new Point(797, 212);
            viewReviewBtn.Name = "viewReviewBtn";
            viewReviewBtn.Size = new Size(156, 34);
            viewReviewBtn.TabIndex = 5;
            viewReviewBtn.Text = "View reviews";
            viewReviewBtn.UseVisualStyleBackColor = true;
            viewReviewBtn.Click += viewReviewBtn_Click;
            // 
            // portraitFlowPanel
            // 
            portraitFlowPanel.AutoScroll = true;
            portraitFlowPanel.Location = new Point(12, 184);
            portraitFlowPanel.Name = "portraitFlowPanel";
            portraitFlowPanel.Size = new Size(227, 209);
            portraitFlowPanel.TabIndex = 6;
            // 
            // mediaFlowPanel
            // 
            mediaFlowPanel.Location = new Point(257, 147);
            mediaFlowPanel.Name = "mediaFlowPanel";
            mediaFlowPanel.Size = new Size(527, 433);
            mediaFlowPanel.TabIndex = 7;
            // 
            // listMediaLbl
            // 
            listMediaLbl.AutoSize = true;
            listMediaLbl.Location = new Point(414, 95);
            listMediaLbl.Name = "listMediaLbl";
            listMediaLbl.Size = new Size(122, 25);
            listMediaLbl.TabIndex = 8;
            listMediaLbl.Text = "List of medias";
            // 
            // FormCrewMemberInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 592);
            Controls.Add(listMediaLbl);
            Controls.Add(mediaFlowPanel);
            Controls.Add(portraitFlowPanel);
            Controls.Add(viewReviewBtn);
            Controls.Add(writeReviewBtn);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(ratingLbl);
            Controls.Add(nameLbl);
            Name = "FormCrewMemberInformation";
            Text = "CrewMemberInformation";
            ResumeLayout(false);
            PerformLayout();
        }

        public void Update()
        {
           ResourceManager rm = new ResourceManager("MovieDatabase.message.messages",typeof(Program).Assembly);
           nameLbl.Text = rm.GetString("Name");
           backBtn.Text = rm.GetString("BackButton");
           ratingLbl.Text = rm.GetString("Rating");
           langBtn.Text = rm.GetString("LanButton");
           writeReviewBtn.Text = rm.GetString("WriteReview");
           viewReviewBtn.Text = rm.GetString("ViewReviews"); 
        }

        #endregion

        private Label nameLbl;
        private Label ratingLbl;
        private Button backBtn;
        private Button langBtn;
        private Button writeReviewBtn;
        private Button viewReviewBtn;
        private FlowLayoutPanel portraitFlowPanel;
        private FlowLayoutPanel mediaFlowPanel;
        private Label listMediaLbl;
    }
}