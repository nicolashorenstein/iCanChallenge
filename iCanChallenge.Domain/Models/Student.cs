using iCanChallenge.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Domain.Models
{
    public class Student
    {
        [DigitCountValidation(5)]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ExamScore> ExamScores { get; set; } = new List<ExamScore>();
    }
}
