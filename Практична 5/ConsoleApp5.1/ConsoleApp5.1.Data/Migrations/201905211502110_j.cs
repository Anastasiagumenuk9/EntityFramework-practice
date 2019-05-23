namespace ConsoleApp5._1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PaymentMethods", name: "Id", newName: "PaymentMethodId");
            RenameIndex(table: "dbo.PaymentMethods", name: "IX_Id", newName: "IX_PaymentMethodId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PaymentMethods", name: "IX_PaymentMethodId", newName: "IX_Id");
            RenameColumn(table: "dbo.PaymentMethods", name: "PaymentMethodId", newName: "Id");
        }
    }
}
