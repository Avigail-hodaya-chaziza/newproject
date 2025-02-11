using FinalGradesProject.Configuration;
using FinalGradesProject.Models;
using FinalGradesProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FinalGradesProject.Exceptions;

namespace FinalGradesProject.controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ViewingGrades : ControllerBase
    {
        ILogger<ViewingGrades> _logger;
        IStudents _students;
        IGradeManager _gradeManager;
        IPasswordManager _passwordManager;

        public ViewingGrades(IStudents students, IGradeManager gradeManager, IPasswordManager passwordManager, ILogger<ViewingGrades> logger)
        {
            _students = students;
            _gradeManager = gradeManager;
            _passwordManager = passwordManager;
            _logger = logger;
        }
        DataSource studentsList = new DataSource();


        [HttpGet("ShowLastExeAndAvg")]

        public IActionResult ShowLastExeAndAvg(string id, string Password, int exeNumber)
        {
            Student st = studentsList.Students.FirstOrDefault(stu => stu.ID == id);
            if (st == null || !_passwordManager.IntegrityCheck(st.Name, Password))
            {
                return BadRequest("Invalid student ID or password.");
            }
            var average = _gradeManager.GradeAverage(exeNumber);
            int LastExe = _students.ReturnGrade(id, st.ExeList.Count);
      
            {
                _logger.LogInformation($"Show Last Exe {LastExe}  And Avg: {average}");
                return Ok(new { LastExe, Average = average });
            }

        }

        [HttpGet("ShowGradeAndAvg")]
        public IActionResult ShowGradeAndAvg(string id, string password, int exeNumber)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == id && stu.Password == password && stu.ExeList.Count - 1 >= exeNumber);
            if (student == null)
            {
                _logger.LogInformation($"The grade was shown for student ID {id}");

            }
            return Ok($"Show the grade {_students.ReturnGrade(id, exeNumber)} and Avarage {_gradeManager.GradeAverage(exeNumber)}");
        }



        [HttpGet("ShowGradeAndAvgAndFinalGrade")]
        public IActionResult ShowGradeAndAvgAndFinalGrade(string id, string password, int exeNumber)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == id && stu.Password == password && stu.ExeList.Count - 1 >= exeNumber);
            if (student == null)
            {
                _logger.LogInformation($"The grade was shown for student ID {id}");

            }
            return Ok($" the final grade {_gradeManager.FinalGrade(id)} and Show the grade {_students.ReturnGrade(id, exeNumber)} and Avarage {_gradeManager.GradeAverage(exeNumber)}");

        }
    }
}

