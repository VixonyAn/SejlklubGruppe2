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
        void Add(string name, DateTime startDateTime, DateTime endDateTime, int[] attendeeRange, List<Member> attendees, Member master, string summary, string description);
        void Update(Course newCourse, Course course);
        void Delete(int id);
        void PrintAllCourses();
        public Course GetCourseById(int id);

    }
}
