using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.і2
{
    class RobotDirector
    {
        RobotBuilder robotBuilder;
        string cpu;
        string  monitor;
        string speakers;
        MainWindow mw = new MainWindow();
        public RobotDirector(RobotBuilder _robotBuilder, string _cpu, string _monitor, string _speakers)
        {
            robotBuilder = _robotBuilder;
            cpu = _cpu;
            monitor = _monitor;
            speakers = _speakers;
        }

        public void Construct()
        {
            robotBuilder.SetCPU(cpu);
            robotBuilder.SetMonitor(monitor);
            robotBuilder.SetSpeakers(speakers);


        }
    }
}
