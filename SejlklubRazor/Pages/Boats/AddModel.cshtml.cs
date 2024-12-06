using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class AddModelModel : PageModel
    {
        #region Instance Fields
        private IModelRepository _modelRepo;
        #endregion

        #region Properties
        [BindProperty] // Two way binding
        public string ModelName { get; set; }
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
        public AddModelModel(IModelRepository modelRepository)
        {
            _modelRepo = modelRepository;
        }
        #endregion

        #region Methods
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _modelRepo.AddModel(ModelName, Description, HullLength, HullWidth, HullDepth, BaseWeight);
            return RedirectToPage("ShowModelList");
        }
        #endregion
    }
}
