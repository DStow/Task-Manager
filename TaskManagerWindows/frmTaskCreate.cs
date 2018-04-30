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
    public partial class frmTaskCreate : Form
    {
        private TaskManagerAPI.Project _project;

        public frmTaskCreate(TaskManagerAPI.Project project)
        {
            InitializeComponent();
            _project = project;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TaskManagerAPI.ProjectTask.CreateTask(Token.AuthToken, _project.ProjectId, txtDescription.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
