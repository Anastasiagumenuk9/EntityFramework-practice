namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Minions", "Towns_Id", c => c.Int());
            AddColumn("dbo.MinionsVillains", "Minions_Id", c => c.Int());
            AddColumn("dbo.MinionsVillains", "Villains_Id", c => c.Int());
            AddColumn("dbo.Towns", "Countries_Id", c => c.Int());
            AddColumn("dbo.Villains", "EvilnessFactors_Id", c => c.Int());
            CreateIndex("dbo.Towns", "Countries_Id");
            CreateIndex("dbo.Minions", "Towns_Id");
            CreateIndex("dbo.MinionsVillains", "Minions_Id");
            CreateIndex("dbo.MinionsVillains", "Villains_Id");
            CreateIndex("dbo.Villains", "EvilnessFactors_Id");
            AddForeignKey("dbo.Towns", "Countries_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.MinionsVillains", "Minions_Id", "dbo.Minions", "Id");
            AddForeignKey("dbo.Villains", "EvilnessFactors_Id", "dbo.EvilnessFactors", "Id");
            AddForeignKey("dbo.MinionsVillains", "Villains_Id", "dbo.Villains", "Id");
            AddForeignKey("dbo.Minions", "Towns_Id", "dbo.Towns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Minions", "Towns_Id", "dbo.Towns");
            DropForeignKey("dbo.MinionsVillains", "Villains_Id", "dbo.Villains");
            DropForeignKey("dbo.Villains", "EvilnessFactors_Id", "dbo.EvilnessFactors");
            DropForeignKey("dbo.MinionsVillains", "Minions_Id", "dbo.Minions");
            DropForeignKey("dbo.Towns", "Countries_Id", "dbo.Countries");
            DropIndex("dbo.Villains", new[] { "EvilnessFactors_Id" });
            DropIndex("dbo.MinionsVillains", new[] { "Villains_Id" });
            DropIndex("dbo.MinionsVillains", new[] { "Minions_Id" });
            DropIndex("dbo.Minions", new[] { "Towns_Id" });
            DropIndex("dbo.Towns", new[] { "Countries_Id" });
            DropColumn("dbo.Villains", "EvilnessFactors_Id");
            DropColumn("dbo.Towns", "Countries_Id");
            DropColumn("dbo.MinionsVillains", "Villains_Id");
            DropColumn("dbo.MinionsVillains", "Minions_Id");
            DropColumn("dbo.Minions", "Towns_Id");
        }
    }
}
