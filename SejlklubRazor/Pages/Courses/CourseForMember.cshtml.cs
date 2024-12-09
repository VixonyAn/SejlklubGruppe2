using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubRazor.Pages.Members;

namespace SejlklubRazor.Pages.Courses
{
    public class CourseForMemberModel : PageModel
    {
        // This page should show the list of all the courses
        // Show the Courses title, description, and the number of places left in that course   maxNumOfAttendees - Attendees.Count
        #region Instance Fields
        
        private ICourseRepository _CourseRepo ;
        private IMemberRepository _MemberRepo ;
        #endregion

        #region Properties
        public List<Course> ListOfEnteredCourses { get; private set; }



        public List<IMember> Members { get; set; }
        #endregion

       
        #region Constructors
        

        public CourseForMemberModel(ICourseRepository courseRepository, IMemberRepository memberRepository)  
        {
            _CourseRepo = courseRepository;
            _MemberRepo = memberRepository;
            ListOfEnteredCourses = new List<Course>();
            Members = _MemberRepo.GetAll();

        }

        #endregion

        #region Methods
        public List<Course> EnteredCourses(Member member) // search through all courses to find all that member is a part of
        {
            if (member == null)
            {
                return null;
            }

            List<Course> list = new List<Course>();

            // if member apperes in the list of attendees then add course to list
            foreach (Course course in _CourseRepo.GetAll())
            {
                foreach(Member mem in course.Attendees)
                {
                    if (mem == member)
                    {
                        list.Add(course);
                        
                    }
                }
            }
            Console.WriteLine("list of courses for a given member  just ran");
            ListOfEnteredCourses= list;
            return list;
        }
        public void OnGet()
        {
          //  ListOfCourses = _CourseRepo.GetAll();
        }
        #endregion
    }
}
