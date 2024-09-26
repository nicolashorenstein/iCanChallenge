using iCanChallenge.Application.Students.Queries;
using iCanChallenge.Application.Students.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iCanChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
       
        private readonly ILogger<ChallengeController> _logger;
        private readonly IMediator _mediator;

        public ChallengeController(ILogger<ChallengeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("api/GetStudents")]
        public async Task<StudentResponse> GetStudents()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }
    }
}
