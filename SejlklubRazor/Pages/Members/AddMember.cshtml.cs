using ClassLibrary.Exceptions;
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

        public string OldName { get; set; }
        public string PrevName { get; set; }


        public AddMemberModel(IMemberRepository memberRepository)
        {
            _internalMRepo = memberRepository;
        }
        public void OnGet(string oldName)
        {
            OldName = oldName;
        }

        public IActionResult OnPost(string oldName)
        {
            OldName = oldName;
            try
            {
                if(OldName == null)
                {
                    _internalMRepo.AddMember(Name, Phone, Email);
                    return RedirectToPage("ShowMembers");
                } else
                {
                    _internalMRepo.EditMember(OldName, Name, Phone, Email);
                    return RedirectToPage("ShowMembers");
                }
            } catch(KeyTakenException keyEx)
            {
                if (OldName == null) PrevName = Name;
                else PrevName = OldName;

                NameWarning = PrevName + " er allerede registreret som navn.";
                return Page();
            }


        }
    }
}
