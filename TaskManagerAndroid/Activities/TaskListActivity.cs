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
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.linearTaskList);

            // Put tasks onto screen
            foreach(var task in tasks)
            {
                ValuedCheckItem taskCheck = new ValuedCheckItem(this, task.ProjectTaskId.ToString());
                taskCheck.Text = task.Description;

                if (task.Completed)
                {
                    taskCheck.Checked = true;
                }

                taskCheck.CheckedChange += TaskCheck_CheckedChange;

                layout.AddView(taskCheck);
            }

            // Display a message if there are not tasks assigned to this project
            if(tasks.Count() == 0)
            {
                TextView noTasksText = new TextView(this);
                noTasksText.Text = "There are currently no tasks for this project!";
                noTasksText.SetTextColor(Android.Graphics.Color.Red);
                layout.AddView(noTasksText);
            }

            // Get the project 
            TaskManagerAPI.Project proj = TaskManagerAPI.Project.GetProject(Token.AuthToken, _projectId);
            this.Title = proj.Name + " Tasks";
        }

        private void TaskCheck_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            // Update task checked state
            ValuedCheckItem checkedItem = sender as ValuedCheckItem;
            if(checkedItem== null)
            {
                return;
            }

            int taskId = Convert.ToInt32(checkedItem.AttachedValue);
            TaskManagerAPI.ProjectTask.UpdateTaskCompletedStatus(Token.AuthToken, taskId, e.IsChecked);
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

    public class ValuedCheckItem : CheckBox
    {
        public string AttachedValue { get; set; }

        public ValuedCheckItem(Context context, string value)
            : base(context)
        {
            this.AttachedValue = value;
        }
    }
}