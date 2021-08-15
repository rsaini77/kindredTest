using BowlingCalcAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalcAPI.Services
{
    public class GameService : IGameService
    {
        private int currentRoll;
        private int[] rolls = new int[21];
        public int CalculateScore(string[] pinsDowned)
        {
            var size = pinsDowned.Length;
            for (int i = 0; i < size; i++)
            {
                var converted = ConvertToInt(pinsDowned[i]);
                Roll(converted);
            }
            return Score();
        }

        private int ConvertToInt(string stringElement)
        {
            int nNumber = int.TryParse(stringElement, out nNumber) ? nNumber : throw new Exception("Bad data provided to the service");
            return nNumber;
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
        public int Score()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10
                        + StrikeBonus(roll);
                    roll++;

                }
                else if (IsSpare(roll))
                {
                    score += 10
                        + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }
        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }
        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }
        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }
    }


}
