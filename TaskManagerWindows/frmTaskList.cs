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
        private int _projectId;

        public frmTaskList(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
        }

        private void frmTaskList_Load(object sender, EventArgs e)
        {
            TaskManagerAPI.ProjectTask[] tasks = TaskManagerAPI.ProjectTask.GetTasks(Token.AuthToken, _projectId);
            listTasks.DataSource = tasks;
            listTasks.DisplayMember = "Description";
        }
    }
}
