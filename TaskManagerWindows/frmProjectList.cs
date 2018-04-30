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
    public partial class frmProjectList : Form
    {
        public frmProjectList()
        {
            InitializeComponent();
        }

        private void frmProjectList_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if(login.ShowDialog() == DialogResult.OK)
            {
                // We have logged in!
                this.Text = "Welcome " + Token.Email;

                // Go get the projects
                PopulateProjectsList();
            }
            else
            {
                this.Close();
            }
        }

        private void PopulateProjectsList()
        {
            TaskManagerAPI.Project[] projects = TaskManagerAPI.Project.GetProjects(Token.AuthToken);
            listProjects.DataSource = projects;
            listProjects.DisplayMember = "Name";
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            frmProjectCreate createForm = new frmProjectCreate();
            createForm.ShowDialog();
            PopulateProjectsList();
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            if(listProjects.SelectedItems.Count > 0)
            {
                TaskManagerAPI.Project selectedProject = (TaskManagerAPI.Project)listProjects.SelectedItems[0];
                frmTaskList taskList = new frmTaskList(selectedProject);
                taskList.ShowDialog();
            }
        }
    }
}
