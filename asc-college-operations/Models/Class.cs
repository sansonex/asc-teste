using asc_college_operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Models
{
    public class Class : Entity
    {
        public string ClassName { get; set; }
        public ICollection<StudentClass> Students { get; set; } = new HashSet<StudentClass>();
    }
}
