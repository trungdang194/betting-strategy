using System.ComponentModel.DataAnnotations;

namespace BettingStrategySimulator.Models
{
    public class StrategyDefinition
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}