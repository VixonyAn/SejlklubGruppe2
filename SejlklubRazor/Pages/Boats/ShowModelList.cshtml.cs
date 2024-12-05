using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowModelList : PageModel
    {   // This page should show the profiles of all the boat models the club owns
        // Show the models name, description, and the number of boats of this model the club owns
        #region Instance Fields
        private IModelRepository _modelRepo;
        private IBoatRepository _boatRepo;
        #endregion

        #region Properties
        public List<Model> Models { get; private set; }
        public IBoatRepository Boats { get; private set; }
        #endregion

        #region Constructors
        public ShowModelList(IModelRepository modelRepository, IBoatRepository boatRepository)
        {
            _modelRepo = modelRepository;
            _boatRepo = boatRepository;
        }
        #endregion

        #region Methods
        public void OnGet()
        {
            Models = _modelRepo.GetAll();
            Boats = _boatRepo;
        }
        #endregion
    }
}
