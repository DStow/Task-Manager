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

namespace TaskManagerAndroid
{
    [Activity(Label = "ProjectOptionsActivity")]
    public class ProjectOptionsActivity : Activity
    {
        private int _projectId;

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
        }

        private void btnProjectViewTasks_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnProjectEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}