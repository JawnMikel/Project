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
    public partial class FormMediaInformation : Form
    {
        Form form;
        Media media;
        public FormMediaInformation(Form form, Media media)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
            this.media = media;
            this.form = form;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Sysnopsis;
            ratingLbl.Text += media.getMediaRating() + "/5";
        }
        public FormMediaInformation(Media media)
        {
            InitializeComponent();
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Sysnopsis;
            ratingLbl.Text += media.getMediaRating() + "/5";
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void giveReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FormViewReview formViewReview = new FormViewReview(media);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FormViewReview formViewReview = new FormViewReview(media);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }
    }
}
