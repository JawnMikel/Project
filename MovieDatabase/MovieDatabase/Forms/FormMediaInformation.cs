using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Loader;
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

        // private readonly List<Media> mediaList = DatabaseUtils.GetInstance().GetAllMedia();
        //private readonly List<Actor> actors = DatabaseUtils.GetInstance().GetAllActors();

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

            LoadPhoto(media);
            LoadActors(media);
            LoadDirector(media);

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
            WatchListControl();
        }

        /// <summary>
        /// Loads all the actors from the database
        /// </summary>
        /// <param name="media">Media</param>
        private void LoadActors(Media media)
        {
            actorPanel.Controls.Clear();
            foreach (var actor in media.Actors)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = media.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenCrewInfo(actor);

                actorPanel.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// Loads all the directors from the database
        /// </summary>
        /// <param name="media">media</param>
        private void LoadDirector(Media media)
        {
            actorPanel.Controls.Clear();
            foreach (var director in media.Directors)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = media.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenCrewInfo(director);

                directorPanel.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// Loads the photo of the media
        /// </summary>
        /// <param name="media"></param>
        private void LoadPhoto(Media media)
        {
            mediaPicture.Controls.Clear();
            
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = media.ImageLink,
                    Width = 250,
                    Height = 300,
                    Margin = new Padding(10)
                };

                mediaPicture.Controls.Add(pictureBox);
        }

        /// <summary>
        /// Opens the crew member form by needing a crew member
        /// </summary>
        /// <param name="crewMember">crew member</param>
        private void OpenCrewInfo(CrewMember crewMember)
        {
            var currentForm = this;
            var mediaInformationForm = new FormCrewMemberInformation(currentForm, crewMember, user);
            this.Hide();
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }

        /// <summary>
        /// Adds a movie to watch list
        /// </summary>
        private void WatchListControl()
        {
            var database = DatabaseUtils.GetInstance();

            if (watchlistCheckBox.Checked)
            {
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
