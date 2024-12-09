using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class EditModelModel : PageModel
    {
        #region Instance Fields
        private IModelRepository _modelRepo;
        #endregion

        #region Properties
        [BindProperty] // Two way binding
        public Model Model { get; set; }
        [BindProperty]
        public string ModelName { get; set; }
        [BindProperty]
        public string newModelName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public double HullLength { get; set; }
        [BindProperty]
        public double HullWidth { get; set; }
        [BindProperty]
        public double HullDepth { get; set; }
        [BindProperty]
        public double BaseWeight { get; set; }
        #endregion

        #region Constructors
        public EditModelModel(IModelRepository modelRepository) // dependency injection
        {
            this._modelRepo = modelRepository; // parameter overført
        }
        #endregion

        #region Methods
        public IActionResult OnGet(string modelName)
        {
            Model = _modelRepo.GetModelByName(modelName);
            Description = Model.Description;
            HullLength = Model.HullLength;
            HullWidth = Model.HullWidth;
            HullDepth = Model.HullDepth;
            BaseWeight = Model.BaseWeight;
            return Page();
        }

        public IActionResult OnPost(string newModelName)
        {
            _modelRepo.EditModel(ModelName, newModelName, Description, HullLength, HullWidth, HullDepth, BaseWeight);
            return RedirectToPage("ShowModelList");
        }
        #endregion
    }
}
