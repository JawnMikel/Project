using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormMediaInformation : Form
    {
        Form form;
        Media media;
        User user;
        public FormMediaInformation(Form form, Media media, User user)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
            this.media = media;
            this.form = form;
            this.user = user;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Synopsis;
            ratingLbl.Text += media.GetMediaRating() + "/5";
            watchlistCheckBox.Checked = user.WatchList.Contains(media);
            watchlistCheckBox.CheckedChanged += watchlistCheckBox_CheckedChanged;
        }
        public FormMediaInformation(Media media, User user)
        {
            InitializeComponent();
            this.user = user;
            this.media = media;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Synopsis;
            ratingLbl.Text += media.GetMediaRating() + "/5";
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void giveReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var formViewReview = new FormViewReview(media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var formViewReview = new FormViewReview(media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void watchlistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (watchlistCheckBox.Checked)
            {
                if (!user.WatchList.Contains(media))
                {
                    user.WatchList.Add(media);
                    MessageBox.Show($"{media.Title} has been added to your watchlist.", "Watchlist Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (user.WatchList.Contains(media))
                {
                    user.WatchList.Remove(media);
                    MessageBox.Show($"{media.Title} has been removed from your watchlist.", "Watchlist Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
