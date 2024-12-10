using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using ClassLibrary.Data;
using SejlklubRazor.Pages.Members;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubRazor.Pages.Courses.ShowCourseList;

namespace SejlklubRazor.Pages.Courses.AddCourse
{
    public class AddCourseModel : PageModel
    {
  
        #region Instance Fields
        private ICourseRepository _courseRepo;
        private IMemberRepository _memberRepo;


        //public Dictionary<string, IMember> _MemberMap = MockData.GetInstance().MemberData;
        
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
        [BindProperty] // Two way binding
        public string Summary { get; set; }

        #endregion
        #region Constructors
        public AddCourseModel(ICourseRepository courseRepository, IMemberRepository memberRepository)
        {
            _courseRepo = courseRepository;
            _memberRepo = memberRepository;
        }
        #endregion
        #region Methods
        public void OnGet()
        {
            Console.WriteLine("AddCourse.cshtml.cs  line 42 here!!!!!!!!!!!!!!!____________________--------------");
        }
        public IActionResult OnPost()
        {
            Master = _memberRepo.GetMemberByName(MasterName);
            int[] attRange = {MinAttendeeNum, MaxAttendeeNum};
            List<Member> members = new List<Member>();

            members.Add((Member)Master);
            _courseRepo.Add(Name, StartDate, EndDate, attRange, members, (Member)Master, Summary, Description);
            return RedirectToPage("ShowCourseList");
        }
        #endregion
  
    }
  
}