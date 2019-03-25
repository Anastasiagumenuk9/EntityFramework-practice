using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i2
{
    interface ISubject
    {
        void AddObserver(IPost p);
        void RemoveObserver(IPost p);
        void Notify();
    }
}
