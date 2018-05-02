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
    [Activity(Label = "Task List")]
    public class TaskListActivity : Activity
    {
        private int _projectId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TaskList);

            // Get Project Id
            int projectId = Intent.GetIntExtra("SelectedProjectId", -1);
            _projectId = projectId;

            // Get the tasks from the API
            TaskManagerAPI.ProjectTask[] tasks = TaskManagerAPI.ProjectTask.GetTasks(Token.AuthToken, projectId);

            // Get layout
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.TaskListLayout);

            // Put tasks onto screen
            foreach(var task in tasks)
            {
                TextView text = new TextView(this);
                text.Text = task.Description;
                layout.AddView(text);
            }

            // Display a message if there are not tasks assigned to this project
            if(tasks.Count() == 0)
            {
                TextView noTasksText = new TextView(this);
                noTasksText.Text = "There are currently no tasks for this project!";
                noTasksText.SetTextColor(Android.Graphics.Color.Red);
                layout.AddView(noTasksText);
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
                var taskCreateActivity = new Intent(this, typeof(TaskCreateActivity));
                taskCreateActivity.PutExtra("SelectedProjectId", _projectId);
                StartActivity(taskCreateActivity);
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}