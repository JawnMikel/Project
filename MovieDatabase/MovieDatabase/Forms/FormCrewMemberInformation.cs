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
    public partial class FormCrewMemberInformation : Form
    {
        Form form;
        CrewMember crewMember;
        User user;
        public FormCrewMemberInformation(Form form, CrewMember crewMember, User user)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;
            this.form = form;
            this.crewMember = crewMember;

            InitializeComponent();
            nameLbl.Text = crewMember.FirstName + " " + crewMember.LastName;
            ratingLbl.Text += crewMember.GetPopularity() + "/5";
            this.user = user;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        private void wirteReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FormWriteReview formWriteReview = new FormWriteReview(crewMember, user);
            formWriteReview.Closed += (s, args) => this.Close();
            formWriteReview.ShowDialog();
        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FormViewReview formViewReview = new FormViewReview(crewMember, user);
            formViewReview.Closed += (s, args) => this.Close();
            formViewReview.ShowDialog();
        }
    }
}
