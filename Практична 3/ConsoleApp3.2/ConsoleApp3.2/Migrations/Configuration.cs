namespace ConsoleApp3._2.Migrations
{
    using ConsoleApp3._2.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp3._2.Data.SalesDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConsoleApp3._2.Data.SalesDB context)
        {
            
            

           

            base.Seed(context);
        }
    }
}
