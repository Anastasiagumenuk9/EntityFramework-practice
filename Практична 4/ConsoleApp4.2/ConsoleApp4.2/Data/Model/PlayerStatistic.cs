using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._2.Data.Model
{
    public class PlayerStatistic
    {
        public int PayerId { get; set; }
        public int GameId { get; set; }
        public string Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int ScoredGoals { get; set; }
    }
}
