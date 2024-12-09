using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SejlklubRazor.Pages.Courses.AddCourse
{
    public class AddCourseModel(ICourseRepository CourseRepository) : PageModel
    {
  
        #region Instance Fields
        private ICourseRepository _CourseRepo = CourseRepository;
        private IMemberRepository _MemberRepo;
        #endregion 

        #region Properties
        public Member Master { get; set; }
        [BindProperty] // Two way binding
        public string Name { get; set; }
        [BindProperty] // Two way binding
        public int MinAttendeeNum { get; set; }
        [BindProperty] // Two way binding
        public int MaxAttendeeNum { get; set; }
        [BindProperty] // Two way binding
        public DateTime StartDate { get; set; }
        [BindProperty] // Two way binding
        public DateTime EndDate { get; set; }
        [BindProperty] // Two way binding
        public string Description { get; set; }
        [BindProperty] // Two way binding
        public string MasterName { get; set; }

        #endregion
        #region Constructors
        #endregion
        #region Methods
        public void OnGet()
        {
            Console.WriteLine("AddCourse.cshtml.cs  line 42 here!!!!!!!!!!!!!!!____________________--------------");
        }
        public IActionResult OnPost()
        {
            int[] attRange = {MinAttendeeNum, MaxAttendeeNum};
            List<Member> members = new List<Member>();
            members.Add(Master);
            Course course=new Course(_CourseRepo.Count, Name,StartDate,EndDate, attRange,members,Master, Description);
            _CourseRepo.Add(course);
            return RedirectToPage("ShowCourseList");
        }
        #endregion
  
    }
  
}