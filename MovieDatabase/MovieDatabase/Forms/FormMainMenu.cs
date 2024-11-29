using Microsoft.VisualBasic.ApplicationServices;
using MovieDatabase.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDatabase
{
    public partial class FormMainMenu : Form
    {
        User user;
        public FormMainMenu(User user)
        {
            Util.Language();
            Update();
            InitializeComponent();
            this.user = user;
            profileBtn.Text = user.Username;
            if (user.Membership.Equals("REGULAR"))
            {
                recBtn.Enabled = false;
                top10Btn.Enabled = false;
            }
            else
            {
                recBtn.Enabled = true;
                top10Btn.Enabled = true;
            }
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formProfile = new FormProfile(user);
            formProfile.Closed += (s, args) => this.Close();
            formProfile.ShowDialog();
        }
    }
}
