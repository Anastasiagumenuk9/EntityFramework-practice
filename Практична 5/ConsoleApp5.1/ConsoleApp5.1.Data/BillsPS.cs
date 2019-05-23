namespace ConsoleApp5._1.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection.Emit;
    using ConsoleApp5._1.Data.EntityConfig;
    using ConsoleApp5._1.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BillsPS : System.Data.Entity.DbContext
    {
        
        // Контекст настроен для использования строки подключения "BillsPS" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp5._1.Data.BillsPS" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "BillsPS" 
        // в файле конфигурации приложения.
        public BillsPS()
            : base("name=BillsPS")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual System.Data.Entity.DbSet<BankAccount> BankAccounts { get; set; }
        public virtual System.Data.Entity.DbSet<User> Users { get; set; }
        public virtual System.Data.Entity.DbSet<CreditCard> CreditCards { get; set; }
        public virtual System.Data.Entity.DbSet<PaymentMethod> PaymentMethods { get; set; }

      /*  protected  void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<PaymentMethod>()
                .Property(p => p.Type)
                .HasComputedColumnSql("[BankAccount] + ', ' + [CreditCard]");
        }*/
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}