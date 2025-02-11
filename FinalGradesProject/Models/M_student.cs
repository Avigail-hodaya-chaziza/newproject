using System.ComponentModel.DataAnnotations;
using FinalGradesProject;
namespace FinalGradesProject.Models
{
    public class M_student
    {
        [Required]
        public string ID { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [StringLength(3-8)]
        public string Password { get; set; }
        public List<M_Grade> ExeList { get; set; }
        public M_Grade TestGrade { get; set; }

        public Student BuildStudent()
        {
            Student student = new Student() { 
                ID = this.ID,
                Name = this.Name,
                Password = this.Password,
               
            };
            return student;
        }
       
    }
  
}
