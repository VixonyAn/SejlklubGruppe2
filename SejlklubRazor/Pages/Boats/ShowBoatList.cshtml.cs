using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowBoatListModel : PageModel
    {
        private IBoatRepository _boatRepo;

        public List<Boat> Boats { get; private set; }

        public ShowBoatListModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
        }
        public void OnGet()
        {
            Boats = _boatRepo.GetAll();
        }
    }
}
