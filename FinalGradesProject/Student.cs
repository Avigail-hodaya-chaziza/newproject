using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradesProject
{
    public class Student
    {
        public string ID {  get; set; }
        public string Name { get; set; }
        public string  Password { get; set; }
        public List<Grade> ExeList { get; set; }
        public Grade TestGrade { get; set; }

        public Student BuildStudent()
        {
            Student student = new Student()
            {
                ID = this.ID,
                Name = this.Name,   
                Password = this.Password,   
                ExeList = this.ExeList,
                TestGrade = this.TestGrade  

            };
            return student;
        }
        public double GradeAverage()
        {
            return ExeList.Average(grade => grade.GradeNumber);
        }

        

        public Student()
        {
            ExeList = new List<Grade>(); 
        }
        public override string ToString()
        {
            string s = $"ID: {ID}, Name: {Name}\n";
            foreach (Grade g in ExeList)
            {
                if (g != null)
                    s += $"   {g.ToString()}\n";
            }
            if (TestGrade != null)
                s += $" Test Grade  {TestGrade}\n";
            return s;
        }
    }
}
