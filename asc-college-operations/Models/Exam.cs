using asc_college_operations.Abstractions;
using asc_college_operations.Models.Enumerators;

namespace asc_college_operations.Models
{
    public class Exam : Entity
    {
        public decimal Note { get; set; }

        public decimal Weight { get; set; }

        public EnumExamType Type { get; set; }
    }
}