using Microsoft.VisualBasic.ApplicationServices;
using MovieDatabase.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
    public partial class FormMainMenu : Form
    {
        Form form;
        private User user;

        private readonly List<Media> mediaList = DatabaseUtils.GetInstance().GetAllMedia();
        public FormMainMenu(User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            profileBtn.Text = user.Username;
            if (user.Membership.Equals("REGULAR"))
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
        public FormMainMenu(Form form,User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            this.form = form;
            profileBtn.Text = user.Username;
            if (user.Membership.Equals("REGULAR"))
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

                pictureBox.Click += (s, e) => OpenMediaInfo(form,media);

                mediaLayout.Controls.Add(pictureBox);
            }
        }

        private void OpenMediaInfo(Form form,Media media)
        {
            var currentForm = this;
            var mediaInformationForm = new FormMediaInformation(currentForm, media, user);
            this.Hide();
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            //takes from the watchlist and search history??
        }

        private void top10Btn_Click(object sender, EventArgs e)
        {
            var database = DatabaseUtils.GetInstance();
            List<Media> allMedias = database.GetAllMedia();
            List<Media> top10 = allMedias
                .OrderByDescending(m => m.GetMediaRating())
                .Take(10)
                .ToList(); 
         
            LoadMedias(top10);
        }

        private void moviesBtn_Click(object sender, EventArgs e)
        {

            var database = DatabaseUtils.GetInstance();
            List<Movie> movies = database.GetAllMovies(); 
            List<Media> mediaList = movies.Cast<Media>().ToList();
            LoadMedias(mediaList);
            database.CloseConnection();

        }

        private void tvshowBtn_Click(object sender, EventArgs e)
        {
            var database = DatabaseUtils.GetInstance();
            List<TVShow> tvshows = database.GetAllTVShows();
            List<Media> mediaList = tvshows.Cast<Media>().ToList();
            LoadMedias(mediaList);
            database.CloseConnection();

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
                Media.Genre selectedGenre = (Media.Genre)Enum.Parse(typeof(Media.Genre), genreBox.SelectedItem.ToString()); 
                List<Media> genres = database.GetMediaByGenre(selectedGenre);
                LoadMedias(genres);
            }
            database.CloseConnection();
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTB.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var database = DatabaseUtils.GetInstance();
                List<Media> searches = database.SearchMediaByTitle(searchText);
                LoadMedias(searches);
                database.CloseConnection();
            }
            else
            {
                mediaLayout.Controls.Clear();
            }
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }
    }
}
