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
    public partial class FormWriteReview : Form
    {
        User user;
        Media media;
        CrewMember member;
        public FormWriteReview(Media media, User user)
        {
            InitializeComponent();
            this.user = user;
            this.media = media;
            titleLbl.Text = media.Title;

        }
        public FormWriteReview(CrewMember member, User user)
        {
            InitializeComponent();
            this.user = user;
            this.member = member;
            titleLbl.Text = member.FirstName + " " + member.LastName;
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            double rating = double.Parse(ratingTB.Text);
            string comment = reviewTB.Text;
            Review review = new Review(user.Id, comment, rating);
            if (media != null)
            {
                media.AddReview(review);
            }
            if (member != null)
            {
                member.AddReview(review);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formMediaLoad = new FormMediaInformation(this, media, user);
            formMediaLoad.Closed += (s, args) => this.Close();
            formMediaLoad.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
        }
    }
}
