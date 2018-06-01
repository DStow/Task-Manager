using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagerWindows
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email, password;
            email = txtEmail.Text;
            password = txtPassword.Text;

            string token = null;

            if (TaskManagerAPI.Account.GetAccessToken(email, password, out token))
            {
                Token.AuthToken = token;
                Token.Email = email;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Credentials error!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();

            if (register.ShowDialog() == DialogResult.OK)
            {
                // DIsplay the entered email as the login email on this form
                txtEmail.Text = register.Email;
                txtPassword.Text = "";
            }
        }
    }
}
