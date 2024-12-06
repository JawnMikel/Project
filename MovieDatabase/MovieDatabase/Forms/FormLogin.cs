using System.Globalization;
using System.Resources;
using MovieDatabase.Utils;


namespace MovieDatabase
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            UpdateComponents();
            passwordTB.PasswordChar = '*';
            passwordBox.CheckedChanged += passwordBox_CheckedChanged;
            errorLbl.Visible = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var database = DatabaseUtils.GetInstance();
            User? user = database.GetUserByCredentials(usernameTB.Text, passwordTB.Text);
            database.CloseConnection();
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

        private void passwordBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTB.PasswordChar = passwordBox.Checked ? '\0' : '*';
        }

        private void langBtn_Click(object sender, EventArgs e)
        {
            Util.Language();
            UpdateComponents();
        }
    }
}
