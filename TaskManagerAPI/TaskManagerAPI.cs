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
        public static object SendGetRequest(string requestPath, Dictionary<string, string> parameters = null, string authToken = null)
        {
            string URL = "http://192.168.0.16/TaskManagerWeb";

            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(requestPath, Method.GET);

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
                throw new RequestException(response.StatusCode);
            }
        }
    }

    public class RequestException : ApplicationException
    {
        public RequestException(System.Net.HttpStatusCode response)
            : base("Response came back as " + response.ToString())
        {

        }
    }
}
