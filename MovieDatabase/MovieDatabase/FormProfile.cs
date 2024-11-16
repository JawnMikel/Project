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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmLogin = new FormLogin();
            frmLogin.Closed += (s, args) => this.Close();
            frmLogin.ShowDialog();
        }

        private void watchlistBtn_Click(object sender, EventArgs e)
        {

        }

        private void upgradeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
