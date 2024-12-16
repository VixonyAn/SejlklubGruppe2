using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SejlklubRazor.Pages.ProofOfConcept
{

    public class SearchNameModel : PageModel
    {
        private IMemberRepository _memberRepo;

        public string Query { get; set; }

        public List<DLStringValuePair> Matches { get; set; }
        public List<DLStringValuePair> Options { get; set; }



        public string TheName { get; set; }
        public List<SelectListItem> ModelSelectList { get; set; }

        public SearchNameModel(IMemberRepository memberRepository)
        {
            _memberRepo = memberRepository;
        }

        public void OnGet()
        {
            Matches = new List<DLStringValuePair>();
            Options = DLStringComparer.ConvertFromMember(_memberRepo.GetAll());
        }

        /* https://stackoverflow.com/questions/71680811/call-model-function-from-javascript-in-razor-page */

        public void OnGetUpdate(string name)
        {
            if (name != null) Query = name;
            else Query = "";
            Options = DLStringComparer.ConvertFromMember(_memberRepo.GetAll());
            Matches = DLStringComparer.Matches(Options, Query, 9, 10);
        }
    }
}
