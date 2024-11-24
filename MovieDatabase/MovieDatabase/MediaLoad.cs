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
    public partial class FormMediaLoad : Form
    {
        Form form;
        List<Media> mediaList;
        public FormMediaLoad(List<Media> medias, Form form)
        {
            InitializeComponent();
            this.form = form;
            mediaList = medias;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Hide();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }
    }
}
