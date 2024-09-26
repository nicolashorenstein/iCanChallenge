using iCanChallenge.Domain.Interfaces;
using iCanChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();
        private Random random;
        public StudentService()
        {
            random = new Random();
            LoadStudents();
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        private void LoadStudents()
        {
            for (int i = 1; i <= 10; i++)
            {
                _students.Add(new Student
                {
                    StudentId = i,
                    FirstName = $"Name {i}",
                    LastName = $"LastName {i}",
                    ExamScores = GenerateExams()
                });
            }
        }

        private List<ExamScore> GenerateExams()
        {
            var result = new List<ExamScore>();

            //Here, I considered that each student have 6 exams assigned
            for (int i = 1; i<=6; i++)
            {
                var studentTookExam = random.Next(0, 2) == 1;
                var score = random.Next(0, 101); // Generates a random number between 0 and 100 (inclusive)

                result.Add(new ExamScore
                {
                    ExamId = random.Next(100, 1000),
                    ExamName = $"Exam {i}",
                    DateTaken = GenerateRandomDate(),
                    Score = studentTookExam ? score : 0, //If student took exam, the score is generated, if not, the score will be 0
                    IsPassed = studentTookExam ? (score >= 60 ? true : false) : null
                });
            }

            return result;
        }

        private DateTime GenerateRandomDate()
        {
            int daysInYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
            int randomDay = random.Next(1, daysInYear + 1);
            int randomHour = random.Next(0, 24);
            int randomMinute = random.Next(0, 60);
            int randomSecond = random.Next(0, 60);

            return new DateTime(DateTime.Now.Year, 1, 1).AddDays(randomDay - 1).AddHours(randomHour).AddMinutes(randomMinute).AddSeconds(randomSecond);
        }
    }
}
