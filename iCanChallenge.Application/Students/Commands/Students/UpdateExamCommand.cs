using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Application.Students.Commands.Students
{
    public class UpdateExamCommand
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime DateTaken { get; set; }
        [Range(0, 100)]
        public int Score { get; set; }
        public bool? IsPassed { get; set;}
    }
}
