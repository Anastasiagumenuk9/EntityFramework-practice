namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InTowns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Towns", "CountryId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Towns", "CountryId", c => c.Int(nullable: false));
        }
    }
}
