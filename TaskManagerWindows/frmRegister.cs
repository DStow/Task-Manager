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
    public partial class frmRegister : Form
    {

        public string Email { get; set; }

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email, password, confirmPassword;
            email = txtEmail.Text;
            password = txtPassword.Text;
            confirmPassword = txtPassConfirm.Text;

            if(password != confirmPassword)
            {
                MessageBox.Show("Passwords don't match!");
            }
            else
            {
                if(TaskManagerAPI.Account.CreateAccount(email, password))
                {
                    // Account is created successfully
                    this.Email = email;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error Creating account!");
                }
            }
        }
    }
}
