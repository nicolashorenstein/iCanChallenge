﻿using iCanChallenge.Domain.Models;
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
    }
}
