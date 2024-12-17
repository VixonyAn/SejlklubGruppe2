using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Courses.ShowCourseList
{
    public class ShowCourseListModel : PageModel
    {   // This page should show the list of all the courses
        // Show the Courses title, description, and the number of places left in that course   maxNumOfAttendees - Attendees.Count
        #region Instance Fields
        private ICourseRepository _CourseRepo;

        #endregion

        #region Properties
        public List<ICourse> ListOfCourses { get; private set; }

        #endregion

        #region Constructors
        public ShowCourseListModel(ICourseRepository courseRepository)
        {
            _CourseRepo = courseRepository;
            ListOfCourses = _CourseRepo.GetAll();
        }

        #endregion

        #region Methods




        public IActionResult OnPostEdit(int id)
        {
            return RedirectToPage("EditCourse", new { id });
        }


        public IActionResult OnPostSignIn()
        {
            Console.WriteLine("ShowCourseList/OnPostSignIn just ran");
            return RedirectToPage("SignInCourse");
        }

        public void OnGet()
        {
            
        }
        #endregion
    }
}
