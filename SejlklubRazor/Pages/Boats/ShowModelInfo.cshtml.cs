using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowModelInfo : PageModel
    {
        #region Instance Fields
        private IModelRepository _modelRepo;
        #endregion

        #region Properties
        public Model Model { get; set; }
        #endregion

        #region Constructors
        public ShowModelInfo(IModelRepository modelRepository)
        {
            _modelRepo = modelRepository;
        }
        #endregion

        #region Methods
        public IActionResult OnPostDelete(string deleteModelName)
        {
            _modelRepo.RemoveModel(deleteModelName);
            return RedirectToPage("ShowModelList");
        }

        public IActionResult OnPostEdit(string modelName)
        {
            return RedirectToPage("EditModel", new { modelName = modelName });
        }

        public void OnGet(string modelName)
        {
            Model = _modelRepo.GetModelByName(modelName);
        }
        #endregion

    }
}
