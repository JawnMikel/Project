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
using MovieDatabase.Model;
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
                DatabaseUtils database = DatabaseUtils.GetInstance();
                user.WatchList = database.GetUserWatchList(user.Id);
                database.CloseConnection();
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

        /// <summary>
        /// Updates the language and keeps the rating grade
        /// </summary>
        private void UpdateRatingLabel()
        {
            string baseText = messages.Rating;
            double rating = media.GetMediaRating();
            if (rating > 0)
            {
                ratingLbl.Text = $"{baseText} {media.GetMediaRating()}/5";
            }
            else
            {
                ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
                string ratingUnavailableText = rm.GetString("RatingUnavailable");
                ratingLbl.Text = $"{baseText} {ratingUnavailableText}";
            }
        }

        /// <summary>
        /// Loads its genres by the media
        /// </summary>
        /// <param name="media">Media</param>
        private void LoadGenres(Media media)
        {
            genrePanel.Controls.Clear();

            var genreTranslations = Util.GenerateGenreTranslation();

            foreach (Media.Genre genre in media.Genres)
            {
                Label genreLabel = new Label
                {
                    Text = genre.ToString(),
                    Tag = genre,
                    AutoSize = true,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                if (genreTranslations.TryGetValue(genre.ToString(), out var translatedGenre))
                {
                    genreLabel.Text = translatedGenre;
                }

                genreLabel.Click += (s, args) => OpenMediaLoad((Media.Genre)genreLabel.Tag);

                
                genrePanel.Controls.Add(genreLabel);
            }
        }

        /// <summary>
        /// Updates the genre's language by using a dictionnary
        /// </summary>
        private void UpdateGenresLanguage()
        {
            var genreTranslations = Util.GenerateGenreTranslation();

            foreach (Control control in genrePanel.Controls)
            {
                if (control is Label genreLabel)
                {
                    Media.Genre genre = (Media.Genre)genreLabel.Tag;

                    if (genreTranslations.TryGetValue(genre.ToString(), out var translatedGenre))
                    {
                        genreLabel.Text = translatedGenre;  
                    }
                    else
                    {
                        genreLabel.Text = genre.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Opens the Media Load frame by taking a genre
        /// </summary>
        /// <param name="genre"></param>
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

        /// <summary>
        /// Loads the episodes of the tvshow
        /// </summary>
        /// <param name="tvshow">Tv show</param>
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

        /// <summary>
        /// Opens the media form for the episodes
        /// </summary>
        /// <param name="episode">Episode</param>
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
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            if (watchlistCheckBox.Checked)
            {
                if (!user.WatchList.Any(m => m.MediaId == media.MediaId))
                {
                    user.AddMediaToWatchList(media);

                    if (media is Movie)
                    {
                        database.InsertWatchListMovie(user.Id, media.MediaId);
                    }
                    else if (media is TVShow)
                    {
                        database.InsertWatchListTVShow(user.Id, media.MediaId);
                    }
                    string message = rm.GetString("AddToWatchListMessage");
                    string title = rm.GetString("AddToWatchListTitle");
                    MessageBox.Show($"{media.Title} {message}",
                                    title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                var mediaToRemove = user.WatchList.FirstOrDefault(m => m.MediaId == media.MediaId);
                if (mediaToRemove != null)
                {
                    user.RemoveMediaFromWatchList(mediaToRemove);
                    if (media is Movie)
                    {
                        database.DeleteFromUserWatchlist(user, (Movie)media);
                    }
                    else if (media is TVShow)
                    {
                        database.DeleteFromUserWatchlist(user, (TVShow)media);
                    }

                    string message = rm.GetString("RemoveFromWatchListMessage");
                    string title = rm.GetString("RemoveFromWatchListTitle");
                    MessageBox.Show($"{media.Title} {message}",
                                    title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            database.CloseConnection();
        }
    }
}
