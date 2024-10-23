using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingStrategySimulator.BigOrSmall
{
    public class ThreeDicesResult
    {
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public int Dice3 { get; set; }
        public int Point {  get; set; }
        public ThreeDicesDirection Direction { get; set; }
    }

    public enum ThreeDicesDirection
    {
        None,
        Small,
        Big,
        /// <summary>
        /// Triple means 3 dices having the same point
        /// </summary>
        Tripple
    }
}
