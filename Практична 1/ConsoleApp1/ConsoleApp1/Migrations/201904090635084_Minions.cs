namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Minions : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Minions", name: "Towns_Id", newName: "TownsId");
            RenameIndex(table: "dbo.Minions", name: "IX_Towns_Id", newName: "IX_TownsId");
            DropColumn("dbo.Minions", "TownId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Minions", "TownId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Minions", name: "IX_TownsId", newName: "IX_Towns_Id");
            RenameColumn(table: "dbo.Minions", name: "TownsId", newName: "Towns_Id");
        }
    }
}
