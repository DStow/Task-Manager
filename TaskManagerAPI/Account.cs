using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI
{
    public static class Account
    {
        public static bool CreateAccount(string email, string password)
        {
            string URL = "http://192.168.0.16/TaskManagerWeb";

            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest("/Api/Account/Register", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Email", email);
            request.AddParameter("Password", password);
            request.AddParameter("ConfirmPassword", password);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetAccessToken(string email, string password, out string token)
        {
            RestClient client = new RestClient("http://192.168.0.16/TaskManagerWeb");
            RestRequest request = new RestRequest("/Token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("Username", email);
            request.AddParameter("Password", password);

            IRestResponse res = client.Execute(request);
            dynamic response = JsonConvert.DeserializeObject(res.Content);

            if (response.access_token != null)
            {
                token = response.access_token;
                return true;
            }
            else
            {
                token = null;
                return false;
            }
        }

        /// <summary>
        /// Calls the API and returns the email of the currently authenticated user
        /// </summary>
        public static string WhoAmI(string authToken)
        {
            object result = TaskManagerAPI.SendRequest(Enumeration.RequestType.GET, "/API/Account/WhoAmI", null, authToken);
            return result.ToString();
        }
    }
}
