using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.і2
{
    abstract class RobotBuilder
    {
        

        public abstract void SetCPU(string cpu);
        public abstract void SetMonitor(string monitor);
        public abstract void SetSpeakers(string speakers);
        public abstract Robot GetResult();
    }
}
