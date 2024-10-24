using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingStrategySimulator.Models
{
    [PrimaryKey(nameof(Id), nameof(GameSessionId), nameof(StrategyStatisticsId))]
    public class BetResult
    {   
        public Guid Id { get; set; }
        public long GameSessionId { get; set; }
        public Guid StrategyStatisticsId { get; set; }
        public GameReult GameReult { get; set; }
        public decimal PnL { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IncrementId { get; set; }
        public virtual GameSession GameSession { get; set; }
        public virtual StrategyStatistics StrategyStatistics { get; set; }
    }
}