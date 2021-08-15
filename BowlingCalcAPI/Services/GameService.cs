using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalcAPI.Services
{
    public class GameService
    {
        public int score;
        public void Roll(int pins)
        {
            score += pins;
        }
        public int Score()
        {
            return score;
        }
    }


}
