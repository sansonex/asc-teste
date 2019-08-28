using asc_college_operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Abstractions.Services
{
    public interface IStudentService
    {
        ICollection<Student> GetAllStudents();

        void CreateStudent(Student student);
    }
}
