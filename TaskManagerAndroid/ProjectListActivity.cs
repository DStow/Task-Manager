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

using API = TaskManagerAPI;

namespace TaskManagerAndroid
{
    [Activity(Label = "Your Projects")]
    public class ProjectListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ProjectList);

            // Get the projects
            API.Project[] projects = API.Project.GetProjects(Token.AuthToken);

            // Get layout container
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.projectListLayout);

            // Add of the projects as a button to the layout
            foreach (var project in projects)
            {
                Button projButton = new Button(this);
                projButton.Text = project.Name;

                projButton.Click += (object sender, EventArgs e) =>
                {
                    // Send the user to the project menu view?
                };

                layout.AddView(projButton);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.AddItemMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.TitleFormatted.ToString() == "Add")
            {
                // When the add button is pressed in this activity,
                // Send the user to the project add activity
                var projectCreateActivity = new Intent(this, typeof(ProjectCreateActivity));
                StartActivity(projectCreateActivity);
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}