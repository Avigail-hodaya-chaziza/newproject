using FinalGradesProject.Exceptions;
using FinalGradesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalGradesProject
{
    public class Students : IStudents
    {
        DataSource studentsList = new DataSource();

        public Students()
        {
            studentsList.Initialize();
        }
        public void AddStudent(Student student)
        {
            if (studentsList.Students.Any(stu => stu.ID == student.ID))
                throw new StudentNotExsistException(student.ID);
            student.Password = student.ID;
            studentsList.Students.Add(student);

        }

        public void AddGradeToStudent(string StudentId, Grade grade)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentAlradyExsistException(StudentId);
            grade.Date = DateTime.Today;
            student.ExeList.Add(grade);
        }

        public void DeleteStudent(string id, string password)
        {
            Student st = studentsList.Students.FirstOrDefault(stu => stu.Password == password);
            if ( st == null)
                throw new StudentNotExsistException2(password);

            Student stu = studentsList.Students.FirstOrDefault(stu => stu.ID == id);
            if (stu == null || st == null)
                throw new StudentNotExsistException(id);

            studentsList.Students.Remove(stu);
        }

        public void EditStudent(string id, string newPassword)
        {
            Student student = studentsList.Students.Find(stu => stu.ID == id);
            if (student == null)
                throw new StudentNotExsistException(id);
            student.Password = newPassword;

        }

        public Student ViewStudent(string Id)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == Id);
            if (student==null)
                throw new StudentNotExsistException(Id);
            
            return student;
        }

        public List<Student> ViewAllStudents()
        {
            return studentsList.Students.ToList();
        }

        public void EnterGradeForStudent([FromBody] GradeAndStudentList gradeAndStudentList)
        {
            if (gradeAndStudentList.StudentsId.Count != gradeAndStudentList.Grades.Count)
            {
                throw new ArgumentException("The number of students and grades must match.");
            }

            for (int i = 0; i < gradeAndStudentList.StudentsId.Count; i++)
            {
                Student st = studentsList.Students.FirstOrDefault(stu => stu.ID == gradeAndStudentList.StudentsId[i]);
                if (st != null)
                {
                    M_Grade grade = gradeAndStudentList.Grades[i];
                    st.ExeList.Add(grade.BuildGrade());

                    grade.GradeNumber = gradeAndStudentList.Grades[i].GradeNumber;
                }
                else
                {
                    throw new StudentNotExsistException(gradeAndStudentList.StudentsId[i]);
                }
            }
        }

        public void UpdateGrade(string id, M_Grade newGrade)
        {
            Student st = studentsList.Students.FirstOrDefault(stu => stu.ID == id);
            if (st != null)
            {
                Grade UpdateGrade = st.ExeList.Find(g => g.ExeNumber == newGrade.ExeNumber);
                UpdateGrade.GradeNumber = newGrade.GradeNumber;
            }
            else throw new StudentNotExsistException(id);
        }

        public int ReturnGrade(string id, int exeNumber)
        {
            if (!studentsList.Students.Any(stu => stu.ID == id))
                throw new StudentNotExsistException(id);
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == id);
            var x = student.ExeList.FirstOrDefault(gr => gr.ExeNumber == exeNumber);
            return x.GradeNumber;
        }

        public List<Student> GetStudents()
        {
            return studentsList.Students;
        }
        public Student GetStudent(string id)
        {
            if (studentsList.Students.Find(s => s.ID == id) == null)
                throw new StudentNotExsistException(id);

            return studentsList.Students.Find(s => s.ID == id);
        }
        public string GetStudentDetails(string studentId)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            string s = $"Student with ID{studentId} Details:\n";
            s += $"{student.ToString()} \n";
            return s;
        }
        public string GetStudentsDetails()
        {
            string s = "Students Details:\n";
            foreach (Student student in studentsList.Students)
                if (student != null)
                    s += $"{student.ToString()} \n";
            return s;
        }
    }
}

