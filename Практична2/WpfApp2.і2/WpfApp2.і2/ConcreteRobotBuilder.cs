using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.і2
{
    class ConcreteRobotBuilder : RobotBuilder
    {
        MainWindow mw = new MainWindow();
        Robot robot = new Robot();
        public override void SetCPU(string cpu)
        {
            robot.Add("Processor  " + cpu);
        }
        public override void SetMonitor(string monitor)
        {
            robot.Add("Monitor " + monitor);
        }
       
        public override void SetSpeakers(string speakers)
        {
            robot.Add("Speakers " + speakers);
        }
        public override Robot GetResult()
        {
            return robot;
        }

       
    }
}
