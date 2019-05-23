using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._2.Data.Model
{
    public class Bet { 
    
        public int BetId { get; set; }
        public int Amount { get; set; }
        public int GameId { get; set; }
        public string Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

    }
}
