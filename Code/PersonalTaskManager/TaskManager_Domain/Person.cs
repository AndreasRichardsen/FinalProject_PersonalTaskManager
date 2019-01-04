using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain
{
    class Person
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Email { get; set; }
        public List<TaskList> TaskLists { get; set; }

    }
}
