using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowModelList : PageModel
    {
        #region Instance Fields
        private IModelRepository _modelRepo;
        private IBoatRepository _boatRepo;
        #endregion

        #region Properties
        public List<Model> Models { get; private set; }
        public List<Boat> Boats { get; private set; }
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
            Boats = _boatRepo.GetAll();
        }
        #endregion
    }
}
