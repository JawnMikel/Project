using Microsoft.VisualBasic.ApplicationServices;
using MovieDatabase.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
    public partial class FormMainMenu : Form
    {
        private User user;
        private readonly List<Media> mediaList = new List<Media>(); // going to be a list of medias from the database
        public FormMainMenu(User user)
        {
            Util.Language();
            Update();
            InitializeComponent();
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

        private void OpenMediaInfo(Media media)
        {
            Hide();
            FormMediaInformation mediaInformationForm = new FormMediaInformation(this, media, user);
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            //takes from the watchlist and search history??
        }

        private void top10Btn_Click(object sender, EventArgs e)
        {
            //sorts in the database by the rating average
        }

        private void moviesBtn_Click(object sender, EventArgs e)
        {
            // selects all from movies from the database
        }

        private void tvshowBtn_Click(object sender, EventArgs e)
        {
            // shows all from tvshows from the database
        }

        private void genreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genreBox.SelectedItem == null || string.IsNullOrEmpty(genreBox.SelectedItem.ToString()))
            {
               //show all the medias in the database
            }
            else
            {
                //filter all the medias by the selected genre
                string selectedGenre = genreBox.SelectedItem.ToString();
               
            }
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTB.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
               //searches through the database by the title using LIKE 
            }
            else
            {
                mediaLayout.Controls.Clear();
            }
        }
    }
}
