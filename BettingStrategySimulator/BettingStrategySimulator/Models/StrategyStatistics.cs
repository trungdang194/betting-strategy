using System.ComponentModel.DataAnnotations;

namespace BettingStrategySimulator.Models
{
    public class StrategyStatistics
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberOfGameSession { get; set; }
        public Guid StrategyDefinitionId { get; set; }
        public virtual StrategyDefinition StrategyDefinition { get; set; }
    }
}