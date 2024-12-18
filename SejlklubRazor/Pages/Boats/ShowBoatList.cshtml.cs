using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowBoatListModel : PageModel
    {   // This page should show a list of all the boats the club owns
        // Show the boats model, name, registration id, and a link to the maintenance log
        #region Instance Fields
        private IBoatRepository _boatRepo;
        #endregion

        #region Properties
        public List<Boat> Boats { get; private set; }
        #endregion

        #region Constructors
        public ShowBoatListModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
            Boats = _boatRepo.GetAll();
        }
        #endregion

        #region Methods
        public IActionResult OnPostDelete(string deleteRegistration)
        {
            _boatRepo.RemoveBoat(deleteRegistration);
            return RedirectToPage("ShowBoatList");
        }

        public IActionResult OnPostEdit(string Registration)
        { // redirects along with the Registration ID so it can be displayed on the editing page
            return RedirectToPage("EditBoat", new { Registration = Registration });
        }

        public void OnGet()
        {
            Boats = _boatRepo.GetAll();
        }
        #endregion
    }
}
