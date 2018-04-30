using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWeb.Models
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedWhen { get; set; }

        public bool Completed { get; set; }
        public DateTime? CompletedWhen { get; set; }

    }
}