using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_TaskManager.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        [Required]
        public string Email { get; set; }
        public List<TaskList> TaskLists { get; set; }
    }
}