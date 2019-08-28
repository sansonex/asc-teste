using asc_college_operations.Abstractions.Services;
using asc_college_operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Services
{
    public class ExamService : BaseService, IExamService
    {
        public ExamService(CollegeContext context)
            : base(context)
        {
        }

        public Exam GenerateRandomExam(decimal Weight)
        {
            return new Exam()
            {
                Note = this.GenerateNote(),
                Weight = Weight
            };
        }

        private decimal GenerateNote()
        {
            Random random = new Random();
            return Math.Round((new decimal(random.NextDouble() * (10 - 0) + 0)), 1);
        }
    }
}