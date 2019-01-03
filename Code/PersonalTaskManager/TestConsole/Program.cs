using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static TaskReference.ITaskService taskObj = new TaskReference.TaskServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine(taskObj.GetTaskTitle());

            taskObj.SetTaskTitle(Console.ReadLine());


            Console.WriteLine(taskObj.GetTaskTitle());

            Console.ReadLine();
        }
    }
}
