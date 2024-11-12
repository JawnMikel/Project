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
    public partial class FormCreateAcc : Form
    {
        public FormCreateAcc()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmLogin = new FormLogin();
            frmLogin.Closed += (s, args) => this.Close();
            frmLogin.ShowDialog();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            CreateUser();
            User user = CreateUser();
            if (membershipCB.SelectedIndex == 0)
            {
                this.Hide();
                var formMainMenu = new FormMainMenu();
                formMainMenu.Closed += (s, args) => this.Close();
                formMainMenu.ShowDialog();
            }
            else if (membershipCB.SelectedIndex == 1)
            {
                this.Hide();
                var formPayment = new FormPayment(user);
                formPayment.Closed += (s, args) => this.Close();
                formPayment.ShowDialog();
            }
        }

        private void membershipCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (membershipCB.SelectedIndex == 0)
            {
                nextBtn.Text = "Create Account";
            }
            else if (membershipCB.SelectedIndex == 1) 
            {
                nextBtn.Text = "Pay";
            }
        }

        private User CreateUser()
        {
            string firstName = firstNameTB.Text;
            string lastName = lastNameTB.Text;
            
            int selectedIndex = membershipCB.SelectedIndex;
            User.Memberships selectedMembership = (User.Memberships)selectedIndex;
            //string membership = selectedMembership.ToString();

            string username = usernameTB.Text;
            string password = passwordTB.Text;

            User user = new User(username, password, firstName, lastName, selectedMembership);
            return user;
        }

    }
}
