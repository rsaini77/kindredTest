using BowlingCalcAPI.Controllers;
using BowlingCalcAPI.Interfaces;
using BowlingCalcAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BowlingCalcAPITest.Controllers
{

    public class BowlingCalcControllerTest
    {
        BowlingCalcController _controller;
        IGameService _gameService;
        public BowlingCalcControllerTest()
        {
            _gameService = new GameService();
            _controller = new BowlingCalcController(_gameService);
        }

        [Fact]
        public void PassingElementNotANumber_ReturnsBadRequest()
        {
            string[] array = { "10", "InvalidValue", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };

            var result = _controller.Scores(array);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PassingValidValues_ReturnsOk()
        {
            string[] array = { "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };

            var result = _controller.Scores(array);

            Assert.IsType<OkObjectResult>(result);
        }
    }


}
