using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W2D2_StudentAPI.Models;

namespace CS321_W2D2_StudentAPI.Services
{
    public class StudentsService : IStudentsService
    {
        private List<Student> _students = new List<Student>()
        {
        new Student
            {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(2010,1,1),
            Email="john.doe@test.com",
            Phone="555.555.5555"
            },
        new Student
           {
            Id = 2,
            FirstName ="Jane",
            LastName="Smith",
            BirthDate = new DateTime(2012,1,1),
            Email = "jane.smith@test.com",
            Phone ="555.555.5555"
            }
        };



        private int _nextId = 3;
        // IMplementation of IstudentsService
        // GetAll()
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
        // Get(int, Id)
        public Student Get(int id)
        {
            // to find something from list use Linq query
            var student = _students.FirstOrDefault(s => s.Id == id);

            return student;
        }
        // Add(Student student)
        public Student Add(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
            ValidateBirthDate(student);

            return student;
        }
        public void ValidateBirthDate(Student student)
        {
            if (student.BirthDate > DateTime.Now)
            {
                throw new Exception("Student's BirthDate cannot be in the future");
            }
            if (DateTime.Now.Year - student.BirthDate.Year > 18)
            {
                throw new Exception("You are too old to be a student.");
            }
        }
        public Student Update(Student student)
        {
            var currentStudent = this.Get(student.Id); // or you can use _students.FirstorDefault(s=>s.Id==id);
            if (currentStudent == null) return null;
            currentStudent.FirstName = student.FirstName;
            currentStudent.LastName = student.LastName;
            currentStudent.BirthDate = student.BirthDate;
            currentStudent.Email = student.Email;
            currentStudent.Phone = student.Phone;
            return currentStudent;
        }

        public void Remove(Student student)
        {
            _students.Remove(student);
        }
    }


}
