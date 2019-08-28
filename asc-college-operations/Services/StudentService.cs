using asc_college_operations.Abstractions.Services;
using asc_college_operations.Models;
using asc_college_operations.Models.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Services
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(CollegeContext context)
            : base(context)
        {
        }

        public void CreateStudent(Student student)
        {
            this.Context.Students.Add(student);
            this.Context.SaveChanges();
        }

        public ICollection<Student> GetAllStudents()
        {
            return this.Context.Students.ToList();
        }

        public void CalculateStudentStatus()
        {
            var students = this.Context.Students.Include(x => x.Classes);

            foreach (var student in students)
            {
                // (60/100) * total de cursos dele >= total de cursos q ele passsou 
                if ((60 / 100) * student.Classes.Count() >= student.Classes.Count(x => x.Status == EnumStudentStatus.Aproved))
                {
                    student.Status = EnumStudentStatus.Aproved;
                }
                else
                {
                    student.Status = EnumStudentStatus.Reproved;
                }
            }

            this.Context.SaveChanges();
        }
    }
}
