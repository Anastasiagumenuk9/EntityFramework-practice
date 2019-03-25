using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.і2
{
    class Robot
    {
        MainWindow mw = new MainWindow();
      
        public List<Object> parts = new List<Object>();

        public void Add(object part)
        {
            parts.Add(part);
        }

        public string Print()
        {
            string p = "";
            foreach (object i in parts)
            {
                p += i + " ";
            }
            return p;
        }

    }
}
