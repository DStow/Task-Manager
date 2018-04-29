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
    [Activity(Label = "ProjectCreateActivity")]
    public class ProjectCreateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.ProjectCreate);

            // Set click on the create button
            FindViewById<Button>(Resource.Id.btnCreateProject).Click += btnCreateProject_Click;
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            // Validate new name
            EditText txtName = FindViewById<EditText>(Resource.Id.txtProjectName);
            string projectName = txtName.Text;

            if(projectName == "")
            {
                Dialog dialog = new Dialog(this);
                dialog.SetTitle("Project name cannot blank!");
                dialog.Show();
            }
            else
            {

            }
        }
    }
}