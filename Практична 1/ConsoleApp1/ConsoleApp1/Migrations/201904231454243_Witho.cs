namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Witho : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Minions", "TownsId", "dbo.Towns");
            DropIndex("dbo.Minions", new[] { "TownsId" });
            AlterColumn("dbo.Minions", "TownsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Minions", "TownsId");
            AddForeignKey("dbo.Minions", "TownsId", "dbo.Towns", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Minions", "TownsId", "dbo.Towns");
            DropIndex("dbo.Minions", new[] { "TownsId" });
            AlterColumn("dbo.Minions", "TownsId", c => c.Int());
            CreateIndex("dbo.Minions", "TownsId");
            AddForeignKey("dbo.Minions", "TownsId", "dbo.Towns", "Id");
        }
    }
}
