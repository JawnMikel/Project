using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.message;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormCrewMemberInformation : Form
    {
        Form form;
        CrewMember crewMember;
        User user;
        Media media;
        public FormCrewMemberInformation(Form form, CrewMember crewMember, User user, Media media)
        {
            this.form = form;
            this.crewMember = crewMember;
            InitializeComponent();
            Update();
            nameLbl.Text = crewMember.FirstName + " " + crewMember.LastName;
            UpdateRatingLabel();
            this.user = user;
            this.media = media;
            if (user.Membership == User.Memberships.REGULAR)
            {
                writeReviewBtn.Enabled = false;
            }
            LoadPhoto(crewMember);
            LoadMedia(crewMember);
        }

        private List<Media> GetCrewMemberMedia(CrewMember crewMember)
        {
            var database = DatabaseUtils.GetInstance();
            List<Media> medias = new List<Media>();
            if (crewMember is Actor)
            {
                foreach (int id in ((Actor) crewMember).StarredMovies)
                {

                    medias.Add(database.GetMovieById(id));
                }

                foreach (int id in ((Actor)crewMember).StarredTVShows)
                {

                    medias.Add(database.GetTVShowById(id));
                }

                foreach (int id in ((Actor)crewMember).StarredEpisodes)
                {

                    medias.Add(database.GetEpisodeById(id));
                }

            } 
            else
            {
                foreach (int id in ((Director)crewMember).DirectedMovies)
                {

                    medias.Add(database.GetMovieById(id));
                }

                foreach (int id in ((Director)crewMember).DirectedTVShows)
                {

                    medias.Add(database.GetTVShowById(id));
                }

                foreach (int id in ((Director)crewMember).DirectedEpisodes)
                {

                    medias.Add(database.GetEpisodeById(id));
                }
            }
            database.CloseConnection();
            return medias;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mediaInfo = new FormMediaInformation(form,media,user);
            mediaInfo.Closed += (s, args) => this.Close();
            mediaInfo.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
            UpdateRatingLabel();
        }

        private void wirteReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formWriteReview = new FormWriteReview(this, crewMember, user, media);
            formWriteReview.Closed += (s, args) => this.Close();
            formWriteReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormViewReview(this, crewMember, user, media);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void UpdateRatingLabel()
        {
            string baseText = messages.Rating;
            ratingLbl.Text = $"{baseText} {crewMember.GetPopularity()}/5";
        }

        /// <summary>
        /// Loads all the medias from the database by the crewmember
        /// </summary>
        /// <param name="crewMember">Crew Member</param>
        private void LoadMedia(CrewMember crewMember)
        {
            mediaFlowPanel.Controls.Clear();
            foreach (var media in GetCrewMemberMedia(crewMember) )
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

                mediaFlowPanel.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// Loads the photo of the crew member
        /// </summary>
        /// <param name="crewMember">Crew member</param>
        private void LoadPhoto(CrewMember crewMember)
        {
            portraitFlowPanel.Controls.Clear();

            PictureBox pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = crewMember.ImageLink,
                Width = 150,
                Height = 200,
                Margin = new Padding(10)
            };

            portraitFlowPanel.Controls.Add(pictureBox);
        }

        /// <summary>
        /// Opens the FormMediaInformation by needing a media
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
    }
}
