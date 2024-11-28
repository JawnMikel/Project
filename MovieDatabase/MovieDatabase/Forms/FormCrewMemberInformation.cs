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
        public FormCrewMemberInformation(CrewMember member)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
            nameLbl.Text = member.FirstName + " " + member.LastName;
            ratingLbl.Text += member.getCrewMemberRating() + "/5";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
        }

        private void wirteReviewBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewReviewBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
