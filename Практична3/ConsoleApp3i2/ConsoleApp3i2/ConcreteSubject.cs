using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i2
{
    class ConcreteSubject : ISubject
    {
        public List<IPost> Observers { get; set; }
        private Random Random = new Random();
   

        public string mess { get; set; }
   


        public ConcreteSubject()
        {
            Observers = new List<IPost>();
        }

        public void AddObserver(IPost p)
        {
            Observers.Add(p);
        }



        public void RemoveObserver(IPost p)
        {
            Observers.Remove(p);
        }


        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }


        public void NextPoint()
        {
            Console.WriteLine();
            Console.Write("Input message for posts : ");
            mess = Console.ReadLine();

            Console.WriteLine();
            Notify();

        }
    }
}
