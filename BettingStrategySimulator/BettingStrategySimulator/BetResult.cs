using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingStrategySimulator
{
    public class BetResult
    {
        public Guid Id { get; set; }
        public GameReult GameReult { get; set; }
        public decimal PnL { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }

    public class GameSession
    {

    }

    public class BetDirection
    {

    }

    public class StrategyStatistics
    {

    }

    public class StrategyDefinition
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
    }

    public class StrategyConfiguration
    {
        public Guid Id { get; set;}
        public Guid StrategyId { get; set;}
        public string Key { get; set;}
        public string Value { get; set;}
    }
}
