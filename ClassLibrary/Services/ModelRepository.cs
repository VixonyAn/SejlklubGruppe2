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
            if (!_models.ContainsKey(modelName))
            { // because dictionaries cannot contain duplicates
                Model newModel = new Model(modelName, description, hullLength, hullWidth, hullDepth, baseWeight);
                _models.Add(modelName, newModel);
            }
            else
            {
                throw new KeyTakenException($"En model af navnet '{modelName}' findes allerede\n");
            }
        }

        public Model GetModelByName(string modelName)
        {
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

        public void EditModel(Model newModelInfo, Model model, string modelName, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight)
        {
            Model oldModelInfo = GetModelByName(modelName);
            oldModelInfo.ModelName = newModelInfo.ModelName;
            oldModelInfo.Description = newModelInfo.Description;
            oldModelInfo.HullLength = newModelInfo.HullLength;
            oldModelInfo.HullWidth = newModelInfo.HullWidth;
            oldModelInfo.HullDepth = newModelInfo.HullDepth;
            oldModelInfo.BaseWeight = newModelInfo.BaseWeight;
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
