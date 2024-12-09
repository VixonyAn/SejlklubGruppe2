using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Interfaces;

namespace SejlklubRazor.Pages.Members
{
    public class ShowMembersModel : PageModel
    {
        private IMemberRepository _internalRepo;

        public List<IMember> Members { get; private set; }

        public ShowMembersModel(IMemberRepository memberRepository)
        {
            _internalRepo = memberRepository;
        }
        public void OnGet()
        {
            Members = _internalRepo.GetAll();
        }

        public IActionResult OnPostEdit(string oldName)
        {
            return RedirectToPage("AddMember", new { oldName = oldName });
        }

        public IActionResult OnPostDelete(string name)
        {
            _internalRepo.RemoveMember(name);
            return RedirectToPage("ShowMembers");
        }
    }
}
