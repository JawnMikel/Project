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
    public partial class FormViewReview : Form
    {
        Media media;
        public FormViewReview(Media media)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
            this.media = media;
            titleLbl.Text += " " + media.Title;
            foreach (var review in media.Reviews)
            {
                titleLbl.Text += review.ToString();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var formMediaLoad = new FormMediaLoad(media);
            formMediaLoad.Closed += (s, args) => this.Close();
            formMediaLoad.Show();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.language();
        }
    }
}
