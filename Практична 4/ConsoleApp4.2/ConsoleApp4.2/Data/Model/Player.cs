using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._2.Data.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public bool IsInjured { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public int SquardNumber { get; set; }
        public int TeamId { get; set; }
    }
}
