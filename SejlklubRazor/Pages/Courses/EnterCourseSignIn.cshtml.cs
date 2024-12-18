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

        
       
        public ICourseRepository Courep {  get; set; }

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
            Courep = _CourseRepo;
            Console.WriteLine($" SelectedMember is {_CourseRepo.SelectedMember}");
            if (_CourseRepo.SelectedMember == null)
            {
                _CourseRepo.SelectedMember = (Member)_MemberRepo.GetMemberByName("Kurt");
                Console.WriteLine("(EnterCourseSignIn.cshtml.cs)  SelectedMember was null, changed it to Kurt");
            }
        }

        #endregion

        #region Methods
        public List<Course> NonEnteredCoursesByMember(Member member) 
        {
            List<Course> list = new List<Course>();
            Console.WriteLine("list == null");
            DateTime start = new DateTime(0001, 01, 01);
            DateTime end = new DateTime(0001, 01, 01);
            int[] attRange = { 1, 1000 };
            List<Member> members = new List<Member>();
            Member master = new Member(" ", "  ", "  ");
            members.Add(master);
            Course course1 = new Course(0, " ", start, end, attRange, members, master, " ", " ");
            list.Add(course1);

            foreach (ICourse course in Courses)
            {
                if (!_CourseRepo.EnteredCourses(member).Contains(course))
                {
                    if (list[0].Name==" ")
                    {
                        list.Remove(list[0]);
                    }
                    list.Add((Course)course);
                }
             
            }
            Console.WriteLine($"the list of non entered courses is: {list[0]}");
            return list;
        }

        public List<IMember> SortedMembers()
        {
            List<IMember> list = new List<IMember>();
            list = Members;
            list.Remove(_CourseRepo.SelectedMember);
            list.Prepend(_CourseRepo.SelectedMember);
            return list;
        }

        public void OnGet()
        {
            if (_CourseRepo.SelectedMember == null)
            {
                _CourseRepo.SelectedMember = new Member("noone is selected yet", "no", "no");
            }
        }
 

        
        public IActionResult OnPostAttendCourse(int Id)
        {

            Console.WriteLine($"selectedMember is {_CourseRepo.SelectedMember}");
            _CourseRepo.AttendCourse(Id, (Member)_CourseRepo.SelectedMember);

            return RedirectToPage("SignInCourse");
        }

        public IActionResult OnPostSelectMemberButton(string Name)
        {

            _CourseRepo.SelectedMember = (Member)_MemberRepo.GetMemberByName(Name);
            Console.WriteLine($"Selected Member = {_CourseRepo.SelectedMember}");
            if (_CourseRepo.SelectedMember == null)
            {
                Console.WriteLine("SelectedMember is NULL"); // Debugging: Log null issues
            }

            return Page();
        }
        #endregion
    }
}
