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
        #region Instance fields
        private Dictionary<int, Course> _courses = new Dictionary<int, Course>();
        #endregion
        #region Properties
        public int Count { get { return _courses.Count; } }
        #endregion 
        #region Constructors
        public CourseRepository()
        {

        }
        #endregion
        #region Methods
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
            Console.WriteLine("\n liste af alle kurser \n -");
            foreach (Course c in _courses.Values)
            {
                Console.WriteLine();
                Console.WriteLine(c);   
            }
            Console.WriteLine("\n liste sluttede \n ");
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
        #endregion
    }
}
