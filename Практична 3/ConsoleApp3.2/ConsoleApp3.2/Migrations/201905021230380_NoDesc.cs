namespace ConsoleApp3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoDesc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 250, defaultValue: "No Description"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 250, defaultValue: "No Description"));
        }
    }
}
