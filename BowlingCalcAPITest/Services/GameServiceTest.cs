using BowlingCalcAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BowlingCalcAPITest.Services
{
    public class GameServiceTest
    {
        GameService game;

        public GameServiceTest()
        {
            game = new GameService();
        }
        [Fact]
        public void GutterGameTest()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void AllOnesTest()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void OneSpareTest()
        {
            RollSpare();
            game.Roll(3);
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void OneStrikeTest()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, game.Score());
        }
        [Fact]
        public void PerfectGameTest()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.Score());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
