using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Members
{
    public class AddMemberModel : PageModel
    {
        private IMemberRepository _internalMRepo;

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public string NameWarning { get; set; }


        public AddMemberModel(IMemberRepository memberRepository)
        {
            _internalMRepo = memberRepository;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                _internalMRepo.AddMember(Name, Phone, Email);
                return RedirectToPage("ShowMembers");
            } catch
            {
                NameWarning = "A customer with this name already exists";
                return Page();
            }


        }
    }
}
