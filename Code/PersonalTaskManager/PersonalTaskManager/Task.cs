using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagerServer
{
    public class Task: ITask
    {
        string taskTitle = "Title";
        public string GetTaskTitle()
        {
            return taskTitle;
        }
        public void SetTaskTitle(string title)
        {
            this.taskTitle = title;
        }
    }
}
