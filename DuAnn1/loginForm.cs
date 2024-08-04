namespace DuAnn1
{
    public partial class loginForm : System.Windows.Forms.Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Username.Text == "a" && Password.Text == "a")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai.");
            }
        }
    }
}