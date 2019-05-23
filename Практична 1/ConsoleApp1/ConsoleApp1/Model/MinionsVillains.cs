using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class MinionsVillains
    {
        public int Id { get; set; }
        public int MinionsId { get; set; }
        public int VillainsId { get; set; }

        public virtual Minions Minions { get; set; }
        public virtual Villains Villains { get; set; }
    }
}
