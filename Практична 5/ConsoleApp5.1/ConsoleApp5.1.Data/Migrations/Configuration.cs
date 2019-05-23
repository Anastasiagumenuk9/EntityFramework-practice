namespace ConsoleApp5._1.Data.Migrations
{
    using ConsoleApp5._1.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp5._1.Data.BillsPS>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ConsoleApp5._1.Data.BillsPS";
            AutomaticMigrationDataLossAllowed = false;
          
        }

        protected override void Seed(ConsoleApp5._1.Data.BillsPS context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            this.MainModelsSeed(context);
        }

        public void MainModelsSeed(BillsPS context)
        {
           /* 
            User s = new User();
             s.FirstName = "Ольга";
             s.LastName = "Третяк";
             s.Password = "0987657475";
             s.Email = "Olga@mail.ru";

            User s1 = new User();
            s1.FirstName = "Анна";
            s1.LastName = "Байко";
            s1.Password = "09876";
            s1.Email = "Anna@mail.ru";

            

             context.Users.Add(s);
             context.Users.Add(s1);
             context.SaveChanges();

            CreditCard c = new CreditCard();
            c.ExpirationDate = DateTime.Now;
            c.Limit = 200;
            c.MoneyOwned = 100;

            CreditCard c1 = new CreditCard();
            c1.ExpirationDate = DateTime.Now;
            c1.Limit = 400;
            c1.MoneyOwned = 50;

            context.CreditCards.Add(c);
            context.CreditCards.Add(c1);
            context.SaveChanges();

            BankAccount b = new BankAccount();
            b.Balance = 1000;
            b.BankName = "Приват";
            b.SwiftCode = "12675";

            BankAccount b1 = new BankAccount();
            b1.Balance = 1160;
            b1.BankName = "Приват";
            b1.SwiftCode = "11345";

            context.BankAccounts.Add(b);
            context.BankAccounts.Add(b1);
            context.SaveChanges();
            */
            PaymentMethod p = new PaymentMethod();
            p.BankAccountId = 1;
            p.CreditCardId = 1;
            p.UserId = 1;
            p.Type = "Тип";

            PaymentMethod p1 = new PaymentMethod();
            p1.BankAccountId = 2;
            p1.CreditCardId = 2;
            p1.UserId = 2;
            p1.Type = "Тип";

            context.PaymentMethods.Add(p);
            context.PaymentMethods.Add(p1);
            context.SaveChanges();



        }
    }
}
