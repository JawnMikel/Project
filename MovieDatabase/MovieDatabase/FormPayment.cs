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
        public FormPayment(User user)
        {
            InitializeComponent();
            fullNameTB.Text = $"{user.FirstName} {user.LastName}";
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

        }
    }
}
