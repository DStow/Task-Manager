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
            PopulateTaskList();
        }

        private void PopulateTaskList()
        {
            TaskManagerAPI.ProjectTask[] tasks = TaskManagerAPI.ProjectTask.GetTasks(Token.AuthToken, _project.ProjectId);
            listTasks.DataSource = tasks;
            listTasks.DisplayMember = "Description";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmTaskCreate createForm = new frmTaskCreate(_project);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                PopulateTaskList();
            }
        }

        private void listTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTasks.SelectedIndex >= 0)
            {
                TaskManagerAPI.ProjectTask selectedTask = (TaskManagerAPI.ProjectTask)listTasks.SelectedItem;
                lblCompleteStatus.Text = "Completed: " + selectedTask.Completed.ToString();
            }
            else
            {
                lblCompleteStatus.Text = "Completed: ";
            }
        }
    }
}
