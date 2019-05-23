namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InTown2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Towns", name: "Countries_Id", newName: "CountriesId");
            RenameIndex(table: "dbo.Towns", name: "IX_Countries_Id", newName: "IX_CountriesId");
            DropColumn("dbo.Towns", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Towns", "CountryId", c => c.Int());
            RenameIndex(table: "dbo.Towns", name: "IX_CountriesId", newName: "IX_Countries_Id");
            RenameColumn(table: "dbo.Towns", name: "CountriesId", newName: "Countries_Id");
        }
    }
}
