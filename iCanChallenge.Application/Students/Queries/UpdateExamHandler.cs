using FluentValidation;
using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Interfaces;
using iCanChallenge.Domain.Results;
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
    public class UpdateExamHandler : IRequestHandler<UpdateExamQuery, BaseResult>
    {
        private readonly IChallengeService _challengeService;
        private readonly IValidator<UpdateExamQuery> _validator;
        public UpdateExamHandler(IChallengeService challengeService, IValidator<UpdateExamQuery> validator)
        {
            _challengeService = challengeService;
            _validator = validator;
        }

        public async Task<BaseResult> Handle(UpdateExamQuery request, CancellationToken cancellationToken)
        {
            var result = new BaseResult();

            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validation.Errors);
                result.SetError(errors, HttpStatusCode.BadRequest);
                return result;
            }
            try
            {
                var student = _challengeService.GetStudentById(request.Command.StudentId);

                if(student == null)
                {
                    result.SetError("Student not found", HttpStatusCode.InternalServerError);
                    return result;
                }

                var exam = student.ExamScores.FirstOrDefault(c=>c.ExamId == request.Command.ExamId);
                if (exam == null)
                {
                    result.SetError("Exam not found", HttpStatusCode.NotFound);
                    return result;
                }
                else
                {
                    var updateResult = _challengeService.UpdateExam(request.Command.StudentId, request.Command.ExamId, request.Command.Score,request.Command.DateTaken, request.Command.IsPassed);
                    if (updateResult)
                    {
                        return result;
                    }
                    else
                    {
                        result.SetError("Error when updating exam", HttpStatusCode.InternalServerError);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message, HttpStatusCode.InternalServerError);
                return result;
            }
          
        }
    }
}
