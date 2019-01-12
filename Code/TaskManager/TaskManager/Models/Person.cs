using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TaskManager.Models
{
    //DataContract/DataMember for html
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string UserName { get; set; }
        [DataMember]
        public string FamilyName { get; set; }
        [DataMember]
        public string GivenName { get; set; }
        [DataMember]
        public string Email { get; set; }
        public  virtual List<ATask> Tasks { get; set; }
    }
}