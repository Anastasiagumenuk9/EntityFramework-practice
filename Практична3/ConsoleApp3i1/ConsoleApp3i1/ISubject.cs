using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    interface ISubject
    {
        
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void Notify();
 
    }
}
