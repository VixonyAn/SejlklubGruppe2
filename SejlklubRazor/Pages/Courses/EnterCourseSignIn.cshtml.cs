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

        private ICourseRepository _CourseRepo;
        private IMemberRepository _MemberRepo;
        #endregion

        #region Properties
        public Course SelectedCourse { get; private set; }
        public Member Member { get; private set; }


        public List<IMember> Members { get; set; }
        public List<ICourse> Courses { get; set; }
        #endregion

        #region Constructors


        public EnterCourseSignInModel(ICourseRepository courseRepository, IMemberRepository memberRepository)
        {
            _CourseRepo = courseRepository;
            _MemberRepo = memberRepository;
            Courses = _CourseRepo.GetAll();
            Members = _MemberRepo.GetAll();

        }

        #endregion

        #region Methods
        public List<Course> NonEnteredCoursesByMember(Member member) 
        {
            List<Course> list = new List<Course>();
            foreach (ICourse course in Courses)
            {
                if (!(_CourseRepo.EnteredCourses(member).Contains((ICourse)course)))
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
            Console.WriteLine($"{Member.Name} aplied to Course: {_CourseRepo.GetCourseById(Id)}");
            if(_CourseRepo.GetCourseById(Id).Attendees.Count<= _CourseRepo.GetCourseById(Id).AttendeeRange[1])
            {
                _CourseRepo.GetCourseById(Id).Attendees.Add(Member);
                return RedirectToPage("SignInCourse");
            }
            else
            {
                Console.WriteLine($"{Member} tried to sign in to course: {_CourseRepo.GetCourseById(Id).Name}, But there is too many");
            }
            
            return RedirectToPage("SignInCourse");
        }
        #endregion
    }
}
