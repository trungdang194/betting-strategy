using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingStrategySimulator.BigOrSmall.Strategy
{
    public class Martingale
    {
        public int InitialBet { get; set; }
        public int CurrentBet { get; set; }
        public int NextBetWhenWin { get; set; }
        public int NextBetWhenLose { get; set; }
        public GameReult GameReult { get; set; }
        public ThreeDicesDirection BetDirection { get; set; }
    }
}
