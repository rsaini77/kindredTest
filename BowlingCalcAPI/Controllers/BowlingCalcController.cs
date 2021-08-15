using BowlingCalcAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalcAPI.Controllers
{
    public class BowlingCalcController : ControllerBase
    {
        private readonly IGameService _gameService;
        public BowlingCalcController(IGameService productService)
        {
            _gameService = productService;
        }
        [HttpPost("scores")]
        public IActionResult Scores(string[] pinsDowned)
        {
            try
            {
                var result = _gameService.CalculateScore(pinsDowned);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Error while calculating score: " + e.Message);
            }
        }
    }
}
