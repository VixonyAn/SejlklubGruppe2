using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Interfaces
{
    public interface IBoatRepository
    {
        List<Boat> GetAll();
        void AddBoat(Boat boat);
        Boat GetBoatByReg(string registration);
        void RemoveBoat(string registration);
        void EditBoat(Boat newBoatInfo, Model model, string description, string registration);
        int NumberOfModel(string modelName);
        void PrintAllBoats();
    }
}
