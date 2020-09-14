using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SlotSimulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet("{gameId}/spin/{stake}/{betLines}")]
        public IActionResult Spin(string gameId, int stake, int betLines)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            if (gameId == "sample-game")
            {
                if (stake > 200)
                    return BadRequest("Maximum bet 200 credits");

                if (betLines != 10)
                    return BadRequest("Bet lines should be 10");

                return Ok(new SampleGame().Spin(stake, betLines));
            }

            return BadRequest("Game id not found");
        }
    }
}