using iCanChallenge.Application.Students.Responses;
using iCanChallenge.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Queries
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, StudentResponse>
    {
        private readonly IStudentService _studentService;
        
        public GetAllStudentsHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentResponse> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = new StudentResponse();

            result.Students = _studentService.GetStudents();

            return result;
        }
    }
}
