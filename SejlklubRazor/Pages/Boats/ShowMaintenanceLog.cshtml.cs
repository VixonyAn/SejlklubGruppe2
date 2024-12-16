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
        public List<MaintenanceNote> MaintenanceNote { get; set; }
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
            return RedirectToPage("ShowMaintenanceLog");
        }

        public IActionResult OnPostEdit(int editMaintenanceNote, int boatReg)
        {
            return RedirectToPage("EditNote", new { editMaintenanceNote = editMaintenanceNote, boatReg = boatReg });
        }

        public IActionResult OnPostResolve(int resolveMaintenanceNote)
        {
            //_maintRepo = _boatRepo.GetBoatByReg(boatReg).MaintenanceLog;
            //MaintenanceNote = _maintRepo.GetAll();
            _maintRepo.ResolveNote(resolveMaintenanceNote);
            return RedirectToPage("ShowMaintenanceLog");
        }

        public void OnGet(string boatReg)
        {
            Boat = _boatRepo.GetBoatByReg(boatReg);
            MaintenanceNote = _maintRepo.GetNotesByReg(boatReg);
            //_maintRepo = Boat.MaintenanceLog;
            //MaintenanceNote = _maintRepo.GetAll();
            //MaintenanceNote = _maintRepo.GetNoteById(boatReg);
        }
        #endregion
    }
}
