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
    public partial class FormWatchList : Form
    {
        User user;
        public FormWatchList(User user)
        {
            InitializeComponent();
            this.user = user;   
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formProfile = new FormProfile(user);
            formProfile.Closed += (s, args) => this.Close();
            formProfile.ShowDialog();
        }

        private void langBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
