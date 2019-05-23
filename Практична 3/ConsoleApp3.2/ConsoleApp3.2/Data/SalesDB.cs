namespace ConsoleApp3._2.Data
{
    using ConsoleApp3._2.Data.Model;
    using ConsoleApp3._2.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class SalesDB : DbContext
    {
        // Контекст настроен для использования строки подключения "SalesDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp3._2.Data.SalesDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "SalesDB" 
        // в файле конфигурации приложения.
        public SalesDB()
            : base("name=SalesDB")
        {
            Database.SetInitializer<SalesDB>(new UniDBInitializer<SalesDB>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }



        private class UniDBInitializer<T> : DropCreateDatabaseAlways<SalesDB>
        {

            protected override void Seed(SalesDB context)
            {
                /*
                IList<Product> products = new List<Product>();

                products.Add(new Product()
                {
                    Name = "Мюслі",
                    Price = 45,
                    Quantity = 134
                });

                products.Add(new Product()
                {
                    Name = "Селера",
                    Price = 54,
                    Quantity = 140
                });

                products.Add(new Product()
                {
                    Name = "Капуста",
                    Price = 41,
                    Quantity = 150
                });

                foreach (var p in products)
                {
                    context.Products.Add(p);
                }
                */
                base.Seed(context);
            }
        }
    }
}
        
    