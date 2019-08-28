using asc_college_operations.Models;
using asc_college_operations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Abstractions.Services
{
    public interface IExamService
    {
        Exam GenerateRandomExam(decimal Weight);

    }
}
