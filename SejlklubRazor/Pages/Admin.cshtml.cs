using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages
{
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostAddModel()
        {
            return RedirectToPage("/Boats/AddModel");
        }

        public IActionResult OnPostShowModelList()
        {
            return RedirectToPage("/Boats/ShowModelList");
        }

        public IActionResult OnPostAddBoat()
        {
            return RedirectToPage("/Boats/AddBoat");
        }

        public IActionResult OnPostShowBoatList()
        {
            return RedirectToPage("/Boats/ShowBoatList");
        }

        public IActionResult OnPostAddCourse()
        {
            return RedirectToPage("/Courses/AddCourse");
        }

        public IActionResult OnPostShowCourseList()
        {
            return RedirectToPage("/Courses/ShowCourseList");
        }

        public IActionResult OnPostAddMember()
        {
            return RedirectToPage("/Members/AddMember");
        }

        public IActionResult OnPostShowMembers()
        {
            return RedirectToPage("/Members/ShowMembers");
        }
    }
}
