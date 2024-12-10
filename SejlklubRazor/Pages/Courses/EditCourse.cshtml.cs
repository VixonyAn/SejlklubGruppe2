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
        [BindProperty]
        public int editId { get; set; }
        #endregion

        #region Constructors
        public EditCourseModel(ICourseRepository courseRepository) // dependency injection
        {
            this._courseRepo = courseRepository; // parameter overført
        }
        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {
            Course = _courseRepo.GetCourseById(id);
            Name = Course.Name;
            Summary = Course.Summary;
            Description = Course.Description;
            MasterName = Course.Master.Name;
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _courseRepo.Update(id, Name, StartDate, EndDate, attendeeRange, );
            return RedirectToPage("ShowCourseList");
        }
        #endregion
    }
}
