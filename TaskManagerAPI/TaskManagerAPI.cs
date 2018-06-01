using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI
{
    public static class TaskManagerAPI
    {
        private static string _taskManagerURL = null;

        public static string TaskManagerURL
        {
            get
            {
                if (_taskManagerURL == null)
                {
                    throw new TaskManagerURLNotSetException();
                }
                else
                {
                    return _taskManagerURL;
                }
            }
            set { _taskManagerURL = value; }
        }

        public class TaskManagerURLNotSetException : ApplicationException
        {
            public TaskManagerURLNotSetException()
                : base("The TaskManagerAPI.TaskManagerAPI.TaskManagerURL has not been set yet!")
            {

            }
        }

        public static object SendRequest(Enumeration.RequestType requestType, string requestPath, Dictionary<string, string> parameters = null, string authToken = null)
        {
            string URL = TaskManagerURL;

            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(requestPath, Method.GET);

            if (requestType == Enumeration.RequestType.POST)
            {
                request = new RestRequest(requestPath, Method.POST);
            }

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    request.AddParameter(parameters.ElementAt(i).Key, parameters.ElementAt(i).Value);
                }
            }

            if (authToken != null)
            {
                request.AddHeader("Authorization", "Bearer " + authToken);
            }

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject(response.Content);
            }
            else
            {
                throw new RequestException(response.StatusCode, JsonConvert.DeserializeObject<ExceptionBinder>(response.Content).ExceptionMessage);
            }
        }

        class ExceptionBinder
        {
            public string Message { get; set; }
            public string ExceptionMessage { get; set; }
        }
    }

    public class RequestException : ApplicationException
    {
        public System.Net.HttpStatusCode ResponseCode { get; set; }
        public string ServerErrorMessage { get; set; }

        public RequestException(System.Net.HttpStatusCode response, string message)
            : base("Response came back as " + response.ToString())
        {
            this.ResponseCode = response;
            this.ServerErrorMessage = message;
        }
    }
}
