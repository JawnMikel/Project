using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormProfile : Form
    {
        User user;
        public FormProfile(User user)
        { 
            InitializeComponent();
            Update();

            this.user = user;
            fullNameTB.Text = user.FirstName + " " + user.LastName;
            usernameTB.Text = user.Username;
            dobPicker.Value = user.Dob;
            membershipTB.Text = user.Membership.ToString();

            if (user.Membership == User.Memberships.PREMIUM)
            {
                upgradeBtn.Enabled = false;
            }
            else
            {
                upgradeBtn.Enabled = true;
            }
        }
        private void logoutBtn_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show(
            "Are you sure you want to log out?",
            "Logout Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var frmLogin = new FormLogin();
                frmLogin.Closed += (s, args) => this.Close();
                frmLogin.ShowDialog();
            }
        }

        private void watchlistBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formWatchList = new FormWatchList();
            formWatchList.Closed += (s, args) => this.Close();
            formWatchList.ShowDialog();
        }

        private void upgradeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formPaymentUpgrade = new FormPaymentUpgrade(user);
            formPaymentUpgrade.Closed += (s, args) => this.Close();
            formPaymentUpgrade.ShowDialog();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmMainMenu = new FormMainMenu(user);
            frmMainMenu.Closed += (s, args) => this.Close();
            frmMainMenu.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }
    }
}
