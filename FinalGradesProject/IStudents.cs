using FinalGradesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGradesProject
{
    public interface IStudents
    {
        void AddStudent(Student student);
        void AddGradeToStudent(string StudentId, Grade grade);
        void DeleteStudent(string id, string password);
        void EditStudent(string id, string newPassword);
        Student ViewStudent(string student);
        List<Student> ViewAllStudents();
        void EnterGradeForStudent([FromBody] GradeAndStudentList gradeAndStudentList);
        void UpdateGrade(string id, M_Grade newGrade);
        int ReturnGrade(string id, int exeNumber);
        List<Student> GetStudents();
        string GetStudentDetails(string studentId);
        Student GetStudent(string id);
        string GetStudentsDetails();
    }
}
