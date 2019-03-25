using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i2
{
    class Post2: IPost
    {
        ISubject subject;


        public void Update(ISubject subject)
        {
            var cs = (ConcreteSubject)subject;
            Console.WriteLine("It is a message for post №1 : " + cs.mess);
        }
    }
}
