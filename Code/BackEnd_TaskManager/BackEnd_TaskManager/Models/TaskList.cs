using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_TaskManager.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<ATask> Tasks { get; set; }
    }
}