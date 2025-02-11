using FinalGradesProject.Configuration;
using FinalGradesProject.Exceptions;
using FinalGradesProject.Models;
using FinalGradesProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace FinalGradesProject.controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class GradeManagement : ControllerBase
    {
        IStudents _students;
        IGradeManager _gradeManager;
        List<Percent> percents;
        ILogger<GradeManagement> _logger;
        public GradeManagement(IStudents students, IGradeManager gradeManager, IOptions<List<Percent>> percent, ILogger<GradeManagement> logger)
        {
            _students = students;
            _gradeManager = gradeManager;
            this.percents = percent.Value;
            _logger = logger;
        }
        DataSource studentsList = new DataSource();
 
        [HttpPut("EnterGradeForStudent")]
        public IActionResult EnterGradeForStudent([FromBody] GradeAndStudentList gradeAndStudentList, [FromQuery] int exeumber)
        {
            List<string> StudentsId = gradeAndStudentList.StudentsId;
            List<M_Grade> Grades = gradeAndStudentList.Grades;
            for (int i = 0; i < StudentsId.Count; i++)
            {
                _students.EnterGradeForStudent(gradeAndStudentList);
            }
            _logger.LogInformation($"The student with ID {StudentsId} update mark to thus mark {exeumber}.");
            return Ok();
        }

        [HttpPost("UpdateGrade")]
        public IActionResult UpdateGrade([FromQuery] string id, [FromBody] M_Grade newGrade)
        {
            _students.UpdateGrade(id, newGrade);
            _logger.LogInformation($"the teacher connected and update the grade: {newGrade.BuildGrade().ExeNumber} to the student: {_students.GetStudent(id).Name}");
            return Ok();
        }

        [HttpPost("ShowGrade")]
        public List<int> ShowGrade([FromBody] List<string> listId, [FromQuery] int exeNumber)
        {
            int x = 0;
            List<int> a = new List<int>();
            for (int i = 0; i < listId.Count; i++)
            {
                string id = listId[i];
                x = _students.ReturnGrade(id, exeNumber);
                a.Add(x);
            }
            _logger.LogInformation($"Show Grade: {x}");  
            return a;
        }

        [HttpGet("FinalGrade")]
        public double FinalGrade([FromQuery] string id)
        {
            _logger.LogInformation($"Tthe final grade for {id} is {_gradeManager.FinalGrade}");    
            return _gradeManager.FinalGrade(id);
        }

        [HttpGet("ShowGradeAndExercises")]

        public IActionResult ShowGradeAndExercises([FromQuery] int exeNumber)
        {
            List<int> list = new List<int>();
            _students.ViewAllStudents().ForEach(s =>
            {
                list.Add(_students.ReturnGrade(s.ID, exeNumber));
            });
            _logger.LogInformation($"the grade and exercises {list}");
            return Ok(list);
        }
        [HttpGet("FinalAllGrade")]
        public Dictionary<string, double> FinalAllGrade()
        {
            _logger.LogInformation($" the final all grade{_gradeManager.FinalAllGrade()}");
            return _gradeManager.FinalAllGrade();
            
        }

    }
}

