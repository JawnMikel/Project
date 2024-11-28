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
    public partial class FormPaymentUpgrade : Form
    {
        User user;
        public FormPaymentUpgrade(User user)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;

            InitializeComponent();
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
            string creditCardNumber = cardNumberTB.Text;
            string cvv = cvvTB.Text;
            string expiryDate = expiryDateTB.Text;

            try
            {
                Payment payment = new Payment(
                    fullNameTB.Text,
                    creditCardNumber,
                    expiryDate,
                    cvv
                );

                user.Membership = User.Memberships.PREMIUM;

                MessageBox.Show("Payment approved! Account successfully upgraded.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formProfile = new FormProfile(user);
                formProfile.Closed += (s, args) => this.Close();
                formProfile.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
