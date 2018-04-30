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
    public partial class frmTaskList : Form
    {
        private TaskManagerAPI.Project _project;

        public frmTaskList(TaskManagerAPI.Project project)
        {
            InitializeComponent();
            _project = project;

            this.Text = "Tasks for " + _project.Name;
        }

        private void frmTaskList_Load(object sender, EventArgs e)
        {
            TaskManagerAPI.ProjectTask[] tasks = TaskManagerAPI.ProjectTask.GetTasks(Token.AuthToken, _project.ProjectId);
            listTasks.DataSource = tasks;
            listTasks.DisplayMember = "Description";
        }
    }
}
