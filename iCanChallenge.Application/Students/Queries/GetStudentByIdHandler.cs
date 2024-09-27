using FluentValidation;
using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Queries
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentsByIdQuery, StudentResponse>
    {
        private readonly IChallengeService _challengeService;
        private readonly IValidator<GetStudentsByIdQuery> _validator;
        public GetStudentByIdHandler(IChallengeService challengeService, IValidator<GetStudentsByIdQuery> validator)
        {
            _challengeService = challengeService;
            _validator = validator;
        }

        public async Task<StudentResponse> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new StudentResponse();

            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validation.Errors);
                result.SetError(errors, HttpStatusCode.BadRequest);
                return result;
            }
            try
            {
                var student = _challengeService.GetStudentById(request.StudentId);
                if (student != null)
                {
                    result.Students.Add(student);
                }
                else
                {
                    result.SetError("Student not found", HttpStatusCode.NotFound);
                }

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
