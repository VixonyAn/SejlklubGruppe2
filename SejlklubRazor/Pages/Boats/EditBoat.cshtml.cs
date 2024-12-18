using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace SejlklubRazor.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        #region Instance Fields
        private IBoatRepository _boatRepo;
        #endregion

        #region Properties
        [BindProperty] // Two way binding
        public Boat Boat { get; set; }
        [BindProperty]
        public string Registration { get; set; }
        [BindProperty]
        public string newRegistration { get; set; }
        [BindProperty]
        public string Nickname { get; set; }

        #endregion

        #region Constructors
        public EditBoatModel(IBoatRepository boatRepository) // dependency injection
        {
            this._boatRepo = boatRepository; // parameter overført
        }
        #endregion

        #region Methods
        public IActionResult OnGet(string registration)
        {
            Boat = _boatRepo.GetBoatByReg(registration);
            // Registration appears on the edit page thanks to ShowBoatList OnPostEdit
            Nickname = Boat.Nickname; // makes the current nickname appear in the nickname field
            return Page();
        }

        public IActionResult OnPost(string newRegistration)
        {
            _boatRepo.EditBoat(Registration, newRegistration, Nickname);
            return RedirectToPage("ShowBoatList");
        }
        #endregion
    }
}
