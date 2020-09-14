namespace PMWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 200),
                        Password = c.String(maxLength: 11),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.PersonProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.PersonId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeValue = c.String(maxLength: 8),
                        Name = c.String(nullable: false, maxLength: 255),
                        Remarks = c.String(maxLength: 255),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CodeValue, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.PersonProjects", "PersonId", "dbo.People");
            DropIndex("dbo.Projects", new[] { "CodeValue" });
            DropIndex("dbo.PersonProjects", new[] { "PersonId" });
            DropIndex("dbo.PersonProjects", new[] { "ProjectId" });
            DropIndex("dbo.People", new[] { "Username" });
            DropTable("dbo.Projects");
            DropTable("dbo.PersonProjects");
            DropTable("dbo.People");
        }
    }
}
