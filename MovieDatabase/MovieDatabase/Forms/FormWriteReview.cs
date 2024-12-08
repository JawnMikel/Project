using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Model;
using MovieDatabase.Utils;
using static MovieDatabase.Model.User;

namespace MovieDatabase
{
    public partial class FormWriteReview : Form
    {
        User user;
        Media media;
        CrewMember crewMember;
        Form form;

        public FormWriteReview(Form form, Media media, User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            this.media = media;
            this.form = form;
            titleLbl.Text = media.Title;

        }

        public FormWriteReview(Form form, CrewMember crewMember, User user, Media media)
        {
            InitializeComponent();
            Update();
            this.user = user;
            this.crewMember = crewMember;
            this.form = form;
            this.media = media;
            titleLbl.Text = crewMember.FirstName + " " + crewMember.LastName;
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            Post();
        }

        /// <summary>
        /// Post controlls for when you write a post for a media or crew member
        /// </summary>
        private void Post()
        {
            var database = DatabaseUtils.GetInstance();

            if (!CheckReview())
            {
                return;
            }
            Review review = CreateReview();
            if (media != null)
            {
                if (media is Movie)
                {
                    database.InsertReview(review, (Movie)media);
                }
                else if (media is TVShow)
                {
                    database.InsertReview(review, (TVShow)media);

                }
                else if (media is Episode)
                {
                    database.InsertReview(review, (Episode)media);
                }
                media.AddReview(review);
            }
            if (crewMember != null)
            {
                if (crewMember is Actor)
                {
                    database.InsertReview(review, (Actor)crewMember);
                }
                else
                {
                    database.InsertReview(review, (Director)crewMember);
                }
                crewMember.AddReview(review);
            }
            database.CloseConnection();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (form is FormCrewMemberInformation)
            {
                var formCrewMemberInfo = new FormCrewMemberInformation(form, crewMember, user, media);
                formCrewMemberInfo.Closed += (s, args) => this.Close();
                formCrewMemberInfo.ShowDialog();
            }
            else if (form is FormMediaInformation)
            {
                var formMediaInfo = new FormMediaInformation(form, media, user);
                formMediaInfo.Closed += (s, args) => this.Close();
                formMediaInfo.ShowDialog();
            }
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        /// <summary>
        /// Creates the review
        /// </summary>
        /// <returns>The full review</returns>
        private Review? CreateReview()
        {
            string comment = reviewTB.Text;
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            try
            {
                double rating = double.Parse(ratingTB.Text);
                Review review = user.WriteReview(comment, rating);
                string message = rm.GetString("PostedReviewMessage");
                string title = rm.GetString("PostedReviewTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return review;
            }
            catch (ArithmeticException ex)
            {
                string message = rm.GetString("InvalidRatingMessage");
                string title = rm.GetString("InvalidRatingTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        /// <summary>
        /// Checks the review format
        /// </summary>
        /// <returns>returns true if the user's review is properly formatted.</returns>
        private bool CheckReview()
        {
            string comment = reviewTB.Text;
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);

            if (!Util.ValidateNameFormat(comment))
            {
                string message = rm.GetString("InvalidCommentMessage");
                string title = rm.GetString("InvalidCommentTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            double rating = 0;
            try
            {
                rating = double.Parse(ratingTB.Text);
            }
            catch (FormatException ex)
            {
                string message = rm.GetString("InvalidRatingMessage");
                string title = rm.GetString("InvalidRatingTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Util.ValidateRatingRange(rating))
            {
                string message = rm.GetString("InvalidRatingMessage");
                string title = rm.GetString("InvalidRatingTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
