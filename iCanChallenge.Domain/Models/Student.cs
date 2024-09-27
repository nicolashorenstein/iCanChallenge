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
        private int _studentId;
        public int StudentId { get => _studentId; set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException(nameof(StudentId), "StudentId must be a 5-digit integer.");
                }
                _studentId = value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ExamScore> ExamScores { get; set; } = new List<ExamScore>();
    }
}
