using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    class Observer3 : IObserver
    {
        

        public void Update(ISubject subject)
        {
            var cs = (ConcreteSubject)subject;
            Console.WriteLine("I'm bidder №3 and my price is " + cs.Observer3point);
        }
    }
}
