using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TaskManager.Models
{
    //DataContract/DataMember for html
    [DataContract]
    public class ATask
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string TaskName { get; set; }
        [DataMember]
        public string TaskInfo { get; set; }
        [DataMember]
        public string Category { get; set; }
        public virtual List<ATask> SubTasks { get; set; }
        [DataMember]
        public bool Favourite { get; set; }
        [DataMember]
        public bool Done { get; set; }
        public virtual Person Person { get; set; }
        public virtual ATask Task { get; set; }
    }
}