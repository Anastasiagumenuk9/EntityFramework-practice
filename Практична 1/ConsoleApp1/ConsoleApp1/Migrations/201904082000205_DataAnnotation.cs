namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EvilnessFactors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Minions", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Villains", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Villains", "Name", c => c.String());
            AlterColumn("dbo.Towns", "Name", c => c.String());
            AlterColumn("dbo.Minions", "Name", c => c.String());
            AlterColumn("dbo.EvilnessFactors", "Name", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
        }
    }
}
