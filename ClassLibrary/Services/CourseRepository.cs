using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Exceptions;
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

        public void Update(Course newCourse, Course course)
        {
            course.Name=newCourse.Name;
            course.Master = newCourse.Master;
            course.AttendeeRange = newCourse.AttendeeRange;
            course.TimeSlot = newCourse.TimeSlot;
            course.Summary = newCourse.Summary;
            course.Description = newCourse.Description;

            /*
            _courses[course.Id].Name = ((newCourse.Name == null) ? course.Name : newCourse.Name);
            course.Master = ((newCourse.Master == null) ? course.Master : newCourse.Master);
            course.AttendeeRange = ((newCourse.AttendeeRange == null) ? course.AttendeeRange : newCourse.AttendeeRange);
            course.TimeSlot[0] = ((newCourse.TimeSlot[0] == null) ? course.TimeSlot[0] : newCourse.TimeSlot[0]);
            course.TimeSlot[1] = ((newCourse.TimeSlot[1] == null) ? course.TimeSlot[1] : newCourse.TimeSlot[1]);
            _courses[course.Id].Summary = ((newCourse.Summary == null) ? course.Summary : newCourse.Summary);
            _courses[course.Id].Description = ((newCourse.Description == null) ? course.Description : newCourse.Description);
            */
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
