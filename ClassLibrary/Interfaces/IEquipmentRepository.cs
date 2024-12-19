using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IEquipmentRepository
    {
        int Count { get; }

        List<Equipment> GetAll();

        Equipment GetEquipment(int id);

        void DeleteEquipment(int id);

        void UpdateEquipment(Equipment newEquipment, int oldId);

        void AddEquipment(Equipment eq);
    }
}
