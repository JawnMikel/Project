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
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;
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
            string lastName = lastNameTB.Text;
            DateTime dob = dobPicker.Value;

            if (!Util.ValidateUserAge(dob))
            {
                MessageBox.Show("User must be at least 18 years old.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new ArithmeticException("Must be 18 years and older");
            }

            int selectedIndex = membershipCB.SelectedIndex;
            User.Memberships selectedMembership = (User.Memberships)selectedIndex;

            string username = usernameTB.Text;
            string password = passwordTB.Text;
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
