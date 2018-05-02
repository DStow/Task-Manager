using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManagerWeb.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedWhen { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }

        [NotMapped]
        public DateTime? LatestEditDate { get { return CalculateLatestEditDate(); } }

        public DateTime? CalculateLatestEditDate()
        {
            DateTime? result = null;

            if(Tasks != null)
            {
                result = Tasks.OrderByDescending(x => x.CreatedWhen).First().CreatedWhen;
            }

            return result;
        }
    }
}