using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public partial class FormPaymentUpgrade : Form
    {
        User user;
        public FormPaymentUpgrade(User user)
        {
            InitializeComponent();
            Update();
            this.user = user;
            fullNameTB.Text = user.FirstName + " " + user.LastName;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmCreateAcc = new FormProfile(user);
            frmCreateAcc.Closed += (s, args) => this.Close();
            frmCreateAcc.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            Update();
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            ConfirmPayment();
        }

        /// <summary>
        /// The method sets all the user inputs and uses the Payment class to make the payment and approves it if the criteria is met. It will also open the MainMenu Form after the payment was successful.
        /// </summary>
        private void ConfirmPayment()
        {
            string cardHolderName = fullNameTB.Text;
            string creditCardNumber = cardNumberTB.Text;
            string cvv = cvvTB.Text;
            string expiryDate = expiryDateTB.Text;

            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            try
            {
                Payment userPayment = user.UpgradeMembership(cardHolderName, creditCardNumber, cvv, expiryDate);
                DatabaseUtils.GetInstance().CloseConnection();
                DatabaseUtils database = DatabaseUtils.GetInstance();
                database.InsertPayment(userPayment, user.Id);
                database.CloseConnection();

                string message = rm.GetString("PaymentUpgradeApprovedMessage");
                string title = rm.GetString("PaymentUpgradeApprovedTitle");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formProfile = new FormProfile(user);
                formProfile.Closed += (s, args) => this.Close();
                formProfile.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                string message = rm.GetString("PaymentFailedMessage");
                string title = rm.GetString("PaymentFailedTitle");
                MessageBox.Show($"{message}: {ex.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                string message = rm.GetString("UnexpectedErrorMessage");
                string title = rm.GetString("UnexpectedErrorTitle");
                MessageBox.Show(message + ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
