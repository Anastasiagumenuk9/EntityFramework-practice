using ConsoleApp1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static MinionsDB db = new MinionsDB();

        public static void Procedure()
        {
            Console.Write("Input id: ");
            int idminion = Convert.ToInt32(Console.ReadLine());

            var minions2 = db.Minions
                .Where(o => o.Id == idminion)
                .AsEnumerable()

                 .Select(c => {
                
                     c.Age = c.Age + 1;
                     return c;
                 });

            foreach (var m in minions2)
            {

                db.Entry(m).State = EntityState.Modified;

            }

            db.SaveChanges();
            Console.WriteLine();

            var newminions = db.Minions.ToList();

            foreach (Minions i in newminions)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Age);
            }
        }

        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Number Of Minions");
            Console.WriteLine("Minion Names");
            Console.WriteLine("Add Minion");
            Console.WriteLine("Register ToUper");
            Console.WriteLine("Remove Villain");
            Console.WriteLine("Print All Minion Names");
            Console.WriteLine("Problem №7");
            Console.WriteLine("Problem №8");

            Console.WriteLine("Оберiть пункт : ");
            n = Convert.ToInt32(Console.ReadLine());
            using (MinionsDB context = new MinionsDB())
            {
                /* Countries countries = new Countries();
                 countries.Name = "Italy";
                 context.Countries.Add(countries);
                 context.SaveChanges();

                 Towns towns = new Towns();
                 towns.Name = "Berlin";
                 towns.CountriesId = 4;
                 context.Towns.Add(towns);
                 context.SaveChanges();

                 Minions minions = new Minions();
                 minions.Name = "Nike";
                 minions.Age = 28;
                 minions.TownsId = 2;
                 context.Minions.Add(minions);
                 context.SaveChanges();

                 EvilnessFactors evilnessFactors = new EvilnessFactors();
                 evilnessFactors.Name = "Super good";
                 context.EvilnessFactors.Add(evilnessFactors);
                 context.SaveChanges();

                 Villains villains = new Villains();
                 villains.Name = "Mary";
                 villains.EvilnessFactorsId = 2;
                 context.Villains.Add(villains);
                 context.SaveChanges();

                 MinionsVillains minionsVillains = new MinionsVillains();
                 minionsVillains.MinionsId = 9;
                 minionsVillains.VillainsId = 2;
                 context.MinionsVillains.Add(minionsVillains);
                 context.SaveChanges();

            */
            
                switch (n)
                {
                    case 1:
                        {
                            var v1 = from vm in context.MinionsVillains
                                     group new { vm.Villains, vm } by new
                                     {
                                         vm.Villains.Name
                                     } into g
                                     where g.Count() >= 3
                                     orderby
                                       g.Count() descending
                                     select new
                                     {
                                         g.Key.Name,
                                         NumberOfMinions = g.Count()
                                     };

                            foreach (var i in v1)
                            {
                                Console.WriteLine(i.Name + " - " + i.NumberOfMinions);
                            }
                            break;
                        }

                    case 2:
                        {
                            int? id;
                            int t = 0;
                             Console.WriteLine("Input Id : ");
                             id = Convert.ToInt32(Console.ReadLine());

                            var v2 = from v in context.Villains
                                     join vm in context.MinionsVillains on new { VillainsId = v.Id } equals new { vm.VillainsId } into vm_join
                                     from vm in vm_join.DefaultIfEmpty()
                                     join m in context.Minions on new { Id = vm.MinionsId } equals new { m.Id } into m_join
                                     from m in m_join.DefaultIfEmpty()
                                     where
                                       v.Id == id
                                     select new
                                     {
                                         VillainName = v.Name,
                                         MinionName = m.Name,
                                         MinionAge = m.Age
                                     };

                                    foreach (var i in v2)
                                     {
                                      t++;
                                      if (t == 1)
                                     Console.WriteLine(i.VillainName);
                                     Console.WriteLine(t + "." + i.MinionName + " " + i.MinionAge);
                                      }




                            break;
                        }
                    case 3:
                        {
                            string name;
                            int age;
                           
                            string townName;
                            string villainName;

                            String s;
                            Console.Write("Add Minion : ");
                            s = Console.ReadLine();
                            String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            name = words[0].ToString();
                            age = Convert.ToInt32(words[1]);
                            townName = words[2];

                            Minions minions = new Minions();

                            Console.WriteLine("Input name of Villain : ");
                             villainName = Console.ReadLine();

                            Towns towns = new Towns();
                            var Ttowns = context.Towns.ToList();

                            bool flag = false;
                            bool flag1 = false;
                            int idd = 0;
                            foreach(var t in Ttowns)
                            {
                                if( t.Name == words[2])
                                {
                                    idd = t.Id;
                                    flag = true;
                                    break;
                                   
                                }
                                else if(t.Name != words[2])
                                {

                                    flag = false;
                                }
                            }

                            if(flag == true)
                            {
                                minions.TownsId = idd;
                                minions.Name = name;
                                minions.Age = age;
                                context.Minions.Add(minions);
                                context.SaveChanges();
                                Console.WriteLine("You have this town ");
                            }
                            else
                            {
                                towns.Name = words[2];
                                context.Towns.Add(towns);
                                context.SaveChanges();

                                var newtowns = context.Towns.ToList();
                                minions.Name = name;
                                minions.Age = age;
                                foreach(var t in newtowns)
                                {
                                    if (t.Name == townName)
                                    {
                                        minions.TownsId = t.Id;
                                    }
                                }

                                context.Minions.Add(minions);
                                context.SaveChanges();
                                Console.WriteLine("This town were added to DB");
                            }



                            Villains villains = new Villains();
                                var villainss = context.Villains.ToList();
                                int idvillain = 0;
                                int idminion = 0;
                                var minionss = context.Minions.ToList();
                                MinionsVillains minionsVillains = new MinionsVillains();

                                foreach(var v in villainss)
                                {
                                    if( villainName == v.Name)
                                    {
                                        idvillain = v.Id;
                                        flag1 = true;
                                        break;
                                    }
                                    else if(villainName != v.Name)
                                    {
                                        flag1 = false;
                                    }
                                }

                                if(flag1 == true)
                                {
                                    
                                    idminion = minionss.Last().Id;
                                    minionsVillains.MinionsId = idminion;
                                    minionsVillains.VillainsId = idvillain;
                                    context.MinionsVillains.Add(minionsVillains);
                                    context.SaveChanges();
                                    Console.WriteLine("You have this villain ");
                                }
                                else
                                {
                                  villains.Name = villainName;
                                  villains.EvilnessFactorsId = 5;
                                  context.Villains.Add(villains);
                                  context.SaveChanges();

                                var newvillains = context.Villains.ToList();////////////

                                  idminion = minionss.Last().Id;
                                  minionsVillains.MinionsId = idminion;
                                minionsVillains.VillainsId = newvillains.Last().Id;

                                 context.MinionsVillains.Add(minionsVillains);
                                 context.SaveChanges();

                                Console.WriteLine("This villain were added to DB");

                                }

                                
                            break;
                            
                        }
                    case 4:
                        {
                            string countryName;
                            Console.WriteLine("Input name of Country : ");
                            countryName = Console.ReadLine();
                            bool flag = false;
                            int k = 0;
                            int idcountry = 0;
                            var countries = context.Countries.ToList();

                            foreach(var c in countries)
                            {
                                if(c.Name == countryName)
                                {
                                    idcountry = c.Id;
                                    flag = true;
                                    break;
                                }
                                else
                                {
                                    flag = false;
                                }
                            }

                            if (flag == true)
                            {
                                var towns = context.Towns
                                .Where(c => c.CountriesId == idcountry)
                                .AsEnumerable()
                                .Select(c => {
                                    c.Name = c.Name.ToUpper();
                                    k++;
                                    return c;
                                });
                                foreach (var t in towns)
                                {

                                    context.Entry(t).State = EntityState.Modified;

                                }

                                context.SaveChanges();
                                Console.WriteLine(k + " towns names were affected");
                                Console.Write("[");
                                var newtowns = context.Towns.ToList();
                                foreach(var nt in newtowns)
                                {
                                    if(nt.CountriesId == idcountry)
                                    {
                                        Console.Write( nt.Name + " " );
                                    }
                                }
                                Console.Write("]");



                            }
                            else
                            {
                                Console.WriteLine("No town names were affected");
                            }

                            break;
                        }
                    case 5:
                        {
                            int idvillain;
                            Console.WriteLine("Input Id of villain: ");
                            idvillain = Convert.ToInt32(Console.ReadLine());
                            bool flag = false;
                            int k = 0;

                            var villains = context.Villains.ToList();

                            foreach (var c in villains)
                            {
                                if (c.Id == idvillain)
                                {
                                   
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

                                var minionsVillain = context.MinionsVillains.ToList();
                                

                                Villains villain = context.Villains
                                 .Where(c => c.Id == idvillain)
                                .FirstOrDefault();

                                context.Entry(villain)
                                    .Collection(c => c.MinionsVillains)
                                    .Load();
                                
                                context.Villains.Remove(villain);
                                context.SaveChanges();

                                var minionsVillain1 = context.MinionsVillains.ToList();
                                k = minionsVillain.Count - minionsVillain1.Count;
                                Console.WriteLine(k + " minions were released");
                            }
                            else
                            {
                                Console.WriteLine("No such villain was found");
                            }

                            break;
                        }
                    case 6:
                        {
                            var minions = context.Minions.ToArray();
                            Minions first;
                            Minions last;
                            int firstCount = 0;
                            int lastCount = 0;
                            int lastindex = minions.Count() - 1;
                            first = minions[0];
                            last = minions[lastindex];
                            if (minions.Count() % 2 == 0)
                            {
                                for (int i = 0; i < minions.Count()/2; i++)
                                {
                                    Console.WriteLine(minions[0 + i].Name );
                                    Console.WriteLine(minions[lastindex - i].Name );

                                }


                            }
                            else
                            {
                                string name;
                                int age;
                         
                                Console.WriteLine("Add Minion for continue : ");
                                Console.Write("Name : ");
                                name = Console.ReadLine();
                                Console.Write("Age : ");
                                age = Convert.ToInt32(Console.ReadLine());
                          

                                Minions min = new Minions();
                                min.Name = name;
                                min.Age = age;
                                min.TownsId = 2;
                                context.Minions.Add(min);
                                context.SaveChanges();

                                var newminions = context.Minions.ToArray();
                                for (int i = 0; i < newminions.Count() / 2; i++)
                                {
                                    Console.WriteLine(newminions[0 + i].Name);
                                    Console.WriteLine(newminions[newminions.Count() -1  - i].Name);

                                }
                            }



                            break;
                        }
                    case 7:
                        {
                            /*string mas;
                            Console.Write("Input IDs Of Minions : ");
                            mas = Console.ReadLine();
                            int[] mass = mas.Split(' ').Select(int.Parse).ToArray();
                            ArrayList masss = mas.Split(' ').Select(int.Parse).ToArrayList();

                            var queryMinions =
                             from Minions in context.Minions
                                where
                                (new System.Int32[] { mass }).Contains(Minions.Id)
                                select Minions;
                            foreach (var Minions in queryMinions)
                            {
                                Minions.Name = ((Minions.Name.Substring(0, 1)).ToUpper() + (Minions.Name.Substring(Minions.Name.Length - (int)Minions.Name.Length - 1, (int)Minions.Name.Length - 1)).ToLower());
                                Minions.Age += 1;
                            }
                            context.SaveChanges();*/

                            Console.Write("Input id: ");
                            int idminion = Convert.ToInt32(Console.ReadLine());
                            
                            var minions2 = context.Minions
                                .Where(o => o.Id == idminion)
                                .AsEnumerable()
     
                                 .Select(c => {
                                     c.Name = c.Name.Substring(0, 1).ToUpper() + (c.Name.Substring(1, c.Name.Length-1).ToLower());
                                     c.Age = c.Age + 1;
                                     return c;
                                   });

                            foreach (var m in minions2)
                            {
                               
                                context.Entry(m).State = EntityState.Modified;

                            }
                            
                            context.SaveChanges();
                            Console.WriteLine();

                            var newminions = context.Minions.ToList();

                            foreach (Minions i in newminions)
                            {
                                Console.WriteLine(i.Id + " " + i.Name + " " + i.Age);
                            }
                              

                            
                            break;
                        }
                    case 8:
                        {
                            Procedure();
                            break;
                        }

                    default:
                        {

                          Console.WriteLine( " Error !");
                            break;
                        }
                }
            }
                    Console.ReadKey();
        }
    }
}
