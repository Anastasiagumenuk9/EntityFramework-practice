using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4._2.Data.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public int AwayTeamBetRate { get; set; }
        public int AwayTeamGoals { get; set; }
        public int AwayTeamId { get; set; }
        public int DrawBetRate { get; set; }
        public int HomeTeamBetRate { get; set; }
        public int HomeTeamGoals { get; set; }
        public int HomeTeamId { get; set; }
        public string Result { get; set; }
        public DateTime DateTime { get; set; }


    }
}
