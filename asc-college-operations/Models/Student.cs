using asc_college_operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Models
{
    public class Student : Entity
    {
        public string StudentName { get; set; }

        public EnumStudentStatus Status { get; set; }

        public decimal CR { get; set; }

        public ICollection<StudentClass> Classes { get; set; } = new HashSet<StudentClass>();

    }
}
