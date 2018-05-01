using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerWeb.Models;

namespace TaskManagerWeb.Controllers.Api
{
    public class ProjectController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Authorize]
        public Project[] GetProjects()
        {
            return _context.Projects.Where(x => x.CreatedBy == User.Identity.Name).ToArray();
        }

        [HttpPost]
        [Authorize]
        public int CreateProject(CreateProjectBindingClass newProject)
        {
            // Check if they have already created
            var existingProject = _context.Projects.Where(x => x.Name.ToLower() == newProject.Name.ToString() && x.CreatedBy == User.Identity.Name);

            if (existingProject.Count() > 0)
            {
                throw new Exception("Project already exists");
            }
            else
            {
                Project newProj = new Project()
                {
                    Name = newProject.Name,
                    CreatedBy = User.Identity.Name,
                    CreatedWhen = DateTime.Now
                };

                _context.Projects.Add(newProj);
                _context.SaveChanges();

                return newProj.ProjectId;
            }
        }

        #region Binding Classes
        public class CreateProjectBindingClass
        {
            public string Name { get; set; }
        }
        #endregion
    }
}
