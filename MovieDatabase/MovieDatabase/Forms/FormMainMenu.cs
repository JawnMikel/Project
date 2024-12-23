﻿using Microsoft.VisualBasic.ApplicationServices;
using MovieDatabase.Model;
using MovieDatabase.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
    public partial class FormMainMenu : Form
    {
        Form form;
        private Model.User user;

        private readonly List<Media> mediaList;
        public FormMainMenu(Model.User user)
        {
            InitializeComponent();
            Update();

            DatabaseUtils database = DatabaseUtils.GetInstance();
            mediaList = database.GetAllMedia();
            database.CloseConnection();

            this.user = user;
            profileBtn.Text = user.Username;
            if (user.Membership == Model.User.Memberships.REGULAR)
            {
                recBtn.Enabled = false;
                top10Btn.Enabled = false;
            }
            else
            {
                recBtn.Enabled = true;
                top10Btn.Enabled = true;
            }

            LoadMedias(mediaList);
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formProfile = new FormProfile(user);
            formProfile.Closed += (s, args) => this.Close();
            formProfile.ShowDialog();
        }

        /// <summary>
        /// Loads all the medias from the database
        /// </summary>
        /// <param name="mediaList">list of medias</param>
        private void LoadMedias(List<Media> mediaList)
        {
            mediaLayout.Controls.Clear();
            foreach (var media in mediaList)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = media.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenMediaInfo(media);

                mediaLayout.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// Opens the FormMediaInformation and closes the currentForm
        /// </summary>
        /// <param name="media">Media</param>
        private void OpenMediaInfo(Media media)
        {
            var currentForm = this;
            var mediaInformationForm = new FormMediaInformation(currentForm, media, user);
            this.Hide();
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            if (Recommendation().Any())
            {
                LoadMedias(Recommendation());
            }
            else
            {
                ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
                string errorMessage = rm.GetString("NoRecommendationFound");
                string title = rm.GetString("RecommendationMessageBox");
                MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Filters the recommnedation by the user's watchlist is distict media genre.
        /// </summary>
        /// <returns></returns>
        private List<Media> Recommendation()
        {
            var database = DatabaseUtils.GetInstance();

            List<Media> allMedia = database.GetAllMedia();

            List<Media.Genre> watchlist = user.WatchList.SelectMany(media => media.Genres).Distinct().ToList();

            List<Media> recommendation = allMedia.Where(media => media.Genres.Any(genre => watchlist.Contains((Media.Genre)genre))).ToList();
            
            database.CloseConnection();

            return recommendation;
        }

        private void top10Btn_Click(object sender, EventArgs e)
        {
            LoadMedias(Top10());
        }

        /// <summary>
        /// Filters by the medias rating and takes the first ten.
        /// </summary>
        /// <returns>Returns the top 10 list</returns>
        private List<Media> Top10()
        {
            var database = DatabaseUtils.GetInstance();
            List<Media> allMedias = database.GetAllMedia();
            database.CloseConnection();

            List<Media> top10 = allMedias
                .OrderByDescending(m => m.GetMediaRating())
                .Take(10)
                .ToList();

            return top10;
        }

        private void moviesBtn_Click(object sender, EventArgs e)
        {
            LoadMedias(Movies());
        }

        /// <summary>
        /// Filters the database by movies
        /// </summary>
        /// <returns>Movie List</returns>
        private List<Media> Movies()
        {
            var database = DatabaseUtils.GetInstance();
            List<Movie> movies = database.GetAllMovies();
            List<Media> movieList = movies.Cast<Media>().ToList();
            database.CloseConnection();
            return movieList;
        }

        private void tvshowBtn_Click(object sender, EventArgs e)
        {
            LoadMedias(TVShows());
        }

        /// <summary>
        /// Filters by the TvShows
        /// </summary>
        /// <returns>TvShow List</returns>
        private List<Media> TVShows()
        {
            var database = DatabaseUtils.GetInstance();
            List<TVShow> tvshows = database.GetAllTVShows();
            List<Media> tvshowList = tvshows.Cast<Media>().ToList();
            database.CloseConnection();
            return tvshowList;
        }

        private void genreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var database = DatabaseUtils.GetInstance();

            if (genreBox.SelectedItem == null || string.IsNullOrEmpty(genreBox.SelectedItem.ToString()))
            {
                List<Media> allMedias = database.GetAllMedia();
                LoadMedias(allMedias);
            }
            else
            {
                string selectedTranslatedGenre = genreBox.SelectedItem.ToString();

                var genreTranslations = Utils.Util.GenerateGenreTranslations();
                if (genreTranslations.TryGetValue(selectedTranslatedGenre, out Media.Genre selectedGenre))
                {
                    List<Media> genres = database.GetMediaByGenre(selectedGenre);
                    LoadMedias(genres);
                }
            }
            database.CloseConnection();
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTB.Text.Trim();
            var database = DatabaseUtils.GetInstance();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                List<Media> searches = database.SearchMediaByTitle(searchText);
                LoadMedias(searches);
            }
            else
            {
                List<Media> allMedias = database.GetAllMedia();
                LoadMedias(allMedias);
            }
            database.CloseConnection();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }
    }
}
