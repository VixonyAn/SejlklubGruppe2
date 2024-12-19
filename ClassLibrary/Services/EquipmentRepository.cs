using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private List<Equipment> _eqList;

        public EquipmentRepository()
        {
            _eqList = new List<Equipment>();
        }

        public int Count { get; }

        public void AddEquipment(Equipment eq)
        {
            _eqList.Add(eq);
        }

        public void DeleteEquipment(int id)
        {
            Equipment temp = GetEquipment(id);
            _eqList.Remove(GetEquipment(id));
        }

        public List<Equipment> GetAll()
        {
            return _eqList;
        }

        public Equipment GetEquipment(int id)
        {
            foreach (Equipment eq in _eqList)
            {
                if (eq.Id == id)
                {
                    return eq;
                }
            }
            throw new ArgumentException($"There is no equipment with an ID of {id}");
        }

        public void UpdateEquipment(Equipment newEquipment, int oldId)
        {
            Equipment temp = GetEquipment(oldId);
            temp.Type = newEquipment.Type;
            temp.Description = newEquipment.Description;
        }
    }
}
