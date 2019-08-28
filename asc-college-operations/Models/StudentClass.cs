using asc_college_operations.Abstractions;
using asc_college_operations.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Models
{
    public class StudentClass : Entity
    {
        public Student Student { get; set; }

        public Class Class { get; set; }

        public decimal Note { get; private set; }

        public EnumStudentStatus Status { get; set; }

        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();

        public void AddExam(Exam newExam)
        {
            this.Exams.Add(newExam);
        }

        public void CalculateNotes()
        {

            if (this.Exams.Any(x => x.Type == EnumExamType.FinalExam))
            {
                var media_ponderada = this.Exams.Where(x => x.Type != EnumExamType.FinalExam).Select(x => x.Note * x.Weight).Sum() / this.Exams.Where(x => x.Type != EnumExamType.FinalExam).Select(x => x.Weight).Sum();

                var media_final = (this.Exams.FirstOrDefault(x => x.Type == EnumExamType.FinalExam).Note * this.Exams.FirstOrDefault(x => x.Type == EnumExamType.FinalExam).Weight) / this.Exams.FirstOrDefault(x => x.Type != EnumExamType.FinalExam).Weight;

                this.Note = media_final + media_ponderada;

                this.CalculateStatus();
            }
            else
            {
                this.Note = this.Exams.Select(x => x.Note * x.Weight).Sum() / this.Exams.Select(x => x.Weight).Sum();

                this.CalculateStatus();
            }
        }

        public void CalculateStatus()
        {
            if (this.Note >= 6)
            {
                this.Status = EnumStudentStatus.Aproved;
            }
            else
            if (this.Note <= 4)
            {
                this.Status = EnumStudentStatus.Reproved;
            }
            else
            {
                this.Status = EnumStudentStatus.FinalStage;
            }
        }
    }
}
