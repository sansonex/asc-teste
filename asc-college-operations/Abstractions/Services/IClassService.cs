using asc_college_operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Abstractions.Services
{
    public interface IClassService
    {
        void CreateClass(Class request);

        ICollection<Class> GetAllClasses();

        void AddStudent(int classId, Student request);

        void AddExam(int classId, int studentId, Exam request);
    }
}
