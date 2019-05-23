namespace ConsoleApp4._1.Migrations
{
    using ConsoleApp4._1.Data;
    using ConsoleApp4._1.Data.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp4._1.Data.StudentDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "ConsoleApp4._1.Data.StudentDB";
        }

        protected override void Seed(ConsoleApp4._1.Data.StudentDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            this.MainModelsSeed(context);
        }

        private void MainModelsSeed(StudentDB context)
        {
            /*
            Student s = new Student();
             s.Name = "Ольга";
             s.Birthday = DateTime.Now;
             s.PhoneNumber = "0987657475";
             s.RegisteredOn = true;

             Student s1 = new Student();
             s1.Name = "Марина";
             s.Birthday = DateTime.Now;
             s.PhoneNumber = "0987656676";
             s.RegisteredOn = true;



             context.Students.Add(s);
             context.Students.Add(s1);
             context.SaveChanges();
             /*
             Course c1 = new Course();
             c1.Description = " ";
             c1.EndDate = DateTime.Now;
             c1.Name = "Курс Програмування На C#";
             c1.Price = 20000;
             c1.StartDate = DateTime.Now;


             Course c2 = new Course();
             c2.Description = " ";
             c2.EndDate = DateTime.Now;
             c2.Name = "Курс Програмування На Java ";
             c2.Price = 20300;
             c2.StartDate = DateTime.Now;

             context.Courses.Add(c1);
             context.Courses.Add(c2);
             context.SaveChanges();

              Resource r1 = new Resource();
             r1.CourseId = 1;
             r1.Name = "Фото";
             r1.ResourceType = "Photo";
             r1.Url = @"Foto\532824.jpg";

             Resource r2 = new Resource();
             r2.CourseId = 2;
             r2.Name = "Фото";
             r2.ResourceType = "Photo";
             r2.Url = @"Foto\photo1.jpg";


              context.Resources.Add(r1);
             context.Resources.Add(r2);
             context.SaveChanges();
             

            HomeworkSubmission h1 = new HomeworkSubmission();
            h1.ContentType = "Application";
            h1.CourseId = 1;
            h1.StudentId = 22;
            h1.SubmissionTime = DateTime.Now;

            HomeworkSubmission h2 = new HomeworkSubmission();
            h2.ContentType = "Pdf";
            h2.CourseId = 2;
            h2.StudentId = 23;
            h2.SubmissionTime = DateTime.Now;

            

            context.HomeworkSubmissions.Add(h1);
             context.HomeworkSubmissions.Add(h2);
            context.SaveChanges();


           


            StudentCourse st1 = new StudentCourse();
            st1.CourseId = 1;
            st1.StudentId = 22;

            StudentCourse st2 = new StudentCourse();
            st2.CourseId = 2;
            st2.StudentId = 23;

            

            context.StudentCourses.Add(st1);
            context.StudentCourses.Add(st2);
            context.SaveChanges();
            */
          
        }
    }
}
