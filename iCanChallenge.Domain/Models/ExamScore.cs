using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Domain.Models
{
    public class ExamScore
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime DateTaken { get; set; }
        public int Score { get; set; }
        public bool? IsPassed { get; set; } = null;
    }
}
