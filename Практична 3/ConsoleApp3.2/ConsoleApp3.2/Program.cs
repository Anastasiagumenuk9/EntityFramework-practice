using ConsoleApp3._2.Data;
using ConsoleApp3._2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(SalesDB context = new SalesDB())
            {
                Product p = new Product();
                p.Name = "Огірок";
                p.Price = 60;
                p.Quantity = 120;

                context.Products.Add(p);
                context.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
