using iCanChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Domain.Interfaces
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
        public Student? GetStudentById(int id);
        public bool UpdateExam(int studentId, int examId, int score, DateTime dateTaken, bool? isPassed);
    }
}
