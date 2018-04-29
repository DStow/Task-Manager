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
            dynamic requestResult = TaskManagerAPI.SendGetRequest("/api/project/getprojects", null, authToken);

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
    }
}
