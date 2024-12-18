using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace SejlklubRazor.Pages.Boats
{
    public class AddNoteModel : PageModel
    { //dropdown to choose boat, display name, model and registration
        #region Instance Fields
        private IMaintenanceRepository _maintRepo;
        private IMemberRepository _memberRepo;
        private IBoatRepository _boatRepo;
        #endregion

        #region Properties
        [BindProperty]
        public string Note { get; set; }
        [BindProperty]
        public bool SevereDamage { get; set; }
        [BindProperty]
        public string BoatReg { get; set; }
        [BindProperty]
        public string MemberName { get; set; }
        #endregion

        #region Constructors
        public AddNoteModel(IMaintenanceRepository maintenanceRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
        {
            _maintRepo = maintenanceRepository;
            _memberRepo = memberRepository;
            _boatRepo = boatRepository;
        }
        #endregion

        #region Methods
        public IActionResult OnGet(string boatReg)
        {
            BoatReg = boatReg;
            return Page();
        }

        public IActionResult OnPost()
        {
            _maintRepo.AddNote((Member)_memberRepo.GetMemberByName(MemberName), _boatRepo.GetBoatByReg(BoatReg), Note, SevereDamage);
            return RedirectToPage("ShowMaintenanceLog", new { boatReg = BoatReg });
        }
        #endregion
    }
}
