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
        public FormWriteReview(Media media, User user)
        {
            InitializeComponent();
            this.user = user;
            this.media = media;
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            double rating = double.Parse(ratingTB.Text);
            string comment = reviewTB.Text;
            Review review = new Review(user, comment, rating);
            media.addReview(review);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formMediaLoad = new FormMediaInformation(media);
            formMediaLoad.Closed += (s, args) => this.Close();
            formMediaLoad.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.language();
        }
    }
}
