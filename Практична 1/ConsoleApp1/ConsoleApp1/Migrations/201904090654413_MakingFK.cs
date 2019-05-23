namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MinionsVillains", name: "Minions_Id", newName: "MinionsId");
            RenameColumn(table: "dbo.MinionsVillains", name: "Villains_Id", newName: "VillainsId");
            RenameColumn(table: "dbo.Villains", name: "EvilnessFactors_Id", newName: "EvilnessFactorsId");
            RenameIndex(table: "dbo.MinionsVillains", name: "IX_Minions_Id", newName: "IX_MinionsId");
            RenameIndex(table: "dbo.MinionsVillains", name: "IX_Villains_Id", newName: "IX_VillainsId");
            RenameIndex(table: "dbo.Villains", name: "IX_EvilnessFactors_Id", newName: "IX_EvilnessFactorsId");
            DropColumn("dbo.MinionsVillains", "MinionId");
            DropColumn("dbo.MinionsVillains", "VillainId");
            DropColumn("dbo.Villains", "EvilnessFactorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Villains", "EvilnessFactorId", c => c.Int(nullable: false));
            AddColumn("dbo.MinionsVillains", "VillainId", c => c.Int(nullable: false));
            AddColumn("dbo.MinionsVillains", "MinionId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Villains", name: "IX_EvilnessFactorsId", newName: "IX_EvilnessFactors_Id");
            RenameIndex(table: "dbo.MinionsVillains", name: "IX_VillainsId", newName: "IX_Villains_Id");
            RenameIndex(table: "dbo.MinionsVillains", name: "IX_MinionsId", newName: "IX_Minions_Id");
            RenameColumn(table: "dbo.Villains", name: "EvilnessFactorsId", newName: "EvilnessFactors_Id");
            RenameColumn(table: "dbo.MinionsVillains", name: "VillainsId", newName: "Villains_Id");
            RenameColumn(table: "dbo.MinionsVillains", name: "MinionsId", newName: "Minions_Id");
        }
    }
}
