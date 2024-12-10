using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class CourseRepository : ICourseRepository
    {
        #region Instance fields
        private Dictionary<int, Course> _courses=new Dictionary<int, Course>() ;
        private static int counter;
        #endregion

        #region Properties
        public int Count { get { return _courses.Count; } }
        #endregion 

        #region Constructors
        public CourseRepository()
        {
          //  _courses = new Dictionary<int, Course>();
        }
        #endregion

        #region Methods
        public void Add(string name, DateTime startDateTime, DateTime endDateTime, int[] attendeeRange, List<Member> attendees, Member master, string summary, string description)
        {
            
            _courses.Add(counter, new Course(counter, name,  startDateTime,  endDateTime,  attendeeRange,  attendees,  master, summary, description));
            counter++;
        }

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

        public void Update(Course newCourse, Course course)
        {
            _courses[course.Id].Name = ((newCourse.Name == null) ? course.Name : newCourse.Name);
            _courses[course.Id].Master = ((newCourse.Master == null) ? course.Master : newCourse.Master);
            _courses[course.Id].AttendeeRange = ((newCourse.AttendeeRange == null) ? course.AttendeeRange : newCourse.AttendeeRange);
            _courses[course.Id].TimeSlot[0] = ((newCourse.TimeSlot[0] == null) ? course.TimeSlot[0] : newCourse.TimeSlot[0]);
            _courses[course.Id].TimeSlot[1] = ((newCourse.TimeSlot[1] == null) ? course.TimeSlot[1] : newCourse.TimeSlot[1]);
            _courses[course.Id].Summary = ((newCourse.Summary == null) ? course.Summary : newCourse.Summary);
            _courses[course.Id].Description = ((newCourse.Description == null) ? course.Description : newCourse.Description);
        }
        public List<Course> GetAll()
        {
            return _courses.Values.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _courses[id];   
        }
        #endregion
    }
}
