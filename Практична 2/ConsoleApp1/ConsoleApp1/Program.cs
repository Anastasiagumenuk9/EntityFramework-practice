using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Data;
using ConsoleApp1.Data.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int n;
            Console.Write("Choose task :");
            n = Convert.ToInt32(Console.ReadLine());
            var ture = $"{Environment.NewLine}{new string('-', 10)}{Environment.NewLine}";
            using (SoftUniContext context = new SoftUniContext())
            {


                switch (n)
                {
                    case 1:
                        {
                            var employees = context.Employees.ToList().OrderBy(pn => pn.EmployeeId).The

                            foreach (var e in employees)
                            {
                                Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.MiddleName + " " + e.JobTitle + " " + e.Salary.ToString().Substring(0, e.Salary.ToString().Length - 2));
                            }

                            break;
                        }
                    case 2:
                        {
                            var employeeNames = context.Employees.
                                Where(s => s.Salary > 50000).
                                OrderBy(o => o.FirstName).
                                Select(name => name.FirstName);

                            foreach (var e in employeeNames)
                            {
                                Console.WriteLine(e);
                            }

                            break;
                        }
                    case 3:
                        {
                            string Department = "Research and Development";
                            var selectedEmployees = context.Employees.
                                Where(d => d.DepartmentId == 6).
                                OrderBy(o => o.Salary).
                                ThenByDescending(e => e.FirstName);


                            foreach (var e in selectedEmployees)
                            {
                                if (e.DepartmentId == 6)
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
                            int newid = newadress.Last().AddressId;

                            var employe = context.Employees.
                            Where(l => l.LastName == "Nakov").
                            FirstOrDefault();

                            employe.AddressId = newid;
                            context.SaveChanges();
                            Console.WriteLine("Adress was changed!");

                            break;
                        }
                    case 5:
                        {
                            EmployeeProject employeeProject = new EmployeeProject();

                            var employees = context.Employees.Join(context.EmployeesProjects,
                            p => p.EmployeeId,
                            c => c.EmployeeId,
                            (p, c) => new
                            {
                                Name = p.FirstName,
                                LastName = p.LastName,
                                ManagerFN = p.Manager.FirstName,
                                ManagerLN = p.Manager.LastName,
                                Project = c.Project.Name,
                                SDate = c.Project.StartDate,
                                eDate = c.Project.EndDate

                            }).Where(c => c.SDate.Year > 2000 && c.SDate.Year < 2004).Take(30);
                           

                            foreach (var e in employees)
                            {
                                Console.WriteLine(e.Name + " " + e.LastName + " - Manager : " + e.ManagerFN + " " + e.ManagerLN);
                                if (e.eDate.ToString() != "")
                                {
                                    
                                    Console.WriteLine("-- " + e.Project + " - " + e.SDate + "AM - " + e.eDate + " AM");
                                }
                                else
                                {
                                    Console.WriteLine("-- " + e.Project + " - " + e.SDate + "AM -  No Finshed" );
                                }
                               
                            }

                            break;
                        }
                    case 6:
                        {
                            
                             var output = string.Join(Environment.NewLine, context.Addresses
                            .OrderByDescending(a => a.Employees.Count)
                            .ThenBy(a => a.Town.Name)
                            .ThenBy(a => a.AddressText)
                            .Take(10)
                             .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));

                            Console.WriteLine(output);

                            break;
                        }
                    case 7:
                        {
                            var employee = context.Employees
                             .Select(e => new
                             {
                               e.EmployeeId,
                               e.FirstName,
                               e.LastName,
                               e.JobTitle,
                               Projects = e.EmployeesProjects
                              .Select(ep => ep.Project.Name)
                              .OrderBy(pn => pn)
                              .ToArray()
                             })
                              .FirstOrDefault(e => e.EmployeeId == 147);

                                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                                Console.WriteLine(string.Join(Environment.NewLine, employee.Projects));
                            
                            break;
                        }
                    case 8:
                        {
                            
                            var depart = string.Join(ture, context.Departments.
                                Where(d => d.Employees.Count > 5).
                                OrderBy(d => d.Employees.Count).
                                ThenBy(d => d.Name).
                                Select(d => $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}{Environment.NewLine}" + $@"{string.Join(Environment.NewLine, d.Employees
                                .OrderBy(e => e.FirstName)
                                .ThenBy(e => e.LastName)
                                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}"))}"));

                            Console.WriteLine(depart);
                            break;
                        }
                    case 9:
                        {
                            var proj = string.Join(Environment.NewLine, context.Projects
                            .OrderByDescending(p => p.StartDate)
                            .Take(10)
                            .OrderBy(p => p.Name)
                            .Select(p => $"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate.ToString()}"));
                            Console.WriteLine(proj);
                            break;
                        }
                    case 10:
                        {
                            var employees = context.Employees
                            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                            .Distinct()
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToList();

                            foreach (var e in employees)
                            {
                                e.Salary = e.Salary + ( e.Salary * Convert.ToDecimal(0.12));
                                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                            }

                            context.SaveChanges();

                            break;
                        }
                    case 11:
                        {
                            var sa = string.Join(Environment.NewLine, context.Employees
                           .Where(e => e.FirstName.StartsWith("Sa"))
                           .OrderBy(e => e.FirstName)
                           .ThenBy(e => e.LastName)
                           .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
                            Console.WriteLine(sa);
                            break;
                        }
                    case 12:
                        {
                            /*var project = context.Projects.
                               Where(p => p.ProjectId == 2);

                           var employeeProject = context.EmployeesProjects.
                               Where(p => p.ProjectId == 2);

                           context.EmployeesProjects.RemoveRange(employeeProject);
                           context.SaveChanges();

                           context.Projects.RemoveRange(project);
                           context.SaveChanges();
                           */
                            var newListOfProjects = context.Projects.ToList().Take(10);

                            foreach (var p in newListOfProjects)
                            {
                                Console.WriteLine(p.ProjectId + " " + p.Name);
                            }

                            break;
                        }
                    case 13:
                        {
                            string TownName;
                            Console.WriteLine("Input Town Name : ");
                            TownName = Console.ReadLine();
                            int idtown = 0;
                            bool flag = false;
                            
                            var towns = context.Towns.ToList();

                            foreach(var t  in towns)
                            {
                                if(t.Name == TownName)
                                {
                                    idtown = t.TownId;
                                    flag = true;
                                    break;
                                }
                                else
                                {
                                    flag = false;
                                }

                            }

                            if(flag == true)
                            {
                                int k = 0;
                                var DelAdresses = context.Employees.Where(c => c.Address.Town.TownId == idtown).ToList();

                                foreach(var d in DelAdresses)
                                {
                                    d.AddressId = null;
                                }

                                context.SaveChanges();

                                var addresses = context.Addresses.
                                    Where(t => t.TownId == idtown).ToList();

                                k = addresses.Count();

                                context.Addresses.RemoveRange(addresses);
                                
                                context.SaveChanges();

                                var newtowns = context.Towns.
                                Where(t => t.TownId == idtown);
                                context.Towns.RemoveRange(newtowns);
                                context.SaveChanges();

                                Console.WriteLine( k + " addresses in "+ TownName + " was deleted!");

                            }
                            else
                            {
                                Console.WriteLine("Town not found!");
                            }


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
