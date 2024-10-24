using BettingStrategySimulator.BigOrSmall.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingStrategySimulator.BigOrSmall
{
    public static class BigOrSmallGame
    {
        public static ThreeDicesResult Roll()
        {
            int seed = (int)(DateTimeOffset.UtcNow.Ticks);
            Random rng = new Random(seed);
            int dice1 = rng.Next(1, 7);
            int dice2 = rng.Next(1, 7);
            int dice3 = rng.Next(1, 7);
            int point = dice1 + dice2 + dice3;
            ThreeDicesDirection direction =
                dice1 == dice2 && dice1 == dice3 ? ThreeDicesDirection.Tripple
                : point >= 11 && point <= 17 ? ThreeDicesDirection.Big
                : point >= 4 && point <= 10 ? ThreeDicesDirection.Small
                : ThreeDicesDirection.None;
            return new ThreeDicesResult { Dice1 = dice1, Dice2 = dice2, Dice3 = dice3, Point = point, Direction = direction };
        }

        public static void RunSession(Martingale strategy, BettingStrategyContext dbContext)
        {
            while (true)
            {
                ThreeDicesResult result = Roll();
                if (result.Direction == strategy.BetDirection)
                {
                    // win
                    // save to db
                    Task.Run(async () =>
                    {
                        try
                        {
                            await dbContext.BetResults.AddAsync(new Models.BetResult { CurrentBalance = 1, PnL = 1, PreviousBalance = 1, GameReult = GameReult.Win, GameSessionId = "", StrategyStatisticsId = "" });
                        }
                        catch (Exception ex)
                        {
                        }
                    });
                    return;
                }

                // lose, continue next bet
                // save to db
                strategy.NextBetWhenWin = strategy.InitialBet;
                strategy.NextBetWhenLose = strategy.CurrentBet * 2;
                strategy.CurrentBet = strategy.NextBetWhenLose;
                Task.Run(async () =>
                {
                    try
                    {
                        await dbContext.BetResults.AddAsync(new Models.BetResult { CurrentBalance = 1, PnL = 1, PreviousBalance = 1, GameReult = GameReult.Win, GameSessionId = "", StrategyStatisticsId = "" });
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
        }

        public static void RunStatistics(Martingale strategy)
        {
            using (BettingStrategyContext dbContext = new BettingStrategyContext())
            {
                for (int i = 0; i < 1000; i++)
                {
                    RunSession(strategy, dbContext);
                }
            }
        }
    }
}