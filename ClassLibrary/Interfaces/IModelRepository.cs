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
        Model GetModelByName(string modelName);
        void RemoveModel(string modelName);
        void EditModel(Model newModelInfo, Model model, string modelName, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight);
        void PrintAllModels();
    }
}
