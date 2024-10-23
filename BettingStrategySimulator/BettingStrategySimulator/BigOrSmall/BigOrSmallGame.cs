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

            return new ThreeDicesResult { Dice1 = dice1, Dice2 = dice2, Dice3 = dice3, Point = dice1 + dice2 + dice3, IsTriple = dice1 == dice2 && dice1 == dice3 };
        }

        public static void RunSimulator()
        {
            for (int i = 0; i < 1000; i++)
            {
                ThreeDicesResult result = Roll();

                // Save to DB

            }
        }

        public static void RunSession(Martingale strategy)
        {
            while (true)
            {
                ThreeDicesResult result = Roll();
                if (result.Direction == strategy.BetDirection)
                {
                    // win
                    // save to db

                    break;
                }

                // lose
                // save to db
                strategy.NextBetWhenWin = strategy.InitialBet;
                strategy.NextBetWhenLose = strategy.CurrentBet * 2;
                strategy.CurrentBet = strategy.NextBetWhenLose;
            }
        }

        public static void RunLongTermGame(Martingale strategy)
        {
            for (int i = 0;i < 1000;i++)
            {
                RunSession(strategy);
            }
        }
    }
}
