using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Courses.ShowCourseList
{
    public class ShowCourseList : PageModel
    {   // This page should show the list of all the courses
        // Show the Courses title, description, and the number of places left in that course   maxNumOfAttendees - Attendees.Count
        #region Instance Fields
        private ICourseRepository _CourseRepo;

        #endregion

        #region Properties
        public List<Course> ListOfCourses { get; private set; }

        #endregion

        #region Constructors
        public ShowCourseList(ICourseRepository courseRepository)
        {
            _CourseRepo = courseRepository;
            ListOfCourses = _CourseRepo.GetAll();
        }

        #endregion

        #region Methods


        public IActionResult OnPostDelete(int deleteId)
        {

            
            _CourseRepo.Delete(deleteId);
            // return RedirectToPage("DeleteCourse");

            return RedirectToPage("ShowCourse");
        }

        public IActionResult OnPostEdit(int id)
        {
            return RedirectToPage("EditCourse", new { id });
        }




        public void OnGet()
        {
            
        }
        #endregion
    }
}
