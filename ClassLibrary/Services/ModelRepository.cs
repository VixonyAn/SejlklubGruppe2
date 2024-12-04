using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _models = new Dictionary<string, Model>();
        }
        #endregion

        #region Methods
        public List<Model> GetAll()
        {
            return _models.Values.ToList();
        }

        public void AddModel(Model model)
        {
            if (!_models.ContainsKey(model.ModelName))
            { // because dictionaries cannot contain duplicates
                _models.Add(model.ModelName, model);
            }
            else
            {
                throw new KeyTakenException($"En model af navnet '{model.ModelName}' findes allerede\n");
            }
        }

        public Model GetModelByName(string name)
        {
            if (name != null && _models.ContainsKey(name))
            {
                return _models[name];
            }
            return null;
        }

        public void RemoveModel(string name)
        {
            throw new NotImplementedException();
        }

        public void EditModel(Model newModelInfo, Model model, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight)
        {
            throw new NotImplementedException();
        }

        public void PrintAllModels()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
