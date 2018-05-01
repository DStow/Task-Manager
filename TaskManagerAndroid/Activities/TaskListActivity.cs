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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TaskList);

            // Get Project Id
            int projectId = Intent.GetIntExtra("SelectedProjectId", -1);

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

            if(tasks.Count() == 0)
            {
                TextView noTasksText = new TextView(this);
                noTasksText.Text = "There are currently no tasks for this project!";
                noTasksText.SetTextColor(Android.Graphics.Color.Red);
                layout.AddView(noTasksText);
            }
        }
    }
}