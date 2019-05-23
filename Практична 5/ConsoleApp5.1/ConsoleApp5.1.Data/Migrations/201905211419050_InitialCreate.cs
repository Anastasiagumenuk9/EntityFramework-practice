namespace ConsoleApp5._1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        Balance = c.Single(nullable: false),
                        BankName = c.String(maxLength: 50),
                        SwiftCode = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BankAccountId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        CreditCardId = c.Int(nullable: false),
                        Type = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardId = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                        Limit = c.Single(nullable: false),
                        MoneyOwned = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 80),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentMethods", "UserId", "dbo.Users");
            DropForeignKey("dbo.PaymentMethods", "Id", "dbo.CreditCards");
            DropForeignKey("dbo.PaymentMethods", "Id", "dbo.BankAccounts");
            DropIndex("dbo.PaymentMethods", new[] { "UserId" });
            DropIndex("dbo.PaymentMethods", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.CreditCards");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.BankAccounts");
        }
    }
}
