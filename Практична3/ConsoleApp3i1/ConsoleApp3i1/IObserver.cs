using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
     interface IObserver
    {
         void Update(ISubject subject);
    }
}
