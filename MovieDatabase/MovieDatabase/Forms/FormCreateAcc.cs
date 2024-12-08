using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
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
                if (!CheckUser())
                {
                    return;
                }
                ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
                string title = "";
                string errorMessage = "";
                User user = CreateUser(User.Memberships.REGULAR);
                if (user == null)
                {
                    errorMessage = rm.GetString("AccountCreationFail");
                    title = rm.GetString("AccountCreationFailTitleMessageBox");
                    MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                errorMessage = rm.GetString("AccountCreationSuccess");
                title = rm.GetString("AccountCreationSuccessTitleMessageBox");
                MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formMainMenu = new FormMainMenu(user);
                formMainMenu.Closed += (s, args) => this.Close();
                formMainMenu.ShowDialog();
            }
            else if (membershipCB.SelectedIndex == 1)
            {
                if (!CheckUser())
                {
                    return;
                }
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
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            if (membershipCB.SelectedIndex == 0)
            {
                nextBtn.Text = rm.GetString("CreateAccountButton");
                nextBtn.Enabled = true;
            }
            else if (membershipCB.SelectedIndex == 1)
            {
                nextBtn.Text = rm.GetString("PayButton");
                nextBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Creates a user from the user class from using the information in the frame
        /// </summary>
        /// <param name="memberships">the memberships</param>
        /// <returns>a new user</returns>

        private User CreateUser(User.Memberships memberships)
        {
            string firstName = firstNameTB.Text;
            string lastName = lastNameTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            DateTime dob = dobPicker.Value;
            try
            {
                User user = new User(username, password, firstName, lastName, dob, memberships);
                var database = DatabaseUtils.GetInstance();
                database.InsertUser(user);
                database.CloseConnection();
                return user;
            }
            catch (SQLiteException ex)
            {
                ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
                string title = rm.GetString("UserCreationFailTitleMessageBox");
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        /// <summary>
        /// Checks all the user's information 
        /// </summary>
        /// <returns>returns false if the user's information is invalid and returns true if all of the information is valid</returns>
        private bool CheckUser()
        {
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            string firstName = firstNameTB.Text;

            if (!Util.ValidateNameFormat(firstName))
            {
                string message = rm.GetString("InvalidFirstNameMessage");
                string title = rm.GetString("InvalidFirstNameTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string lastName = lastNameTB.Text;

            if (!Util.ValidateNameFormat(lastName))
            {
                string message = rm.GetString("InvalidLastNameMessage");
                string title = rm.GetString("InvalidLastNameTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime dob = dobPicker.Value;

            if (!Util.ValidateUserAge(dob))
            {
                string message = rm.GetString("InvalidAgeMessage");
                string title = rm.GetString("InvalidAgeTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int selectedIndex = membershipCB.SelectedIndex;
            User.Memberships selectedMembership = (User.Memberships)selectedIndex;

            string username = usernameTB.Text;

            if (!Util.ValidateUsernameFormat(username))
            {
                string message = rm.GetString("InvalidUserNameMessage");
                string title = rm.GetString("InvalidUserNameTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string password = passwordTB.Text;

            if (!Util.ValidatePasswordFormat(password))
            {
                string message = rm.GetString("InvalidPasswordMessage");
                string title = rm.GetString("InvalidPasswordTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
