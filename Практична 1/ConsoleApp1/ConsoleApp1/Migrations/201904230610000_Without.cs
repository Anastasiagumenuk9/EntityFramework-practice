namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Without : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MinionsVillains", "MinionsId", "dbo.Minions");
            DropForeignKey("dbo.MinionsVillains", "VillainsId", "dbo.Villains");
            DropIndex("dbo.MinionsVillains", new[] { "MinionsId" });
            DropIndex("dbo.MinionsVillains", new[] { "VillainsId" });
            AlterColumn("dbo.MinionsVillains", "MinionsId", c => c.Int(nullable: false));
            AlterColumn("dbo.MinionsVillains", "VillainsId", c => c.Int(nullable: false));
            CreateIndex("dbo.MinionsVillains", "MinionsId");
            CreateIndex("dbo.MinionsVillains", "VillainsId");
            AddForeignKey("dbo.MinionsVillains", "MinionsId", "dbo.Minions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MinionsVillains", "VillainsId", "dbo.Villains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MinionsVillains", "VillainsId", "dbo.Villains");
            DropForeignKey("dbo.MinionsVillains", "MinionsId", "dbo.Minions");
            DropIndex("dbo.MinionsVillains", new[] { "VillainsId" });
            DropIndex("dbo.MinionsVillains", new[] { "MinionsId" });
            AlterColumn("dbo.MinionsVillains", "VillainsId", c => c.Int());
            AlterColumn("dbo.MinionsVillains", "MinionsId", c => c.Int());
            CreateIndex("dbo.MinionsVillains", "VillainsId");
            CreateIndex("dbo.MinionsVillains", "MinionsId");
            AddForeignKey("dbo.MinionsVillains", "VillainsId", "dbo.Villains", "Id");
            AddForeignKey("dbo.MinionsVillains", "MinionsId", "dbo.Minions", "Id");
        }
    }
}
