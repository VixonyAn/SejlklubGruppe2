using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary.Models;
using ClassLibrary.Services;

namespace SejlklubRazor.Pages.Boats
{
    public class AddBoatModel : PageModel
    {
        #region Instance Fields
        private IBoatRepository _boatRepo;
        private IModelRepository _modelRepo;
        #endregion

        #region Properties
        [BindProperty] // Two way binding
        public string Nickname { get; set; }
        [BindProperty]
        public string Registration { get; set; }
        [BindProperty]
        public string ModelName { get; set; }
        public List<SelectListItem> ModelSelectList { get; set; }
        #endregion
        
        #region Constructors
        public AddBoatModel(IBoatRepository boatRepository, IModelRepository modelRepository) // dependency injection
        {
            _boatRepo = boatRepository; // parameter overført
            _modelRepo = modelRepository;
            createModelSelectList();
        }
        #endregion

        #region Methods
        private void createModelSelectList() // small first letter for private methods
        {
            List<Model> ModelList = _modelRepo.GetAll();
            ModelSelectList = new List<SelectListItem>();
            ModelSelectList.Add(new SelectListItem("Vælg en Model", "-1"));
            foreach (Model model in ModelList)
            {
                SelectListItem msl = new SelectListItem(model.ModelName, model.ModelName);
                ModelSelectList.Add(msl);
            }
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _boatRepo.AddBoat(_modelRepo.GetModelByName(ModelName), Nickname, Registration);
            return RedirectToPage("ShowBoatList");
        }
        #endregion
    }
}
