using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskDetailDTO
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskInfo { get; set; }
        public string Category { get; set; }
        public bool Favourite { get; set; }
        public bool Done { get; set; }
        public List<int> SubTasks { get; set; }
    }
}