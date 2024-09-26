using iCanChallenge.Domain.Models;
using iCanChallenge.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Responses
{
    public class StudentResponse : BaseResult
    {
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
