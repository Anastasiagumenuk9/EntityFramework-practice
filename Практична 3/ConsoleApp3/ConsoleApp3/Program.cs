using ConsoleApp3.Data.Model;
using ConsoleApp3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Гостьовий вхiд");
            Console.WriteLine("2.Реєстрацiя");
            Console.WriteLine("3.Мiй кабiнет");
            Console.WriteLine();

            int n;
            n = Convert.ToInt32(Console.ReadLine());
            using (Hospital context = new Hospital())
            {
                switch (n)
            {
                case 1:
                    {
                            Console.WriteLine("Ласкаво просимо, гiсть!");
                        break;
                    }
                case 2:
                    {
                            string login;
                            string password;
                            bool flag = false;
                            string name;
                            string speciality;
                            Console.Write("Ваше iм'я : ");
                            name = Console.ReadLine();

                            Console.Write("Вашa cпецiальнiсть : ");
                            speciality = Console.ReadLine();

                            Console.Write("Введiть свiй логiн : ");
                            login = Console.ReadLine();

                            Console.Write("Введiть свiй пароль : ");
                            password = Console.ReadLine();

                            Doctors doc = new Doctors();
                            doc.Name = name;
                            doc.Speciality = speciality;
                            doc.Password = password;
                            doc.Login = login;
                            context.Doctors.Add(doc);
                            context.SaveChanges();

                            Console.WriteLine("Реєстрацiя пройшла успiшно!");
                            break;
                    }
                case 3:
                    {
                            string login;
                            string password;
                            bool flag = false;
                            string name = "";
                            Console.Write("Введiть свiй логiн : ");
                            login = Console.ReadLine();
                         
                            Console.Write("Введiть свiй пароль : ");
                            password = Console.ReadLine();

                            var doctors = context.Doctors.ToList();
                            foreach (var d in doctors)
                            {
                                if (d.Login == login && d.Password == password)
                                {
                                    flag = true;
                                    name = d.Name;
                                    break;

                                }
                                else
                                {
                                    flag = false;

                                }
                            }


                                if (flag == true)
                                {
                                    Console.WriteLine("Ласкаво просимо, " + name);
                                }
                                else
                                {
                                    Console.WriteLine("Пароль або логiн не вiрний!");
                                }
                            

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Виберiть щось з iснуючого списку");
                        break;
                    }
            }

         
              /*  Patients p = new Patients();
                p.Address = "L.Ukrainky, 29";
                p.Email = "Anna@mail.com";
                p.FirstName = "Anna";
                p.HasInsurance = true;
                p.LastName = "Boyko";

                context.Patients.Add(p);
                context.SaveChanges();*/


                

            }

            Console.WriteLine("");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
