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
        public string oldBoatReg { get; set; }
        [BindProperty]
        public string newBoatReg { get; set; }
        [BindProperty]
        public string newNickname { get; set; }

        #endregion

        #region Constructors
        public EditBoatModel(IBoatRepository boatRepository) // dependency injection
        {
            this._boatRepo = boatRepository; // parameter overført
        }
        #endregion

        #region Methods
        public IActionResult OnGet(string oldBoatReg)
        {
            Boat = _boatRepo.GetBoatByReg(oldBoatReg);
            return Page();
        }

        public IActionResult OnPost(string oldBoatReg)
        {
            _boatRepo.EditBoat(oldBoatReg, newBoatReg, newNickname);
            return RedirectToPage("ShowBoatList");
        }
        #endregion
    }
}
