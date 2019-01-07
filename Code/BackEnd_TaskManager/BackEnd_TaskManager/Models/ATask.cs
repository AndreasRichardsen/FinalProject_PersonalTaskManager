using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd_TaskManager.Models
{
    public class ATask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskInfo { get; set; }
        public int ParentTaskId { get; set; }
        public List<ATask> SubTasks { get; set; }
        public bool Favourite { get; set; }
        public bool Done { get; set; }
    }
}