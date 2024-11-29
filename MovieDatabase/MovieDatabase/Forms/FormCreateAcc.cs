using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormCreateAcc : Form
    {
       
        public FormCreateAcc()
        {
            InitializeComponent();
            Update();
            passwordTB.PasswordChar = '*';
            passwordBox.CheckedChanged += passwordBox_CheckedChanged;
            nextBtn.Enabled = false;
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
            if (membershipCB.SelectedIndex == 0)
            {
                User user = CreateUser();

                if (user == null)
                {
                    return;
                }
                FormLogin.users.Add(user);

                MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formMainMenu = new FormMainMenu(user);
                formMainMenu.Closed += (s, args) => this.Close();
                formMainMenu.ShowDialog();
            }
            else if (membershipCB.SelectedIndex == 1)
            {
                this.Hide();

                var formPayment = new FormPaymentSignUp(
                    firstNameTB.Text,
                    lastNameTB.Text,
                    usernameTB.Text,
                    passwordTB.Text,
                    dobPicker.Value,
                    User.Memberships.PREMIUM
                );

                formPayment.Closed += (s, args) => this.Close();
                formPayment.ShowDialog();
            }
        }
        private void membershipCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (membershipCB.SelectedIndex == 0)
            {
                nextBtn.Text = "Create Account";
                nextBtn.Enabled = true;
            }
            else if (membershipCB.SelectedIndex == 1)
            {
                nextBtn.Text = "Pay";
                nextBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Creates a user from the user class from using the information in the frame
        /// </summary>
        /// <returns>a new user</returns>
        private User CreateUser()
        {
            string firstName = firstNameTB.Text;

            if (!Util.ValidateNameFormat(firstName))
            {
                MessageBox.Show("User must have a proper first name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string lastName = lastNameTB.Text;

            if (!Util.ValidateNameFormat(lastName))
            {
                MessageBox.Show("User must have a proper last name", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            DateTime dob = dobPicker.Value;

            if (!Util.ValidateUserAge(dob))
            {
                MessageBox.Show("User must be at least 18 years old.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int selectedIndex = membershipCB.SelectedIndex;
            User.Memberships selectedMembership = (User.Memberships)selectedIndex;

            string username = usernameTB.Text;

            if (!Util.ValidateUsernameFormat(username))
            {
                MessageBox.Show("User must have a valid username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }


            string password = passwordTB.Text;

            if (!Util.ValidatePasswordFormat(password))
            {
                MessageBox.Show("User must have a valid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            User user = new User(username, password, firstName, lastName, dob, selectedMembership);
            return user;
        }

        private void passwordBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTB.PasswordChar = passwordBox.Checked ? '\0' : '*';
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }
    }
}
