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
       List<ICourse> GetAll();
        public int Count { get; }
        void Add(string name, DateTime startDateTime, DateTime endDateTime, int[] attendeeRange, List<Member> attendees, Member master, string summary, string description);
        void Update(Course newCourse, Course course);
        void Delete(int id);
        void PrintAllCourses();
        public ICourse GetCourseById(int id);
        public List<ICourse> EnteredCourses(Member member); // search through all courses to find all that member is a part of
    }
}
