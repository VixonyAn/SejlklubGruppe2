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
        public bool SevereDamage { get; set; }
        [BindProperty]
        public string Note { get; set; }
        #endregion

        #region Constructors
        public EditNoteModel(IMaintenanceRepository maintenanceRepository) // dependency injection
        {
            this._maintRepo = maintenanceRepository;
        }
        #endregion

        #region Methods
        public IActionResult OnGet(int editMaintenanceNote)
        { // retrieve a specific note by it's ID so it can be edited
            MaintenanceNote = _maintRepo.GetNoteById(editMaintenanceNote);
            SevereDamage = MaintenanceNote.SevereDamage;
            Note = MaintenanceNote.Note;
            return Page();
        }

        public IActionResult OnPost(int editMaintenanceNote, string note, bool severeDamage)
        { // overwrites the contents of the note
            _maintRepo.EditNote(editMaintenanceNote, note, severeDamage);
            return RedirectToPage("ShowMaintenanceLog");
        }
        #endregion
    }
}
