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
        public List<IMaintenanceNote> MaintenanceNote { get; set; }
        public Boat Boat { get; set; }
        //public MaintenanceNote MaintenanceNote { get; set; }
        #endregion

        #region Constructors
        public ShowMaintenanceLogModel(IBoatRepository boatRepository) //, IMaintenanceRepository maintenanceRepository)
        {
            //_maintRepo = maintenanceRepository;
            _boatRepo = boatRepository;
            //_maintRepo = boatRepository.GetBoatByReg(boatReg).MaintenanceLog;
        }
        #endregion

        #region Methods
        public IActionResult OnPostDelete(int deleteMaintenanceNote)
        {
            _maintRepo.RemoveNote(deleteMaintenanceNote);
            return RedirectToPage("ShowMaintenanceLog");
        }

        public IActionResult OnPostEdit(int editMaintenanceNote)
        {
            return RedirectToPage("EditNote", new { editMaintenanceNote = editMaintenanceNote });
        }

        public IActionResult OnPostResolve(int resolveMaintenanceNote, string boatReg)
        {
            _maintRepo = _boatRepo.GetBoatByReg(boatReg).MaintenanceLog;
            MaintenanceNote = _maintRepo.GetAll();
            _maintRepo.ResolveNote(resolveMaintenanceNote);
            return RedirectToPage("ShowMaintenanceLog");
        }

        public void OnGet(string boatReg)
        {
            Boat = _boatRepo.GetBoatByReg(boatReg);
            _maintRepo = Boat.MaintenanceLog;
            MaintenanceNote = _maintRepo.GetAll();
            //MaintenanceNote = _maintRepo.GetNoteById(boatReg);
        }
        #endregion
    }
}
