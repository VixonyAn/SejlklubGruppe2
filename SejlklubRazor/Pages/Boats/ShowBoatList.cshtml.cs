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
        public void OnGet()
        {
            Boats = _boatRepo.GetAll();
        }
        #endregion
    }
}
