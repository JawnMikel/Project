namespace MovieDatabase
{
    public partial class FormLogin : Form
    {
        public static List<User> users = new List<User>();
        public FormLogin()
        {
            InitializeComponent();
            errorLbl.Visible = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            User user = users.FirstOrDefault(u => u.CheckCredentials(usernameTB.Text, passwordTB.Text));

            if (user != null)
            {
                this.Hide();
                var frmMainMenu = new FormMainMenu(user);
                frmMainMenu.Closed += (s, args) => this.Close();
                frmMainMenu.ShowDialog();
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
