using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MovieDatabase.Model;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormViewReview : Form
    {
        Media media;
        Media previousMedia;
        CrewMember crewMember;
        User user;
        Form form;

        public FormViewReview(Form form, CrewMember crewMember, User user, Media media, Media previousMedia)
        {
            InitializeComponent();
            this.crewMember = crewMember;
            this.form = form;
            this.user = user;
            this.media = media;
            this.previousMedia = previousMedia;
            LoadReview(crewMember);
            Update();
        }

        public FormViewReview(Form form, Media media, User user)
        {
            InitializeComponent();
            this.media = media;
            this.form = form;
            this.user = user;
            LoadReview(media);
            Update();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (form is FormCrewMemberInformation)
            {
                FormCrewMemberInformation formCrewMemberInfo = null;
                if (previousMedia != null)
                {
                    formCrewMemberInfo = new FormCrewMemberInformation(form, crewMember, user, previousMedia);
                }
                else
                {
                    formCrewMemberInfo = new FormCrewMemberInformation(form, crewMember, user, media);
                }
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
        /// Loads the reviews of the crew member
        /// </summary>
        /// <param name="crewMember">Crew member</param>
        private void LoadReview(CrewMember crewMember)  
        {
            DatabaseUtils database = DatabaseUtils.GetInstance();
            foreach (Review review in crewMember.Reviews)
            {
                // Get the reviewer
                User reviewer = database.GetUserById(review.AuthorId);
                reviewsTB.Text += "Author: " + reviewer.FirstName + " " + reviewer.LastName + "\n";
                reviewsTB.Text += review.Comment + "\n\n";
            }
            database.CloseConnection();
        }

        /// <summary>
        /// Loads the review of the media
        /// </summary>
        /// <param name="media">Media</param>
        private void LoadReview(Media media)
        {
            var database = DatabaseUtils.GetInstance();

            foreach (Review review in media.Reviews)
            {
                // Get the reviewer
                User reviewer = database.GetUserById(review.AuthorId);
                reviewsTB.Text += "Author: " + reviewer.FirstName + " " + reviewer.LastName + "\n";
                reviewsTB.Text += review.Comment + "\n\n";
            }
            database.CloseConnection();
        }

    }
}
