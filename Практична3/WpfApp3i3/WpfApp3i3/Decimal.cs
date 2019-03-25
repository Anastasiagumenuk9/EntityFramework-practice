using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3i3
{
    class Decimal : INumber
    {
        ISubject subject;
        public string s { get; set; }

        public void Update(ISubject subject)
        {
            var cs = (ConcreteSubject)subject;
            Console.WriteLine("It is a message for post №1 : " + cs.ObserverDec);
        }
    }
}
