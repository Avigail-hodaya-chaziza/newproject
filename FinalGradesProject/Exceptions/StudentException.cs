using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradesProject.Exceptions
{
    public class StudentNotExsistException : Exception
    {
        public int statusCode { get; set; }
        public StudentNotExsistException(string StudentId) : base($"The student {StudentId} not exsist")
        {
            statusCode = 500;

        }

    }
    public class StudentNotExsistException2 : Exception
    {
        public int statusCode { get; set; }
        public StudentNotExsistException2(string password) : base($"The student {password} not exsist")
        {
            statusCode = 500;

        }

    }
    public class StudentAlradyExsistException : Exception
    {
        public StudentAlradyExsistException(string StudentId) : base($"The student with Id {StudentId} aleady exsist")
        {

        }

    }
    public class GradeNotExistException : Exception
    {
        public GradeNotExistException(int previousGrade) : base($"The grade {previousGrade} not exsist")
        {

        }

    }
}
