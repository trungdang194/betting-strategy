using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingStrategySimulator.Models
{
    public class GameSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid StrategyStatisticsId { get; set; }

        public virtual StrategyStatistics StrategyStatistics { get; set; }
    }
}