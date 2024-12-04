
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class CourseRepository : ICourseRepository
    {
        private Dictionary<int, Course> _courses;
        public int Count { get { return _courses.Count; } }

        public void Add(Course course)
        {
            _courses.Add(Count + 1, course);
        }       // previous id+1=new id

        public void Delete(int id)
        {
            _courses.Remove(id);
        }

        public void PrintAllCourses()
        {
            foreach (Course c in _courses.Values)
            {
                Console.WriteLine(c);   
            }
        }

        public void Update(Course course)
        {
            Course courseToUpdate = course;
            Delete(course.Id);
            _courses.Add(course.Id,courseToUpdate);
        }
        public List<Course> GetAll()
        {
            return _courses.Values.ToList();
        }
    }
}
