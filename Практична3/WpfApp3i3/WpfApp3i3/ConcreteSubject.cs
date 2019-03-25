using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WpfApp3i3
{
    class ConcreteSubject : ISubject
    {

        public List<INumber> Observers { get; set; }
     
        MainWindow mw = new MainWindow();

        public int ObserverDec { get; set; }
        public int ObserverBin { get; set; }
        public int ObserverOctal { get; set; }
        public int ObserverHex { get; set; }




        public ConcreteSubject()
        {
            Observers = new List<INumber>();
        }

        public void AddObserver(INumber n)
        {
            Observers.Add(n);
        }



        public void RemoveObserver(INumber n)
        {
            Observers.Remove(n);
        }


        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }

        }


        public void NextNumber()
        {
            if(mw.RB1.IsEnabled == true)
            {
           //ObserverDec = Convert.ToInt32(mw.TB1.Text);
            mw.TB2.Text = Convert.ToString(Convert.ToInt32(mw.TB1.Text), 10);

           // ObserverBin = Convert.ToInt32(mw.TB1.Text);
            mw.TB3.Text = Convert.ToString(ObserverBin = Convert.ToInt32(mw.TB1.Text), 2);

           // ObserverOctal = Convert.ToInt32(mw.TB1.Text);
            mw.TB4.Text = Convert.ToString(ObserverOctal = Convert.ToInt32(mw.TB1.Text), 8);

            //ObserverHex = Convert.ToInt32(mw.TB1.Text);
            }
            
            mw.TB5.Text = Convert.ToString(ObserverHex = Convert.ToInt32(mw.TB1.Text), 16);

        
            Console.WriteLine();
            Notify();

        }
    }
}
