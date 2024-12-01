using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
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
            InitializeComponent();
            Update();
            this.media = media;
            this.form = form;
            this.user = user;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            synopsisTB.Text = media.Synopsis;
            ratingLbl.Text += media.GetMediaRating() + "/5";

            if (media is Episode)
            {
                watchlistCheckBox.Enabled = false;
            }
            else
            {
                user.WatchList = DatabaseUtils.GetInstance().GetUserWatchList(user.Id);
                watchlistCheckBox.Checked = user.WatchList.Any(m => m.MediaId == media.MediaId);
                watchlistCheckBox.CheckedChanged += watchlistCheckBox_CheckedChanged;
            }
        }
        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void giveReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormWriteReview(form, media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormViewReview(form, media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void watchlistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var database = DatabaseUtils.GetInstance();

            if (watchlistCheckBox.Checked)
            {
                // Add to watchlist only if it isn't already present
                if (!user.WatchList.Any(m => m.MediaId == media.MediaId))
                {
                    user.WatchList.Add(media);

                    if (media is Movie)
                    {
                        database.InsertWatchListMovie(user.Id, media.MediaId);
                    }
                    else if (media is TVShow)
                    {
                        database.InsertWatchListTVShow(user.Id, media.MediaId);
                    }

                    MessageBox.Show($"{media.Title} has been added to your watchlist.",
                                    "Watchlist Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Remove from watchlist if it exists
                var mediaToRemove = user.WatchList.FirstOrDefault(m => m.MediaId == media.MediaId);
                if (mediaToRemove != null)
                {
                    user.WatchList.Remove(mediaToRemove);

                    MessageBox.Show($"{media.Title} has been removed from your watchlist.",
                                    "Watchlist Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
