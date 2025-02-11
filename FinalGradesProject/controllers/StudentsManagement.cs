using FinalGradesProject.Configuration;
using FinalGradesProject.Exceptions;
using FinalGradesProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace FinalGradesProject.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagement : ControllerBase
    {
        ILogger<StudentManagement> _logger;
        IStudents _students;
       
        public StudentManagement(ILogger<StudentManagement> logger, IStudents students)
        {
            _logger = logger;
            _students = students;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student != null)
            {
                _students.AddStudent(student);
                _logger.LogInformation($"the student: {student}added successfully");
                return Ok("Student added successfully");
            }
            else {
               return StatusCode(500, "An error occurred while adding the student");
            }
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent([FromQuery] string id, string password)
        {
            _students.DeleteStudent(id, password);
            _logger.LogInformation($"the student: {id} deleted successfully");
            return Ok("Deleted successfully");
        }

        [HttpPut("EditStudent")]
        public IActionResult EditStudent([FromQuery] string id, [FromQuery] string newPassword)
        {
            _students.EditStudent(id, newPassword);
            _logger.LogInformation($"the student: {id} edited successfully");
            return Ok("Edited successfully");
        }

        [HttpGet("ViewAllStudents")]

   
        public string ViewAllStudents()
        {
            _logger.LogInformation($"list the student{_students.GetStudentsDetails()} ");
            return _students.GetStudentsDetails();
        }


        [HttpGet("ViewStudent")]
        public string ViewStudent([FromQuery] string Id)
        {
            _logger.LogInformation($"the student{_students.GetStudentDetails(Id)} ");
            return _students.GetStudentDetails(Id);
        }


    }

}