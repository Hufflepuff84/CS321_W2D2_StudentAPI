using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W2D2_StudentAPI.Models;

namespace CS321_W2D2_StudentAPI.Services
{
    public interface IStudentsService
    {
        // in interfaces we define function signature only
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student student);
        Student Update(Student student);
        void Remove(Student student);
    }
}
