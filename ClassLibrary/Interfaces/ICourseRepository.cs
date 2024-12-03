using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ICourseRepository
    {
       List<Course> GetAll();
        public int Count { get; }
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
        void PrintAllCourses();


    }
}
