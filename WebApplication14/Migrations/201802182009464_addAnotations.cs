namespace WebApplication14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.People", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", new[] { "Email" });
            AlterColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
        }
    }
}
