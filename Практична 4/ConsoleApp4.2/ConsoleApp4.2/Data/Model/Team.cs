using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._2.Data.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public int Budget { get; set; }
        public string Initials { get; set; }
        public int LogoUrl { get; set; }
        public int Name { get; set; }
        public int PrimaryKitColorId { get; set; }
        public int SecondaryKitColorId { get; set; }
        public int TownId { get; set; }

        //public virtual PrimaryKitColor PrimaryKitColor { get; set; }
    }
}
