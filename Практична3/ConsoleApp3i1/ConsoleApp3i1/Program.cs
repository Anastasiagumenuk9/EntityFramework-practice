using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            var consub = new ConcreteSubject();
            var ob1 = new Observer1();
            var ob2 = new Observer2();
            var ob3 = new Observer3();

            consub.AddObserver(ob1);
            consub.AddObserver(ob2);
            consub.AddObserver(ob3);

            Console.Write("Input number of rates : ");
            n = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                consub.NextPoint();
            }
        
             

            Console.ReadKey();

        }
    }
}
