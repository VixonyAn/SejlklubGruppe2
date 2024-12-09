using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
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

        public IMember OldUser { get; set; }
        public IMember ExistingUser { get; set; }


        public AddMemberModel(IMemberRepository memberRepository)
        {
            _internalMRepo = memberRepository;
        }
        public void OnGet(string oldEmail)
        {
            if (oldEmail != null) 
            {
                OldUser = _internalMRepo.GetMemberByEmail(oldEmail);
                Name = OldUser.Name;
                Phone = OldUser.Phone;
                Email = OldUser.Email;
            }
        }

        public IActionResult OnPost(string oldEmail)
        {
            try
            {
                if(oldEmail == null)
                {
                    _internalMRepo.AddMember(Name, Phone, Email);
                    return RedirectToPage("ShowMembers");
                } else
                {
                    _internalMRepo.EditMember(Name, Phone, oldEmail, Email);
                    return RedirectToPage("ShowMembers");
                }
            } catch(KeyTakenException keyEx)
            {
                if (oldEmail == null) OldUser = _internalMRepo.GetMemberByEmail(Email);
                else
                {
                    OldUser = _internalMRepo.GetMemberByEmail(oldEmail);
                }
                    ExistingUser = _internalMRepo.GetMemberByEmail(Email);

                NameWarning = "en bruger er allerede registreret med Email: " + ExistingUser.Email;
                return Page();
            }


        }
    }
}
