namespace ConsoleApp6.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopDB : DbContext
    {
        // Контекст настроен для использования строки подключения "BookShopDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp6.Models.BookShopDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "BookShopDB" 
        // в файле конфигурации приложения.
        public BookShopDB()
            : base("name=BookShopDB")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Author> Authors { get; set; }
         public virtual DbSet<Book> Books { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}