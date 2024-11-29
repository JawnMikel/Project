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
    public partial class FormPaymentSignUp : Form
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private DateTime _dob;
        private User.Memberships _membership;
        public FormPaymentSignUp(string firstName, string lastName, string username, string password, DateTime dob, User.Memberships membership)
        {
            Thread.CurrentThread.CurrentCulture = Util.cultureEn;
            Thread.CurrentThread.CurrentUICulture = Util.cultureEn;
            
            InitializeComponent();
           
            Update();
            _firstName = firstName;
            _lastName = lastName;
            _username = username;
            _password = password;
            _dob = dob;
            _membership = membership;
            fullNameTB.Text = firstName + " " + lastName;
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

            try
            {
                Payment payment = new Payment(
                    cardHolderName,
                    creditCardNumber,
                    expiryDate,
                    cvv
                );

                User user = new User(_username, _password, _firstName, _lastName, _dob, _membership);
                FormLogin.users.Add(user);

                MessageBox.Show("Payment approved! Account successfully created.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var formMainMenu = new FormMainMenu(user);
                formMainMenu.Closed += (s, args) => this.Close();
                formMainMenu.ShowDialog();
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
