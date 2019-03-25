using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            var consub = new ConcreteSubject();
            var ob1 = new Post1();
            var ob2 = new Post2();
            var ob3 = new Post3();

            consub.AddObserver(ob1);
            consub.AddObserver(ob2);
            consub.AddObserver(ob3);

            Console.Write("Input number of messages : ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                consub.NextPoint();
            }



            Console.ReadKey();
        }
    }
}
