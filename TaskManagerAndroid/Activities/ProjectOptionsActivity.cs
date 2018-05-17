using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TaskManagerAndroid.Activities
{
    [Activity(Label = "Project Options")]
    public class ProjectOptionsActivity : Activity
    {
        private int _projectId;
        private TaskManagerAPI.Project _project;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.ProjectOptions);

            // Store the passed in project Id
            _projectId = Intent.GetIntExtra("SelectedProjectId", -1);

            // Get buttons and assign clicks
            FindViewById<Button>(Resource.Id.btnProjectViewTasks).Click += btnProjectViewTasks_Click;
            FindViewById<Button>(Resource.Id.btnProjectEdit).Click += btnProjectEdit_Click;
            FindViewById<Button>(Resource.Id.btnProjectDelete).Click += btnProjectDelete_Click;

            _project = TaskManagerAPI.Project.GetProject(Token.AuthToken, _projectId);
            this.Title = _project.Name + " Options";
        }

        private void btnProjectViewTasks_Click(object sender, EventArgs e)
        {
            var taskListActivity = new Intent(this, typeof(TaskListActivity));
            taskListActivity.PutExtra("SelectedProjectId", _projectId);
            StartActivity(taskListActivity);
        }

        private void btnProjectEdit_Click(object sender, EventArgs e)
        {
            var projectEditActivity = new Intent(this, typeof(ProjectEditActivity));
            projectEditActivity.PutExtra("SelectedProjectId", _projectId);
            StartActivity(projectEditActivity);
        }

        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            // Confirm with user
            var dialogBuilder = new AlertDialog.Builder(this);
            dialogBuilder.SetTitle("Delete Project?!");
            dialogBuilder.SetMessage("Are you sure you want to delete the '" + _project.Name + "' project? (Can't be undone...)");
            dialogBuilder.SetNeutralButton("Cancel", (x, y) =>
            {
                // Do nothing as cancelled
            });

            dialogBuilder.SetNegativeButton("DELETE", (x, y) =>
            {
                // Send delete request
                TaskManagerAPI.Project.DeleteProject(Token.AuthToken, _projectId);
                // If this successds return to project list
                var projectListIntent = new Intent(this, typeof(ProjectListActivity));
                 StartActivity(projectListIntent);
                return;
            });
            dialogBuilder.Show();

        }
    }
}