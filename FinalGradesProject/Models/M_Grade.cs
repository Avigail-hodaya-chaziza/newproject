using System.ComponentModel.DataAnnotations;
using FinalGradesProject;
namespace FinalGradesProject.Models
{
    public class M_Grade
    {
        public int ExeNumber { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [Range(0, 100)]
        public int GradeNumber { get; set; }

        [MaxLength(50)]
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
    }
}
