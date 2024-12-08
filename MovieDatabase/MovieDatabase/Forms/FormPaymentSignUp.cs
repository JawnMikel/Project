using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieDatabase.Model;
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
            ResourceManager rm = new ResourceManager("MovieDatabase.message.messages", typeof(Program).Assembly);
            try
            {
                Payment payment = new Payment(cardHolderName, creditCardNumber, cvv, expiryDate);
                if (payment != null)
                {
                    User user = new User(_username, _password, _firstName, _lastName, _dob, _membership);
                    var database = DatabaseUtils.GetInstance();
                    database.InsertUser(user);
                    database.InsertPayment(payment, user.Id);
                    database.CloseConnection();

                    string message = rm.GetString("PaymentApprovedMessage");
                    string title = rm.GetString("PaymentApprovedTitle");
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    var formMainMenu = new FormMainMenu(user);
                    formMainMenu.Closed += (s, args) => this.Close();
                    formMainMenu.ShowDialog();
                }
                else
                {
                    string message = rm.GetString("PaymentFailedMessage");
                    string title = rm.GetString("PaymentFailedTitle");
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            catch (SQLiteException ex)
            {
                string message = rm.GetString("SQLErrorMessage");
                string title = rm.GetString("SQLErrorTitle");
                MessageBox.Show(message + ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ArgumentException ex)
            {
                string message = rm.GetString("PaymentFailedMessage");
                string title = rm.GetString("PaymentFailedTitle");
                MessageBox.Show(ex.Message, "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
