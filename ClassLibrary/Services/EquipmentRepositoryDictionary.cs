using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class EquipmentRepositoryDictionary : IEquipmentRepository
    {
        private Dictionary<int, Equipment> _eqDict;

        public EquipmentRepositoryDictionary()
        {
            _eqDict = new Dictionary<int, Equipment>();
        }


        public int Count { get { return _eqDict.Count; } }

        public void AddEquipment(Equipment eq)
        {
            if (!_eqDict.ContainsKey(eq.Id))
            {
                _eqDict.Add(eq.Id, eq);
            }
            else throw new Exception("The equipment already exists in the dictionary");
        }

        public void DeleteEquipment(int id)
        {
            if (!_eqDict.ContainsKey(id)) throw new Exception($"There is no equipment with an ID of {id}");
            else _eqDict.Remove(id);
        }

        public List<Equipment> GetAll()
        {
            return _eqDict.Values.ToList();
        }

        public Equipment GetEquipment(int id)
        {
            if (_eqDict.ContainsKey(id)) return _eqDict[id];
            throw new Exception($"There is no equipment with an ID of {id} in the dictionary");
        }

        public void UpdateEquipment(Equipment newEquipment, int oldId)
        {
            _eqDict[oldId].Type = newEquipment.Type;
            _eqDict[oldId].Description = newEquipment.Description;
        }
    }
}
