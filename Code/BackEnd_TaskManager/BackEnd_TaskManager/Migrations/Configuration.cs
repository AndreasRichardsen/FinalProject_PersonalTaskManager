namespace BackEnd_TaskManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BackEnd_TaskManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackEnd_TaskManager.Models.BackEnd_TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackEnd_TaskManager.Models.BackEnd_TaskManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.People.AddOrUpdate(x => x.Id,
                new Person() { Id = 1, UserName = "Admin", FamilyName = "Simpson", GivenName = "Homer", Email = "homer.simpson@nuclear.com"},
                new Person() { Id = 2, UserName = "Hitado", FamilyName = "Hitler", GivenName = "Adolf", Email = "adolf.hitler@nuclear.com", TaskLists = new System.Collections.Generic.List<TaskList>() },
                new Person() { Id = 3, UserName = "Stajos", FamilyName = "Stalin", GivenName = "Joseph", Email = "joseph.stalin@nuclear.com", TaskLists = new System.Collections.Generic.List<TaskList>() },
                new Person() { Id = 4, UserName = "Niefri", FamilyName = "Nietzsche", GivenName = "Friedrich", Email = "friedrich.nietzsche@nuclear.com", TaskLists = new System.Collections.Generic.List<TaskList>() },
                new Person() { Id = 5, UserName = "Strbja", FamilyName = "Stroustrup", GivenName = "Bjarne", Email = "bjarne.stroustrup@nuclear.com", TaskLists = new System.Collections.Generic.List<TaskList>() }
                );

            context.TaskLists.AddOrUpdate(x => x.Id,
                new TaskList() { Id = 1, Title = "Assignments"},
                new TaskList() { Id = 2, Title = "Chores"}
                );

            context.ATasks.AddOrUpdate(x => x.Id,
                new ATask() { Id = 1, TaskName = "Clean house", TaskInfo = "Clean", Favourite = false, Done = false},
                new ATask() { Id = 2, TaskName = "Clean bathroom", TaskInfo = "Clean and scrub the toilet",ParentTaskId = 1, Favourite = false, Done = false },
                new ATask() { Id = 3, TaskName = "Clean bedroom", TaskInfo = "Clean and make the bed",ParentTaskId = 1, Favourite = false, Done = false },
                new ATask() { Id = 4, TaskName = "Fix computer", TaskInfo = "Computer wont start", Favourite = false, Done = false }
                );
        }
    }
}
