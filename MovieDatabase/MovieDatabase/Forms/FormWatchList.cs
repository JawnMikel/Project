using MovieDatabase.Model;
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
    public partial class FormWatchList : Form
    {
        User user;
        public FormWatchList(User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            LoadMedias();

        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formProfile = new FormProfile(user);
            formProfile.Closed += (s, args) => this.Close();
            formProfile.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        /// <summary>
        /// Loads all the medias in the user's watchlist
        /// </summary>
        private void LoadMedias()
        {
            watchlistLayout.Controls.Clear();
            foreach (var media in user.WatchList)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = media.ImageLink,
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10)
                };

                pictureBox.Click += (s, e) => OpenMediaInfo(this, media);

                watchlistLayout.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// Opens the media inforamtion frame by giving the form and media
        /// </summary>
        /// <param name="form">The current form</param>
        /// <param name="media">Media</param>
        private void OpenMediaInfo(Form form, Media media)
        {
            var mediaInformationForm = new FormMediaInformation(this, media, user);
            this.Hide();
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }
    }
}
