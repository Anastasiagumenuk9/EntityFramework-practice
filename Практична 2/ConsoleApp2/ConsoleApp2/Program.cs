using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Choose task :");
            n = Convert.ToInt32(Console.ReadLine());

            using (SoftUniEntities context = new SoftUniEntities())
            {


                switch (n)
                {
                    case 1:
                        {
                            var employees = context.Employees.ToList().OrderBy(pn => pn.EmployeeID);

                            foreach (var e in employees)
                            {
                                Console.WriteLine(e.FirstName +  " " + e.LastName + " " + e.MiddleName + " " + e.JobTitle + " " + e.Salary.ToString().Substring(0,e.Salary.ToString().Length-2));
                            }

                            break;
                        }
                    case 2:
                        {
                            var employeeNames = context.Employees.
                                Where(s => s.Salary > 50000).
                                OrderBy(o => o.FirstName).
                                Select(name => name.FirstName);

                            foreach(var e in employeeNames)
                            {
                                Console.WriteLine(e);
                            }

                            break;
                        }
                    case 3:
                        {
                            string Department = "Research and Development";
                            var selectedEmployees = context.Employees.
                                Where(d => d.DepartmentID == 6).
                                OrderBy(o => o.Salary).
                                ThenByDescending(e => e.FirstName);
                                

                            foreach(var e in selectedEmployees)
                            {
                                if(e.DepartmentID == 6)
                                {
                                    
                                    Console.WriteLine($"{e.FirstName}  {e.LastName} from {Department} - ${e.Salary:f2}");
                                }
                                
                            }

                            break;
                        }
                    case 4:
                        {
                           /* Addresses adress = new Addresses();
                            adress.AddressText = "Vitochka17";
                            adress.TownID = 4;
                            context.Addresses.Add(adress);
                            context.SaveChanges();*/
                            
                            var newadress = context.Addresses.ToArray();
                            int newid = newadress.Last().AddressID;

                            var employe = context.Employees.
                            Where(l => l.LastName == "Nakov").
                            FirstOrDefault();

                            employe.AddressID = newid;
                            context.SaveChanges();
                            Console.WriteLine("Adress was changed!");

                            break;
                        }
                    case 5:
                        {
                            /*EmployeeProject employeeProject = new EmployeeProject();

                            var employees = context.Employees.Join(context.EmployeesProjects, // второй набор
                            p => p.EmployeeID, // свойство-селектор объекта из первого набора
                            c => c.
                            */

                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    case 8:
                        {
                            break;
                        }
                    case 9:
                        {
                            break;
                        }
                    case 10:
                        {
                            break;
                        }
                    case 11:
                        {
                            break;
                        }
                    case 12:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error");
                            break;
                        }

                }
                }
            Console.ReadKey();
        }
    }
}
