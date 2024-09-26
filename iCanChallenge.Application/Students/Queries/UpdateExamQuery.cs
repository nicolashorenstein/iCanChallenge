using iCanChallenge.Application.Students.Commands.Students;
using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Queries
{
    public class UpdateExamQuery : IRequest<BaseResult>
    {
        public UpdateExamCommand Command { get; set; }
    }
}
