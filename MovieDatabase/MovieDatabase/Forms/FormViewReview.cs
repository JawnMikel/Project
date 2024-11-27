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
        CrewMember crewMember;
        User user;
        public FormViewReview(CrewMember crewMember, User user)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;
            this.media = null;

            InitializeComponent();
            this.crewMember = crewMember;
            titleLbl.Text += " " + crewMember.FirstName + " " + crewMember.LastName;
            
            foreach (var review in crewMember.Reviews)
            {
                titleLbl.Text += review.ToString();
            }

            this.user = user;
        }
        public FormViewReview(Media media, User user)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;
            this.crewMember = null;

            InitializeComponent();
            this.media = media;
            titleLbl.Text += " " + media.Title;
            foreach (var review in media.Reviews)
            {
                titleLbl.Text += review.ToString();
            }

            this.user = user;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            var formMediaLoad = new FormMediaInformation(media, user);
            formMediaLoad.Closed += (s, args) => this.Close();
            formMediaLoad.Show();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.language();
        }
    }
}
