using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    class Observer1 : IObserver

    {
        ISubject subject;
      

        public void Update(ISubject subject)
        {
            var cs = (ConcreteSubject)subject;
            Console.WriteLine("I'm bidder №1 and my price is " + cs.Observer1point);
        }
    }
}
