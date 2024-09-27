using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Domain.Models
{
    public class Student
    {
        [Range(0, 99999, ErrorMessage = "StudentId must be between 0 and 99999.")]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ExamScore> ExamScores { get; set; } = new List<ExamScore>();
    }
}
