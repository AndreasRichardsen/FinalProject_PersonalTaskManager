using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaskManager.Models
{
    public class ATask
    {
        public int? Id { get; set; }
        public string TaskName { get; set; }
        public string TaskInfo { get; set; }
        public string Category { get; set; }
        public bool Favourite { get; set; }
        public bool Done { get; set; }
        public List<ATask> SubTasks { get; set; }
        //[JsonIgnore]
        //public Person Person { get; set; }
        //[JsonIgnore]
        //public ATask Task { get; set; }
    }
}