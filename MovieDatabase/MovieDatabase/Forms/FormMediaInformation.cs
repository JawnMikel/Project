using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using MovieDatabase.message;
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
            
            this.media = media;
            this.form = form;
            this.user = user;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            synopsisTB.Text = media.Synopsis;
            

            UpdateRatingLabel();
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
            LoadGenres(media);
            if (media is TVShow)
            {
                episodeLbl.Visible = true;
                LoadEpisodes((TVShow)media);
            }
            Update();
            UpdateRatingLabel();

        }
        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
            UpdateRatingLabel();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new FormMainMenu(user);
            mainMenu.Closed += (s, args) => this.Close();
            mainMenu.Show();
        }

        private void giveReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormWriteReview(this, media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormViewReview(this, media, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void watchlistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WatchListControl();
        }

        private void UpdateRatingLabel()
        {
            string baseText = messages.Rating;
            ratingLbl.Text = $"{baseText} {media.GetMediaRating()}/5";
        }

        private void LoadGenres(Media media)
        {
            genrePanel.Controls.Clear();

            // Get the genre translations dictionary (translated genre name => Media.Genre)
            var genreTranslations = Util.GenerateGenreTranslation();

            foreach (Media.Genre genre in media.Genres)
            {
                // Create a label for each genre
                Label genreLabel = new Label
                {
                    Text = genre.ToString(),  // Initially use the default genre name
                    Tag = genre,  // Store the enum in the Tag
                    AutoSize = true,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                // Try to get the translation for the genre in the current language
                if (genreTranslations.TryGetValue(genre.ToString(), out var translatedGenre))
                {
                    // Set the translated genre name
                    genreLabel.Text = translatedGenre;  // Set the label to the translated genre string
                }

                // Add a click event handler to open the media load form (you can modify this as needed)
                genreLabel.Click += (s, args) => OpenMediaLoad((Media.Genre)genreLabel.Tag);

                // Add the label to the panel
                genrePanel.Controls.Add(genreLabel);
            }
        }

        private void UpdateGenresLanguage()
        {
            // Get the genre translations (this should return a dictionary with genre name as key and translation as value)
            var genreTranslations = Util.GenerateGenreTranslation();

            // Iterate through the controls in the genrePanel (which are labels for each genre)
            foreach (Control control in genrePanel.Controls)
            {
                if (control is Label genreLabel)
                {
                    Media.Genre genre = (Media.Genre)genreLabel.Tag; // Retrieve the genre from the Tag property

                    // Try to get the translation for the genre in the current language
                    if (genreTranslations.TryGetValue(genre.ToString(), out var translatedGenre))
                    {
                        // Update label with the translated genre name
                        genreLabel.Text = translatedGenre;  // Update the label with the translated genre name (string)
                    }
                    else
                    {
                        // If no translation exists, keep the original genre name
                        genreLabel.Text = genre.ToString();  // Default to the original genre name
                    }
                }
            }
        }



        private void OpenMediaLoad(Media.Genre genre)
        {
            this.Hide();
            var mediaLoad = new FormMediaLoad(genre, this, user);
            mediaLoad.Closed += (s, args) => this.Close();
            mediaLoad.ShowDialog();
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
                    ImageLocation = actor.ImageLink,
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
            directorPanel.Controls.Clear();
            foreach (var director in media.Directors)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = director.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenCrewInfo(director);

                directorPanel.Controls.Add(pictureBox);
            }
        }

        private void LoadEpisodes(TVShow tvshow)
        {
            episodePanel.Controls.Clear();
            
            foreach (Episode episode in tvshow.Episodes)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = episode.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenMediaForm(episode);

                episodePanel.Controls.Add(pictureBox);
            }
        }

        private void OpenMediaForm(Episode episode)
        {
            
            this.Hide();
            var mediaInformationForm = new FormMediaInformation(this, episode, user);
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
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
            var mediaInformationForm = new FormCrewMemberInformation(currentForm, crewMember, user, media);
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
