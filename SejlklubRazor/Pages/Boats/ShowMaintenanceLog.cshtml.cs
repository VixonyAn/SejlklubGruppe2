using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowMaintenanceLogModel : PageModel
    {
        #region Instance Fields
        private IBoatRepository _boatRepo;
        private IMaintenanceRepository _maintRepo;
        #endregion

        #region Properties
        public List<MaintenanceNote> MaintenanceNotes { get; set; }
        [BindProperty]
        public Boat Boat { get; set; }
        public string BoatReg { get; set; }
        #endregion

        #region Constructors
        public ShowMaintenanceLogModel(IBoatRepository boatRepository, IMaintenanceRepository maintenanceRepository)
        {
            _boatRepo = boatRepository;
            _maintRepo = maintenanceRepository;
        }
        #endregion

        #region Methods
        public IActionResult OnPostDelete(int deleteMaintenanceNote, string boatReg)
        {
            _maintRepo.RemoveNote(deleteMaintenanceNote);
            return RedirectToPage("ShowMaintenanceLog", new { boatReg = boatReg });
        }

        public IActionResult OnPostEdit(int editMaintenanceNote, string boatReg)
        {
            return RedirectToPage("EditNote", new { editMaintenanceNote = editMaintenanceNote, boatReg = boatReg });
        }

        public IActionResult OnPostResolve(int resolveMaintenanceNote, string boatReg)
        {
            _maintRepo.ResolveNote(resolveMaintenanceNote);
            return RedirectToPage("ShowMaintenanceLog", new { boatReg = boatReg });
        }

        public IActionResult OnPostAdd(string boatReg)
        {
            return RedirectToPage("AddNote", new { boatReg = boatReg });
        }

        public void OnGet(string boatReg)
        {
            Boat = _boatRepo.GetBoatByReg(boatReg);
            MaintenanceNotes = _maintRepo.GetNotesByReg(boatReg);
        }
        #endregion
    }
}
