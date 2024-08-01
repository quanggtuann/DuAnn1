using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnn1
{
    public partial class loginForm : Form
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
