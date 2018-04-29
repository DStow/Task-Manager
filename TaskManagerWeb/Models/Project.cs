using System;
using System.Collections.Generic;
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
    }
}