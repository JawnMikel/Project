using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Utils;
using static MovieDatabase.User;

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

        private Review CreateReview()
        {
            string comment = reviewTB.Text;
            double rating = double.Parse(ratingTB.Text);
            try
            {
                Review review = new Review(user.Id,comment,rating);
                MessageBox.Show("Successfully posted review", "Posted review", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return review;
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message, "Invalid review", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (!Util.ValidateNameFormat(comment))
            {
                MessageBox.Show("User must have a proper comment", "Invalid Comment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            double rating = double.Parse(ratingTB.Text);

            if (!Util.ValidateRatingRange(rating))
            {
                MessageBox.Show("User must input a proper rating number (0-5)", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
