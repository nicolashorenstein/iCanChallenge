using iCanChallenge.Application.Students.Commands.Students;
using iCanChallenge.Application.Students.Queries;
using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iCanChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ChallengeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/Students")]
        public async Task<StudentResponse> GetStudents()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }

        [HttpGet("api/Students/{id}")]
        public async Task<StudentResponse> GetStudentById(int id)
        {
            return await _mediator.Send(new GetStudentsByIdQuery
            {
                StudentId = id
            });
        }

        [HttpPut("api/Exam")]
        public async Task<BaseResult> UpdateExamn([FromBody] UpdateExamCommand command)
        {
            return await _mediator.Send(new UpdateExamQuery
            {
                Command = command
            });
        }
    }
}
