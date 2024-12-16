using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace SejlklubRazor.Pages.Courses
{
    public class EditCourseModel : PageModel
    {
        #region Instance Fields
        private ICourseRepository _courseRepo;
        private IMemberRepository _memberRepo;
        #endregion

        #region Properties
        [BindProperty] // Two way binding
        public string Name { get; set; }
        [BindProperty]
        public Course Course { get; set; }
        [BindProperty]
        public string MasterName { get; set; }
        [BindProperty]
        public int MinAttendeeNum { get; set; }
        [BindProperty]
        public int MaxAttendeeNum { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Summary { get; set; } // shorter version of the Description
        [BindProperty]
        public string Description { get; set; }


        #endregion

        #region Constructors
        public EditCourseModel(ICourseRepository courseRepository, IMemberRepository memberRepository) // dependency injection
        {
            _courseRepo = courseRepository; // parameter overført
            _memberRepo = memberRepository; // parameter overført
        }
        #endregion

        #region Methods
        public IActionResult OnGet(int Id)
        {
            Course = _courseRepo.GetCourseById(Id);
            Name = Course.Name;
            MasterName = Course.Master.Name;
            MaxAttendeeNum = Course.AttendeeRange[1];
            MinAttendeeNum = Course.AttendeeRange[0];
            StartDate = Course.TimeSlot[0];
            EndDate = Course.TimeSlot[1];
            Summary = Course.Summary;
            Description = Course.Description;

            return Page();
        }

        /*public IActionResult OnPost(int id)
        {
            Console.WriteLine("editCourse OnPost ran somehow, and got id: "+ id);
            return RedirectToPage("ShowCourseList");
        }*/
        public IActionResult OnPost(int id)
        {
            Console.WriteLine($"Edit course: {_courseRepo.GetCourseById(id)} ");
            int[] AttendeeRange = { MinAttendeeNum, MaxAttendeeNum };
            Course oldCourse = _courseRepo.GetCourseById(id);
            Course newcourse = new Course(0, Name, StartDate, EndDate, AttendeeRange, oldCourse.Attendees, (Member)_memberRepo.GetMemberByName(MasterName), Summary, Description);
            _courseRepo.Update(newcourse, _courseRepo.GetCourseById(id));
            return RedirectToPage("ShowCourseList");
        }
        public IActionResult OnPostDelete(int deleteId)
        {
            Console.WriteLine($"remove course: {_courseRepo.GetCourseById(deleteId)} ");
            _courseRepo.Delete(deleteId);
            return RedirectToPage("ShowCourseList");
        }
        #endregion
    }
}