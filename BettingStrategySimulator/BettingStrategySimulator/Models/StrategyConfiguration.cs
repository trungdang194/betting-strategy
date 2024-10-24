using System.ComponentModel.DataAnnotations;

namespace BettingStrategySimulator.Models
{
    public class StrategyConfiguration
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid StrategyDefinitionId { get; set; }
        [Length(0,255)]
        public string Key { get; set; }
        
        public string Value { get; set; }

        public virtual StrategyDefinition StrategyDefinition { get; set; }
    }
}