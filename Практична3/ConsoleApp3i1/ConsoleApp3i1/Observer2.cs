using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    class Observer2 : IObserver
    {
      

        public void Update(ISubject subject)
        {
            var cs = (ConcreteSubject)subject;
            Console.WriteLine("I'm bidder №2 and my price is " + cs.Observer2point);
        }
    }
}
