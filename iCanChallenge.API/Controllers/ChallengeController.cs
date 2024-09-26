using Microsoft.AspNetCore.Mvc;

namespace iCanChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
       
        private readonly ILogger<ChallengeController> _logger;

        public ChallengeController(ILogger<ChallengeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
