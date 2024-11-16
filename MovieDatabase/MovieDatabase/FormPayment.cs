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
    public partial class FormPayment : Form
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private DateTime _dob;
        private User.Memberships _membership;

        private decimal _paymentAmount = 11.99m;
        public FormPayment(string firstName, string lastName, string username, string password, DateTime dob, User.Memberships membership)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            _username = username;
            _password = password;
            _dob = dob;
            _membership = membership;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmCreateAcc = new FormCreateAcc();
            frmCreateAcc.Closed += (s, args) => this.Close();
            frmCreateAcc.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {

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
            int cvv;
            if (!int.TryParse(cvvTB.Text, out cvv))
            {
                MessageBox.Show("Invalid CVV. Please enter a 3-digit number.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //DateTime expiryDate = expiryDateTB.Text;

            Payment payment = new Payment(_firstName +" "+ _lastName,creditCardNumber,expiryDate,cvv,_paymentAmount);

            bool paymentSuccess = payment.Process(creditCardNumber, cvv, expiryDate);

            if (paymentSuccess)
            {
                User user = new User(_username, _password, _firstName, _lastName, _membership, _dob);
                FormLogin.users.Add(user);

                MessageBox.Show("Payment approved! Account successfully created.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formMainMenu = new FormMainMenu(user);
                formMainMenu.Closed += (s, args) => this.Close();
                formMainMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Payment failed. Please try again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
