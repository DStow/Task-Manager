using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TaskManagerWeb.Controllers
{
    public class TaskController : ApiController
    {
        private Models.ApplicationDbContext _context;

        public TaskController()
        {
            _context = new Models.ApplicationDbContext();
        }

        [Authorize]
        [HttpGet]
        public Models.ProjectTask[] GetTasks(int projectId)
        {
            // Check user is the project creator
            var project = _context.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault();
            if (project.CreatedBy.ToLower() == User.Identity.Name.ToLower())
            {
                Models.ProjectTask[] tasks = _context.Tasks.Where(x => x.ProjectId == projectId).ToArray();
                return tasks;
            }
            else
            {
                throw new Exception("Project does not belong to this user!");
            }
        }

        [Authorize]
        [HttpPost]
        public int CreateTask(CreateTaskBindingClass newTask)
        {
            // Check project belongs to user
            Models.Project project = _context.Projects.Where(x => x.ProjectId == newTask.ProjectId && x.CreatedBy.ToLower() == User.Identity.Name.ToLower()).FirstOrDefault();

            if (project == null)
            {
                throw new Exception("Project does not exist!");
            }
            else
            {
                Models.ProjectTask dbTask = new Models.ProjectTask()
                {
                    Completed = false,
                    CreatedBy = User.Identity.Name,
                    CreatedWhen = DateTime.Now,
                    Description = newTask.Description,
                    ProjectId = newTask.ProjectId
                };

                _context.Tasks.Add(dbTask);
                _context.SaveChanges();

                return dbTask.ProjectTaskId;
            }
        }

        public class CreateTaskBindingClass
        {
            public int ProjectId { get; set; }
            public string Description { get; set; }
        }
    }


}
