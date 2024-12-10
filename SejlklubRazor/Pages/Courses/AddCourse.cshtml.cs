using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using ClassLibrary.Data;
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
        public MemberRepository _MemberRepo;


        public Dictionary<string, IMember> _MemberMap = MockData.GetInstance().MemberData;
        
        #endregion 

        #region Properties
       
        public IMember Master { get; set; }
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
            Master = _MemberMap[MasterName];
            int[] attRange = {MinAttendeeNum, MaxAttendeeNum};
            List<Member> members = new List<Member>();

            members.Add((Member)Master);
            Course course=new Course(_CourseRepo.Count, Name,StartDate,EndDate, attRange,members,(Member)Master, Description);
            _CourseRepo.Add(course);
            return RedirectToPage("ShowCourseList");
        }
        #endregion
  
    }
  
}