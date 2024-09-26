using iCanChallenge.Application.Students.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<StudentResponse>
    {
    }
}
