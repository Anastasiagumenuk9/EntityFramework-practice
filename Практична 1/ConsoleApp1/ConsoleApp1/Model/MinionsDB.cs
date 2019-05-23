namespace ConsoleApp1.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MinionsDB : DbContext
    {
        // Контекст настроен для использования строки подключения "MinionsDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp1.Model.MinionsDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MinionsDB" 
        // в файле конфигурации приложения.
        public MinionsDB()
            : base("name=MinionsDB")
        {
        }

        public DbSet<Towns> Towns { get; set; }
        public DbSet<Minions> Minions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<EvilnessFactors> EvilnessFactors { get; set; }
        public DbSet<MinionsVillains> MinionsVillains { get; set; }
        public DbSet<Villains> Villains { get; set; }


        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}