namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManager.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.Models.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskManager.Models.TaskManagerContext context)
        {
            bool exists = context.People.Any(x => x.Id == 1);

            if (!exists)
            {
                context.People.AddOrUpdate(InitialiseData());
            }
        }
        public Person InitialiseData()
        {
            Person admin = MakePerson("Admin", "Simpson", "Homer", "homer.simpson@nuclear.com");

            ATask t1 = MakeTask("Fix computer", "Computer fked.", "IT", person: admin);
                ATask t2 = MakeTask("Get Parts", "Buy Power supply", aTask: t1);
                ATask t3 = MakeTask("Install software", "Install needed software", aTask: t1);
                    ATask t4 = MakeTask("Windows", "Windows 7", aTask: t3);
                    ATask t5 = MakeTask("Office", "Office 2013", aTask: t3);
                    ATask t6 = MakeTask("UMLet", "Tool for fast UML diagrams", aTask: t3);

            ATask t7 = MakeTask("clean house", "clean the house", "Chores", person: admin);
                ATask t8 = MakeTask("Clean bathroom", "Bathroom is dirty", aTask: t7);
                    ATask t9 = MakeTask("Toilette", "Scrub the toilette", aTask: t8);
                    ATask t10 = MakeTask("Shower", "Scrub the shower", aTask: t8);
                ATask t11 = MakeTask("Clean bedroom", "Bedroom is dirty", aTask: t7);
                    ATask t12 = MakeTask("Bed", "Make the bed", aTask: t11);
                    ATask t13 = MakeTask("Closet", "Organise the closet", aTask: t11);

            return admin;
        }

        public static Person MakePerson(string userName, string familyName, string givenName, string email)
        {
            Person person = new Person { UserName = userName, FamilyName = familyName, GivenName = givenName, Email = email };
            person.Tasks = new List<ATask>();
            return person;
        }

        public static ATask MakeTask(string taskName, string taskInfo, string category = null, bool favourite = false, bool done = false, Person person = null, ATask aTask = null)
        {
            ATask task = new ATask { TaskName = taskName, TaskInfo = taskInfo, Category = category, Favourite = favourite, Done = done };
            task.SubTasks = new List<ATask>();
            if (person != null) { person.Tasks.Add(task); };
            if(aTask != null) { aTask.SubTasks.Add(task); };
            return task;
        }
    }
}
