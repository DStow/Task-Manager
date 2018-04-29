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
    [Activity(Label = "Task Manager Login", MainLauncher = true)]
    public class LoginActvitiy : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            // Setup events for the two buttons
            FindViewById<Button>(Resource.Id.btnLogin).Click += btnLogin_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get email and password
            string email, password;
            EditText txtEmail, txtPassword;
            txtEmail = FindViewById<EditText>(Resource.Id.txtLoginEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtLoginPassword);
            email = txtEmail.Text;
            password = txtPassword.Text;
            
            // ToDo: Validate these details

            string token = null;
            if(API.Account.GetAccessToken(email, password, out token))
            {
                // Clear down and move to view projects activity
                txtEmail.Text = "";
                txtPassword.Text = "";

                Token.AuthToken = token;

                var projectListActivity = new Intent(this, typeof(ProjectListActivity));
                StartActivity(projectListActivity);
            }
            else
            {
                // Show credentials error
            }
        }
    }
}