using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain
{
    class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskInfo { get; set; }
        public int ParentTaskId{ get; set; }
        public List<Task> SubTasks { get; set; }
        public bool Favourite { get; set; }
        public bool Done { get; set; }
    }
}
