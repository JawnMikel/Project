using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Model;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormMediaLoad : Form
    {
        Form form;
        Media.Genre genre;
        User user;
        public FormMediaLoad(Media.Genre genre, Form form, User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            this.form = form;
            this.genre = genre;

            var genreTranslations = Util.GenerateGenreTranslation();

            string translatedGenre = genreTranslations.ContainsKey(genre.ToString()) ? genreTranslations[genre.ToString()] : genre.ToString();

            genreLbl.Text = translatedGenre;

            LoadMedia(genre);
        }

        /// <summary>
        /// Loads all the media by their genres
        /// </summary>
        /// <param name="genre"></param>
        private void LoadMedia(Media.Genre genre)
        {
            var database = DatabaseUtils.GetInstance();
            List<Media> medias = database.GetMediaByGenre(genre);
            database.CloseConnection();
            mediaLayout.Controls.Clear();

            foreach(var media in medias)
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
        /// Opens the media information frame when you click on a media
        /// </summary>
        /// <param name="media"></param>
        private void OpenMediaInfo(Media media)
        {
            var mediaInformationForm = new FormMediaInformation(this, media, user);
            this.Hide();
            mediaInformationForm.Closed += (s, args) => this.Close();
            mediaInformationForm.ShowDialog();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
