using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Queries
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, StudentResponse>
    {
        private readonly IChallengeService _challengeService;
        
        public GetAllStudentsHandler(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        public async Task<StudentResponse> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = new StudentResponse();
            try
            {
                result.Students = _challengeService.GetStudents();

                return result;
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message, HttpStatusCode.InternalServerError);
                return result;
            }
           
        }
    }
}
