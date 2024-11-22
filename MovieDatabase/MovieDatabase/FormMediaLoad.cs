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
    public partial class FormMediaLoad : Form
    {
        Form form;
        public FormMediaLoad(Form form, Media media)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
            this.form = form;
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Sysnopsis;
            ratingLbl.Text += media.getMediaRating() + "/5";
        }
        public FormMediaLoad(Media media)
        {
            InitializeComponent();
            titleLbl.Text = media.Title;
            releaseDate.Value = media.ReleaseDate;
            sysnopsisLbl.Text = media.Sysnopsis;
            ratingLbl.Text += media.getMediaRating() + "/5";
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.language();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void giveReviewBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
