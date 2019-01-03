using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerServer
{
    public interface ITask
    {
        string GetTaskTitle();
        void SetTaskTitle(string title);
    }
}
