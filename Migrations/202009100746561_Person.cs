namespace PMWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 200),
                        Lastname = c.String(),
                        Password = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            AlterColumn("dbo.Projects", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", new[] { "Username" });
            AlterColumn("dbo.Projects", "DateCreated", c => c.DateTime());
            DropTable("dbo.People");
        }
    }
}
