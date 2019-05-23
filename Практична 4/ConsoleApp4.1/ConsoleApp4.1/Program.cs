using ConsoleApp4._1.Data;
using ConsoleApp4._1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StudentDB context = new StudentDB())
            {
                //context.Database.Initialize(true);

                Console.WriteLine("Iнформацiя про курси : ");
                var courses = context.Courses.ToList();
                foreach(var c in courses)
                {
                    Console.WriteLine(c.CourseId + " " + c.Name + " " + c.Price);
                }

                Console.WriteLine("Iнформацiя про cтудентiв : ");
                var students = context.Students.ToList();
                foreach (var c in students)
                {
                    Console.WriteLine(c.StudentId + " " + c.Name + " " + c.PhoneNumber + " " + c.Birthday);
                    
                }
            }
            Console.ReadKey();
        }
    }
}
