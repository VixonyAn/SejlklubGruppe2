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
        private Dictionary<int, ICourse> _courses=new Dictionary<int, ICourse>() ;
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

 
        }


        public List<ICourse> GetAll()
        {
            return _courses.Values.ToList();
        }

        public ICourse GetCourseById(int id)
        {
            return _courses[id];   
        }


        public List<ICourse> EnteredCourses(Member member) // search through all courses to find all that member is a part of
        {


            List<ICourse> list = new List<ICourse>();

            // if member apperes in the list of attendees then add course to list
            foreach (Course course in _courses.Values)
            {
                foreach (Member mem in course.Attendees)
                {
                    if (mem == member)
                    {
                        list.Add(course);

                    }
                }
            }
            if (list == null)
            {
                DateTime start = new DateTime(0001, 01, 01);
                DateTime end = new DateTime(0001, 01, 01);
                int[] attRange = { 1, 1 };
                List<Member> members = new List<Member>();
                Member master = new Member(" ", "  ", "  ");
                members.Add(master);
                Course course = new Course(0," ",start,end,attRange, members,master, " "," ");
                list.Add((ICourse)course);
            }
            Console.WriteLine("list of courses for a given member  just ran");
            return list;
        }
        #endregion
    }
}