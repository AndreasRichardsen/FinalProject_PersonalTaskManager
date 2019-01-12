namespace TaskManager.Migrations
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
                        TaskName = c.String(nullable: false),
                        TaskInfo = c.String(),
                        Category = c.String(),
                        Favourite = c.Boolean(nullable: false),
                        Done = c.Boolean(nullable: false),
                        Person_Id = c.Int(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.ATasks", t => t.Task_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FamilyName = c.String(),
                        GivenName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ATasks", "Task_Id", "dbo.ATasks");
            DropForeignKey("dbo.ATasks", "Person_Id", "dbo.People");
            DropIndex("dbo.ATasks", new[] { "Task_Id" });
            DropIndex("dbo.ATasks", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.ATasks");
        }
    }
}
