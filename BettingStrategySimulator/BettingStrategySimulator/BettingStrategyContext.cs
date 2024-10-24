using BettingStrategySimulator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingStrategySimulator
{
    public class BettingStrategyContext: DbContext
    {
        public DbSet<BetResult> BetResults { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<StrategyConfiguration> StrategyConfigurations { get; set; }
        public DbSet<StrategyDefinition> StrategyDefinitions { get; set; }
        public DbSet<StrategyStatistics> StrategyStatistics { get; set; }
        public string DbPath { get; }
        public BettingStrategyContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "betting_strategy.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
