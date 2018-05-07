using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedWhen { get; set; }

        public static Project[] GetProjects(string authToken)
        {
            dynamic requestResult = TaskManagerAPI.SendRequest(Enumeration.RequestType.GET, "/api/project/getprojects", null, authToken);

            List<Project> results = new List<Project>();

            foreach (var item in requestResult)
            {
                Project proj = new Project()
                {
                    CreatedBy = item.CreatedBy,
                    CreatedWhen = item.CreatedWhen,
                    Name = item.Name,
                    ProjectId = item.ProjectId
                };

                results.Add(proj);
            }

            return results.ToArray();
        }

        public static Project GetProject(string authToken, int projectId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ProjectId", projectId.ToString());

            dynamic requestResult = TaskManagerAPI.SendRequest(Enumeration.RequestType.GET, "/api/project/getproject", parameters, authToken);
            Project project = new Project()
            {
                CreatedBy = requestResult.CreatedBy,
                CreatedWhen = requestResult.CreatedWhen,
                Name = requestResult.Name,
                ProjectId = requestResult.ProjectId
            };

            return project;
        }

        public static int CreateProject(string authToken, string projectName)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", projectName);

            dynamic requestResult = TaskManagerAPI.SendRequest(Enumeration.RequestType.POST, "/api/project/createproject", parameters, authToken);

            return 0;
        }

        public static void UpdateProject(string authToken, int projectId, string projectName)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ProjectId", projectId.ToString());
            parameters.Add("Name", projectName);

            TaskManagerAPI.SendRequest(Enumeration.RequestType.POST, "/api/project/updateproject", parameters, authToken);
        }
    }
}
