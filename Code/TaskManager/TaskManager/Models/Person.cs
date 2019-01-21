using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TaskManager.Models
{
    public class Person
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Email { get; set; }
        public List<ATask> Tasks { get; set; }
    }
}