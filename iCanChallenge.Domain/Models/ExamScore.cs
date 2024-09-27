using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace iCanChallenge.Domain.Models
{
    public class ExamScore
    {
        private int _examId;
        public int ExamId
        {
            get => _examId; set
            {
                if (value < 100 || value > 999)
                {
                    throw new ArgumentOutOfRangeException(nameof(ExamId), "ExamId must be a 3-digit integer.");
                }
                _examId = value;
            }
        }
        public string ExamName { get; set; }
        public DateTime DateTaken { get; set; }
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(Score), "Score must be between 0 and 100.");
                }
                _score = value;
            }
        }
        public bool? IsPassed { get; set; } = null;
    }
}
