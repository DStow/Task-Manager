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
    [Activity(Label = "Create Task")]
    public class TaskCreateActivity : Activity
    {
        private int _projectId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TaskCreate);

            _projectId = Intent.GetIntExtra("SelectedProjectId", -1);

            // Add event handlers
            FindViewById<Button>(Resource.Id.btnCreateTask).Click += btnCreateTask_Click;
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            // Get description and validate
            string description = FindViewById<EditText>(Resource.Id.txtTaskDescription).Text;

            if (String.IsNullOrEmpty(description) == false)
            {
                TaskManagerAPI.ProjectTask.CreateTask(Token.AuthToken, _projectId, description);
            }

            // Return to project list
            var projectListActivity = new Intent(this, typeof(TaskListActivity));
            projectListActivity.PutExtra("SelectedProjectId", _projectId);
            StartActivity(projectListActivity);
        }
    }
}