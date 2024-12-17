using ClassLibrary.Helpers;
using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace SejlklubRazor.Pages.ProofOfConcept
{

    public class SearchNameModel : PageModel
    {
        private IMemberRepository _memberRepo;

        public string Query { get; set; }

        public List<DLStringValuePair<IMember>> Matches { get; private set; }
        public List<DLStringValuePair<IMember>> Options { get; private set; }




        public string TheName { get; set; }
        public List<SelectListItem> ModelSelectList { get; set; }

        public SearchNameModel(IMemberRepository memberRepository)
        {
            _memberRepo = memberRepository;
        }

        public void OnGet(string name)
        {
            if (name != null)
            {
                Query = name;

                Options = DLStringComparer<IMember>.ConvertFromMember(_memberRepo.GetAll());
                Matches = DLStringComparer<IMember>.Matches(Options, Query, 9, 10);
            } else Matches = new List<DLStringValuePair<IMember>>();
        }

        /* https://stackoverflow.com/questions/71680811/call-model-function-from-javascript-in-razor-page */

        public async Task<IActionResult> OnGetUpdateAsync(string name)
        {
            if (name != null)
            {
                Query = name;

                Options = DLStringComparer<IMember>.ConvertFromMember(_memberRepo.GetAll());
                Matches = DLStringComparer<IMember>.Matches(Options, Query, 9, 10);
            }
            else Matches = new List<DLStringValuePair<IMember>>();

            return new JsonResult(Matches);
        }
    }
}
