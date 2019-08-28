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
    public class ClassService : BaseService, IClassService
    {
        private IExamService examService;

        public ClassService(CollegeContext context, IExamService examService)
            : base(context)
        {
            this.examService = examService;
        }

        public void AddExam(int classId, int studentId, Exam request)
        {
            var studentClass = this.Context.StudentClasses.Include(x => x.Student).Include(x => x.Class).Include(x => x.Exams).Where(x => x.Class.Id == classId && x.Student.Id == studentId).FirstOrDefault();

            if (studentClass == null)
            {
                throw new Exception("Student Not Found in This Class");
            }

            var exam = this.examService.GenerateRandomExam(request.Weight);


            if (!isValidAddNewExam(studentClass, exam))
            {
                throw new Exception("Student Has more than 3 Exams");
            }

            studentClass.AddExam(exam);
            this.Context.SaveChanges();
        }

        public bool isValidAddNewExam(StudentClass student, Exam newExam)
        {
            if (student.Exams.Where(x => x.Type == EnumExamType.Normal).Count() >= 3 && newExam.Type == EnumExamType.Normal)
            {
                return false;
            }
            return true;
        }

        public void AddStudent(int classId, Student request)
        {
            var student = this.Context.Students.Find(request.Id);

            var @class = this.Context.Classes.Find(classId);

            if (student == null || @class == null)
            {
                throw new Exception("Bad request");
            }

            var studentClass = new StudentClass()
            {
                Class = @class,
                Student = student
            };

            if (@class.Students.Any(x => x.Student.Id == request.Id))
            {
                throw new Exception("Student already in class");
            }

            @class.Students.Add(studentClass);

            Context.SaveChanges();
        }

        public void CreateClass(Class request)
        {
            this.Context.Classes.Add(request);
            this.Context.SaveChanges();
        }

        public ICollection<Class> GetAllClasses()
        {
            return this.Context.Classes.ToList();
        }
    }
}
