using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MovieDatabase.Utils;
namespace MovieDatabase
{
    public partial class FormViewReview : Form
    {
        Media media;
        CrewMember crewMember;
        User user;
        Form form;
        public FormViewReview(Form form, CrewMember crewMember, User user, Media media)
        {
            InitializeComponent();
            Update();
            this.crewMember = crewMember;
            this.form = form;
            this.user = user;
            this.media = media;
            titleLbl.Text += " " + crewMember.FirstName + " " + crewMember.LastName;

            titleLbl.Text += LoadReview(crewMember);
        }
        public FormViewReview(Form form, Media media, User user)
        {
            InitializeComponent();
            this.media = media;
            titleLbl.Text += " " + media.Title;
            this.form = form;
            LoadReview(media);
            this.user = user;
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

        private string LoadReview(CrewMember crewMember)  
        {
            foreach (var review in crewMember.Reviews)
            {
                
            }

            this.user = user;

            return null;
        }

        private void LoadReview(Media media)
        {
            var database = DatabaseUtils.GetInstance();

            if (media is Movie)
            {
                Movie selectedMovie = database.GetMovieById(media.MediaId);
                foreach (var review in selectedMovie.Reviews)
                {
                    reviewsTB.Text += review.ToString();
                }
            } 
            else if (media is TVShow)
            {
                TVShow selectedTV = database.GetTVShowById(media.MediaId);
                foreach (var review in selectedTV.Reviews)
                {
                    reviewsTB.Text += review.ToString();
                }
            }
            else
            {
                Episode selectedEpisode = database.GetEpisodeById(media.MediaId);
                foreach (var review in selectedEpisode.Reviews)
                {
                    reviewsTB.Text += review.ToString();
                }
            }

            database.CloseConnection();
        }

    }
}
