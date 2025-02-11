namespace FinalGradesProject.Models
{
    public class GradeAndStudentList
    {
        public List<string> StudentsId { get; set; }
        public List<M_Grade> Grades { get; set; }
        public GradeAndStudentList()
        {
            StudentsId = new List<string>();
            Grades = new List<M_Grade>();
        }
    }
}
