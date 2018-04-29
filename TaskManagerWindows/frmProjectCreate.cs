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
    public partial class frmProjectCreate : Form
    {
        public frmProjectCreate()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string projectName = txtName.Text;

            int newProjectId = TaskManagerAPI.Project.CreateProject(Token.AuthToken, projectName);

            this.Close();
        }
    }
}
