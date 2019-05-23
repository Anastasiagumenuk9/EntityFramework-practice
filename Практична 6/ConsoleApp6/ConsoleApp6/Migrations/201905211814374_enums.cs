namespace ConsoleApp6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "EditionType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "EditionType", c => c.String());
        }
    }
}
