using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormCrewMemberInformation : Form
    {
        Form form;
        CrewMember crewMember;
        User user;

        //private readonly List<Media> medias = DatabaseUtils.GetInstance().GetM
        public FormCrewMemberInformation(Form form, CrewMember crewMember, User user)
        {
            
            this.form = form;
            this.crewMember = crewMember;
            InitializeComponent();
            Update();
            nameLbl.Text = crewMember.FirstName + " " + crewMember.LastName;
            ratingLbl.Text += crewMember.GetPopularity() + "/5";
            this.user = user;
            if (user.Membership.Equals("REGULAR"))
            {
                writeReviewBtn.Enabled = false;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        private void wirteReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formWriteReview = new FormWriteReview(form, crewMember, user);
            formWriteReview.Closed += (s, args) => this.Close();
            formWriteReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formViewReview = new FormViewReview(form, crewMember, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        /// <summary>
        /// Loads all the medias from the database
        /// </summary>
        /// <param name="medias">list of medias</param>
        private void LoadMedia(List<Media> medias)
        {
            mediaFlowPanel.Controls.Clear();
            foreach (var media in medias)
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
