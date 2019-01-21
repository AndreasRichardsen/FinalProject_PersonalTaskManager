using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class PersonDetailDTO
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Email { get; set; }
        public List<int?> Tasks { get; set; }
    }
}