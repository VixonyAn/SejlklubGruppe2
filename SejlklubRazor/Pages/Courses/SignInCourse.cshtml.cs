using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SejlklubRazor.Pages.Courses
{
    public class SignInCourseModel : PageModel
    {
        // This page should show the list of all the courses
        // Show the Courses title, description, and the number of places left in that course   maxNumOfAttendees - Attendees.Count
        #region Instance Fields
        private ICourseRepository _CourseRepo ;
        private IMemberRepository _MemberRepo ;
        #endregion
        #region Properties
        public List<ICourse> ListOfEnteredCourses { get; private set; }
        public Member Member { get; private set; }
        public Course Course{ get; private set; }
        public List<IMember> Members { get; set; }
        public List<ICourse> Courses { get; set; }
        #endregion
        #region Constructors
        public SignInCourseModel(ICourseRepository courseRepository, IMemberRepository memberRepository)  
        {
            _CourseRepo = courseRepository;
            _MemberRepo = memberRepository;
            Courses = _CourseRepo.GetAll();
            Members = _MemberRepo.GetAll();
        }
        #endregion
        #region Methods
        public List<Course> ENTEREDcOURSES(Member member)
        {


            List<Course> list = new List<Course>();

            // if member apperes in the list of attendees then add course to list
            foreach (Course course in Courses)
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
                Course course = new Course(0, " ", start, end, attRange, members, master, " ", " ");
                list.Add(course);
            }
            Console.WriteLine("list of courses for a given member  just ran");
            return list;

        }


        public void OnGet()
        {
            //  ListOfCourses = _CourseRepo.GetAll();
            Console.WriteLine("SignInCourse/OnGet Just Ran--");
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("pressed EnterCourseSignIn");
            return RedirectToPage("EnterCourseSignIn");
        }
        #endregion
    }
}