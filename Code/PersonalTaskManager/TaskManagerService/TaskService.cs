using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TaskManagerServer;

namespace TaskManager_ServiceLibrary
{
    public class TaskService : ITaskService
    {
        private static ITask taskObj = new Task();
        public string GetTaskTitle()
        {
            return taskObj.GetTaskTitle();
        }

        public void SetTaskTitle(string title)
        {
            taskObj.SetTaskTitle(title);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
