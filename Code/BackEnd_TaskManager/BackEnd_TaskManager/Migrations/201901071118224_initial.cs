namespace BackEnd_TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        TaskInfo = c.String(),
                        ParentTaskId = c.Int(nullable: false),
                        Favourite = c.Boolean(nullable: false),
                        Done = c.Boolean(nullable: false),
                        ATask_Id = c.Int(),
                        TaskList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ATasks", t => t.ATask_Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskList_Id)
                .Index(t => t.ATask_Id)
                .Index(t => t.TaskList_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FamilyName = c.String(),
                        GivenName = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskLists", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ATasks", "TaskList_Id", "dbo.TaskLists");
            DropForeignKey("dbo.ATasks", "ATask_Id", "dbo.ATasks");
            DropIndex("dbo.TaskLists", new[] { "Person_Id" });
            DropIndex("dbo.ATasks", new[] { "TaskList_Id" });
            DropIndex("dbo.ATasks", new[] { "ATask_Id" });
            DropTable("dbo.TaskLists");
            DropTable("dbo.People");
            DropTable("dbo.ATasks");
        }
    }
}
