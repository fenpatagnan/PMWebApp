namespace PMWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project : DbMigration
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
            DropIndex("dbo.Projects", new[] { "CodeValue" });
            DropIndex("dbo.People", new[] { "Username" });
            DropTable("dbo.Projects");
            DropTable("dbo.People");
        }
    }
}
