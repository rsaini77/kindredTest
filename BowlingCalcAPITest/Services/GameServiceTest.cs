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
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score());
        }
    }
}
