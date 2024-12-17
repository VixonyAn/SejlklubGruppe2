using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubRazor.Pages.Members;
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

        [BindProperty]
        public Member Member { get;  set; }

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
            Member nenenen=new Member("Nothing is selected yet","no","no");
            Member = Member ?? nenenen;
        }
        #endregion
        #region Methods
        public List<Course> ENTEREDcOURSES(Member member)
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
            // if member apperes in the list of attendees then add course to list
            foreach (Course course in Courses)
            {
                foreach (Member mem in course.Attendees)
                {
                    if (mem == member)
                    {
                        if (list.Count >= 0 && list[0].Name == " ")
                        {
                            Console.WriteLine("just removed smth");
                            list.Remove(list[0]);
                        }
                        else { Console.WriteLine("all clear to proceed"); }
                        list.Add(course);

                    }
                }
            }
            
            Console.WriteLine("list of courses for a given member  just ran, and the first item in the list was \n " + list[0]);
            return list;

        }

        public bool say(string text)
        {
            Console.WriteLine(text);
            return true;
        }

        public void OnGet()
        {
            //  ListOfCourses = _CourseRepo.GetAll();
            
            Console.WriteLine("SignInCourse/OnGet Just Ran--");
        }


        public IActionResult OnPostEnterCourseSignIn(string Name)
        {


            //
            Console.WriteLine("Name" + Name);
            Console.WriteLine($"{Member.Name} is chosen");
            Console.WriteLine("pressed EnterCourseSignIn");
            return RedirectToPage("EnterCourseSignIn");
        }
        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Member.Name))
            {
                // Process the submitted value (e.g., log, save to DB, etc.)
                Console.WriteLine($"Selected Option: {Member.Name}");

                // Return a JSON or plain text response for Ajax
                return new JsonResult(new { success = true, message = "Selection received successfully!" });
            }

            // Handle errors or invalid submissions
            return new JsonResult(new { success = false, message = "Invalid selection!" });
        }
     
        #endregion
    }
}