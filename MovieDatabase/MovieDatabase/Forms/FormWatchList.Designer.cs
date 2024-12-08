using System.Resources;

namespace MovieDatabase
{
    partial class FormWatchList
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
            watchListLbl = new Label();
            watchlistLayout = new FlowLayoutPanel();
            backBtn = new Button();
            langBtn = new Button();
            SuspendLayout();
            // 
            // watchListLbl
            // 
            watchListLbl.AutoSize = true;
            watchListLbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            watchListLbl.Location = new Point(253, 9);
            watchListLbl.Name = "watchListLbl";
            watchListLbl.Size = new Size(244, 65);
            watchListLbl.TabIndex = 0;
            watchListLbl.Text = "Watch List";
            // 
            // watchlistLayout
            // 
            watchlistLayout.Dock = DockStyle.Bottom;
            watchlistLayout.Location = new Point(0, 77);
            watchlistLayout.Name = "watchlistLayout";
            watchlistLayout.Size = new Size(863, 468);
            watchlistLayout.TabIndex = 1;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(27, 23);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(132, 36);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // langBtn
            // 
            langBtn.Location = new Point(695, 25);
            langBtn.Name = "langBtn";
            langBtn.Size = new Size(133, 34);
            langBtn.TabIndex = 3;
            langBtn.Text = "French";
            langBtn.UseVisualStyleBackColor = true;
            langBtn.Click += langBtn_Click;
            // 
            // FormWatchList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 545);
            Controls.Add(langBtn);
            Controls.Add(backBtn);
            Controls.Add(watchlistLayout);
            Controls.Add(watchListLbl);
            Name = "FormWatchList";
            Text = "FormWatchList";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Updates the language by using the ResourceManager
        /// </summary>
        public void Update()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            watchListLbl.Text = rm.GetString("WatchListTitle");
            backBtn.Text = rm.GetString("BackButton");
            langBtn.Text = rm.GetString("Lanbutton");
        }

        #endregion

        private Label watchListLbl;
        private FlowLayoutPanel watchlistLayout;
        private Button backBtn;
        private Button langBtn;
    }
}