using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3i1
{
    class ConcreteSubject : ISubject
    {
        public List<IObserver> Observers { get; set; }
        private Random Random = new Random();
        public int number { get; private set; }

        public int Observer1point { get; set; }
        public int Observer2point { get; set; }
        public int Observer3point { get; set; }


        public ConcreteSubject()
        {
            Observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            Observers.Add(o);
        }

     

        public void RemoveObserver(IObserver o)
        {
            Observers.Remove(o);
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
            number++;
            Observer1point += Random.Next(100, 500);
            Observer2point += Random.Next(105, 510);
            Observer3point += Random.Next(103, 506);

            Console.WriteLine();
            Notify();

        }
    }
}
