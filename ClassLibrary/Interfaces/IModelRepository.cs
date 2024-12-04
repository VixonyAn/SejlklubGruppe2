using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        void AddModel(Model model);
        Model GetModelByName(string name);
        void RemoveModel(string name);
        void EditModel(Model newModelInfo, Model model, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight);
        void PrintAllModels();
    }
}
