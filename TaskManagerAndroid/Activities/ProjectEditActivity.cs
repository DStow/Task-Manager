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
    [Activity(Label = "ProjectEditActivity")]
    public class ProjectEditActivity : Activity
    {
        private TaskManagerAPI.Project _project;
        private EditText _txtProjectName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.ProjectCreate);

            // Set click on the create button (This will now edit the title not create a fresh one)
            Button editBtn = FindViewById<Button>(Resource.Id.btnCreateProject);
            editBtn.Click += btnCreateProject_Click;
            editBtn.Text = "Update Project";

            // Get project details
            int projectId = Intent.GetIntExtra("SelectedProjectId", -1);

            if(projectId == 0)
            {
                throw new Exception("Project not found?!");
            }

            _project = TaskManagerAPI.Project.GetProject(Token.AuthToken, projectId);

            // Update activity title
            this.Title = "Edit " + _project.Name;

            // Get the text input
            _txtProjectName = FindViewById<EditText>(Resource.Id.txtProjectName);
            _txtProjectName.Text = _project.Name;
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            // Get the name
            string newText = _txtProjectName.Text;

            if (String.IsNullOrWhiteSpace(newText))
            {
                // Error message
                return;
            }
            else
            {
                TaskManagerAPI.Project.UpdateProject(Token.AuthToken, _project.ProjectId, newText);

                // Move back to projectlist
                var projectListActivity = new Intent(this, typeof(ProjectListActivity));
                StartActivity(projectListActivity);
            }
        }
    }
}