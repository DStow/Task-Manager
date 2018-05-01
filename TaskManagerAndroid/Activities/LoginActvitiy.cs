using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using API = TaskManagerAPI;

namespace TaskManagerAndroid.Activities
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

            // Check if the user already has a token
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            string prefToken = prefs.GetString("AuthToken", null);
            if(prefToken != null)
            {
                Token.AuthToken = prefToken;
                // ToDo: Test a connection to make sure the token is valid
                GoToProjectListActivity();
            }
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

                // Store the token in the shared preferences...
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("AuthToken", token);
                editor.Apply();

                GoToProjectListActivity();
            }
            else
            {
                // Show credentials error
            }
        }

        private void GoToProjectListActivity()
        {
            var projectListActivity = new Intent(this, typeof(ProjectListActivity));
            StartActivity(projectListActivity);
        }
    }
}