namespace ConsoleApp4._1.Data
{
    using ConsoleApp4._1.Data.Model;
    using ConsoleApp4._1.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentDB : DbContext
    {
        // Контекст настроен для использования строки подключения "StudentDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ConsoleApp4._1.Data.StudentDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "StudentDB" 
        // в файле конфигурации приложения.
        public StudentDB()
            : base("name=StudentDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentDB, Configuration>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}