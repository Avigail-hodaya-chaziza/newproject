using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradesProject
{
    public class Grade
    {
        public int ExeNumber { get; set; }//1 ,2 99= for the test
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int GradeNumber { get; set; }
        public string Comment { get; set; }
        public Grade BuildGrade()
        {
            Grade grade = new Grade() 
            { 
                ExeNumber = this.ExeNumber,
                Name = this.Name,
                Date = this.Date,
                GradeNumber = this.GradeNumber,
                Comment = this.Comment
            };
            return grade;
        }
        public override string ToString()
        {
            return $"{Name}: ExeNumber:{ExeNumber} ,Mark: {GradeNumber},Comment: {Comment}, Date: {Date}";
        }

    }
}
