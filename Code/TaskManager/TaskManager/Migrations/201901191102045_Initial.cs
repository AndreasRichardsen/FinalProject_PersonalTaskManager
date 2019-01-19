namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Category = c.String(),
                        Favourite = c.Boolean(nullable: false),
                        Done = c.Boolean(nullable: false),
                        ATask_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ATasks", t => t.ATask_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.ATask_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FamilyName = c.String(),
                        GivenName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ATasks", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ATasks", "ATask_Id", "dbo.ATasks");
            DropIndex("dbo.ATasks", new[] { "Person_Id" });
            DropIndex("dbo.ATasks", new[] { "ATask_Id" });
            DropTable("dbo.People");
            DropTable("dbo.ATasks");
        }
    }
}
