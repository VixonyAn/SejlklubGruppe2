using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazor.Pages.Boats
{
    public class ShowModelInfo : PageModel
    {
        private IModelRepository _modelRepo;

        public Model Model { get; set; } // NEEDS TO CHANGE TO ONLY SHOW ONE!!!!!

        public ShowModelInfo(IModelRepository modelRepository)
        {
            _modelRepo = modelRepository;
        }
        public void OnGet(string modelName)
        {
            Model = _modelRepo.GetModelByName(modelName);
        }
    }
}
