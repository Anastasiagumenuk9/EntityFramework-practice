using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3i3
{
    interface ISubject
    {
        void AddObserver(INumber n);
        void RemoveObserver(INumber n);
        void Notify();
    }
}
