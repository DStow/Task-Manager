using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedWhen { get; set; }

        public bool Completed { get; set; }
        public DateTime? CompletedWhen { get; set; }

        public static ProjectTask[] GetTasks(string authToken, int projectId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ProjectId", projectId.ToString());

            var responseResult = ((dynamic)TaskManagerAPI.SendRequest(Enumeration.RequestType.GET, "/api/task/gettasks", parameters, authToken));

            List<ProjectTask> results = new List<ProjectTask>();
            foreach (var item in responseResult)
            {
                // Should be a list of tasks...
                ProjectTask task = new ProjectTask()
                {
                    Completed = item.Completed,
                    CompletedWhen = item.CompletedWhen,
                    CreatedBy = item.CreatedBy,
                    CreatedWhen = item.CreatedWhen,
                    Description = item.Description,
                    ProjectId = item.ProjectId,
                    ProjectTaskId = item.ProjectTaskId
                };

                results.Add(task);
            }

            return results.ToArray();
        }

        public static int CreateTask(string authToken, int projectId, string description)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ProjectId", projectId.ToString());
            parameters.Add("Description", description);

            object result = TaskManagerAPI.SendRequest(Enumeration.RequestType.POST, "/api/task/createtask", parameters, authToken);

            return 0;
        }
    }
}
