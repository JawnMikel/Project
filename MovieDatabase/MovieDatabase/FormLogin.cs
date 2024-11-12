namespace MovieDatabase
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            errorLbl.Visible = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text.Equals("Andrew") && passwordTB.Text.Equals("123456"))
            {
                this.Hide();
                var frmCreateAcc = new FormMainMenu();
                frmCreateAcc.Closed += (s, args) => this.Close();
                frmCreateAcc.ShowDialog();
            }
            else
            {
                errorLbl.Visible = true;
            }
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmCreateAcc = new FormCreateAcc();
            frmCreateAcc.Closed += (s, args) => this.Close();
            frmCreateAcc.ShowDialog();
        }

        private void loginTitleLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usernameTB_MouseClick(object sender, MouseEventArgs e)
        {
            errorLbl.Visible = false;
        }

        private void passwordTB_MouseClick(object sender, MouseEventArgs e)
        {
            errorLbl.Visible = false;
        }
    }
}
