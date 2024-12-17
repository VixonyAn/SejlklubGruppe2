using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class EditNoteModel : PageModel
    {
        #region Instance Fields
        private IMaintenanceRepository _maintRepo;
        #endregion

        #region Properties
        [BindProperty]
        public MaintenanceNote MaintenanceNote { get; set; }
        [BindProperty]
        public bool Resolved { get; set; }
        [BindProperty]
        public bool SevereDamage { get; set; }
        [BindProperty]
        public string Note { get; set; }
        [BindProperty]
        public int No { get; set; }
        [BindProperty]
        public string BoatReg { get; set; }
        #endregion

        #region Constructors
        public EditNoteModel(IMaintenanceRepository maintenanceRepository) // dependency injection
        {
            this._maintRepo = maintenanceRepository;
        }
        #endregion

        #region Methods
        public IActionResult OnGet(int editMaintenanceNote, string boatReg)//, string boatReg)
        { // retrieve a specific note by its ID so it can be edited
            BoatReg = boatReg; // saves boat registration for the OnPost method's redirect
            MaintenanceNote = _maintRepo.GetNoteById(editMaintenanceNote);
            No = MaintenanceNote.No; // displays the note's ID
            Resolved = MaintenanceNote.Resolved; // current resolved status
            SevereDamage = MaintenanceNote.SevereDamage; // current damage status
            Note = MaintenanceNote.Note; // displays current note on the editing page
            return Page();
        }

        public IActionResult OnPost()
        { // overwrites the contents of the note
            _maintRepo.EditNote(No, Note, SevereDamage, Resolved);
            return RedirectToPage("ShowMaintenanceLog", new { boatReg = BoatReg});
        }
        #endregion
    }
}
