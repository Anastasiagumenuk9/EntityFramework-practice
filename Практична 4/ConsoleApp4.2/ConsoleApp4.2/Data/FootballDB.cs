namespace ConsoleApp4._2.Data
{
    using ConsoleApp4._2.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootballDB : DbContext
    {
        // Контекст настроен для использования строки подключения "FootballDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp4._2.Data.FootballDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "FootballDB" 
        // в файле конфигурации приложения.
        public FootballDB()
            : base("name=FootballDB")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}