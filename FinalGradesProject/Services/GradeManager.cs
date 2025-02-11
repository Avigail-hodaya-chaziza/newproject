using FinalGradesProject;
using FinalGradesProject.Configuration;
using FinalGradesProject.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace FinalGradesProject.Services
{
    public class GradeManager:IGradeManager
    {
        DataSource studentsList = new DataSource();
        IConfiguration configuration;
        private Percent valuePercent;

        public GradeManager(IOptions<Percent> percent)
        {
            valuePercent = percent.Value;
        }
        public double FinalGrade(string id)
        {
            Student s = studentsList.Students.FirstOrDefault(stu => stu.ID == id);
            if (s==null)
                throw new StudentNotExsistException(id);
               double sum = 0;
            sum += s.TestGrade.GradeNumber * (valuePercent.PercentTest);
            foreach (Grade grade in s.ExeList)
            {
                if (grade==null)              
                    continue;

                if (grade.ExeNumber==1)
                    sum += grade.GradeNumber * (valuePercent.PercentExe1);
             
                if (grade.ExeNumber == 2)
                    sum += grade.GradeNumber * (valuePercent.PercentExe2);
               
                if (grade.ExeNumber == 3)
                    sum += grade.GradeNumber * (valuePercent.PercentExe3);
            }
            return sum;
        }
        public Dictionary<string, double> FinalAllGrade()
        {
            Dictionary<string, double> allGrades = new Dictionary<string, double>();
            foreach (Student student in studentsList.Students)
            {
                double finalGrade = FinalGrade(student.ID);
                allGrades.Add(student.Name, finalGrade);
            }
            return allGrades;
        }
        public double GradeAverage(int exeNumber)
        {
            double sum = 0;
            int count = 0;
            foreach (var s in studentsList.Students)
            {
                    Grade g = s.ExeList.Find(a => a.ExeNumber == exeNumber);
                    if (g != null)
                    {
                        sum += g.GradeNumber;
                        count++;
                    }
                }
            return count == 0 ? 0 : sum / count;
        }

    }
}
