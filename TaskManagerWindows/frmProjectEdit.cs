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
    public partial class frmProjectEdit : Form
    {
        private TaskManagerAPI.Project _project;

        public frmProjectEdit(TaskManagerAPI.Project project)
        {
            InitializeComponent();
            _project = project;

            txtName.Text = _project.Name.Trim();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                TaskManagerAPI.Project.UpdateProject(Token.AuthToken, _project.ProjectId, txtName.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
