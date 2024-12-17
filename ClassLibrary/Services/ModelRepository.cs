using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class ModelRepository : IModelRepository
    {
        #region Instance Fields
        private Dictionary<string, Model> _models; // string is Name as key
        #endregion

        #region Constructors
        public ModelRepository()
        {
            _models = MockData.GetInstance().ModelData;
            //_models = new Dictionary<string, Model>();
        }
        #endregion

        #region Methods
        public List<Model> GetAll()
        {
            return _models.Values.ToList();
        }

        public void AddModel(string modelName, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight)
        {
            if (!_models.ContainsKey(modelName)) // if modelname is NOT in the list, add new model
            { // because dictionaries cannot contain duplicates
                Model newModel = new Model(modelName, description, hullLength, hullWidth, hullDepth, baseWeight);
                _models.Add(modelName, newModel);
            }
            else
            { // else if modelname is in the list, throw an exception
                throw new KeyTakenException($"En model af navnet '{modelName}' findes allerede\n");
            }
        }

        public Model GetModelByName(string modelName)
        { // if the input isn't empty, and the list contains the modelName, return the model of that name
            if (modelName != null && _models.ContainsKey(modelName))
            {
                return _models[modelName];
            }
            return null;
        }

        public void RemoveModel(string modelName)
        {
            _models.Remove(modelName);
        }

        public void EditModel(string oldModelName, string newModelName, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight)
        {
            if (_models.ContainsKey(newModelName))
            { // if Dict already contains a Model with the new ModelName, throw an exception
                throw new KeyTakenException($"Kan ikke ændre modellens navn til '{newModelName}' denne model navn findes allerede\n");
            } // else
            Model oldModel = _models[oldModelName]; // temp Ref to Model, gets oldModel info
            _models.Remove(oldModelName); // severs Ref to the Model (oldModelName) in the Dict
            _models[newModelName] = oldModel; // oldModel info placed in new spot using new ModelName as key
            oldModel.ModelName = newModelName; // overwrites old ModelName with new ModelName in object (not key)
            oldModel.Description = description; // the rest overwrite old info with new info
            oldModel.HullLength = hullLength;
            oldModel.HullWidth = hullWidth;
            oldModel.HullDepth = hullDepth;
            oldModel.BaseWeight = baseWeight;
        }

        public void PrintAllModels()
        {
            foreach (Model model in _models.Values)
            {
                Console.WriteLine(model.ToString());
            }
        }
        #endregion
    }
}
