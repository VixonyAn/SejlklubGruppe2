using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubRazor.Pages.Members;
namespace SejlklubRazor.Pages.Courses
{
    public class EnterCourseSignInModel : PageModel
    {
        #region Instance Fields

        private CourseRepository _CourseRepo;
        private IMemberRepository _MemberRepo;
        #endregion

        #region Properties
        public Course SelectedCourse { get; private set; }
        public Member Member { get; private set; }


        public List<IMember> Members { get; set; }
        public CourseRepository Courses { get; set; }
        #endregion

        #region Constructors


        public EnterCourseSignInModel(CourseRepository courseRepository, IMemberRepository memberRepository)
        {
            _CourseRepo = courseRepository;
            _MemberRepo = memberRepository;
            Courses = _CourseRepo;
            Members = _MemberRepo.GetAll();

        }

        #endregion

        #region Methods
        public List<Course> NonEnteredCoursesByMember(Member member) 
        {
            List<Course> list = new List<Course>();
            foreach (var course in Courses.GetAll())
            {
                if (!(Courses.EnteredCourses(member).Contains(course)))
                {
                    list.Add((Course)course);
                }
            }
            return list;
        }

        public void OnGet()
        {   
        }
        public IActionResult OnPost(int Id)
        {
            Console.WriteLine($"{Member} aplied to Course: {Courses.GetCourseById(Id)}");
            if(Courses.GetCourseById(Id).Attendees.Count<= Courses.GetCourseById(Id).AttendeeRange[1])
            {
                Courses.GetCourseById(Id).Attendees.Add(Member);
                return RedirectToPage("SignInCourse");
            }
            else
            {
                Console.WriteLine($"{Member} tried to sign in to course: {Courses.GetCourseById(Id).Name}, But there is too many");
            }
            
            return RedirectToPage("SignInCourse");
        }
        #endregion
    }
}
