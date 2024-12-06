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
        void AddBoat(Model modelName, string nickname, string registration);
        Boat GetBoatByReg(string registration);
        void RemoveBoat(string registration);
        void EditBoat(string oldBoatReg, string newBoatReg, string newNickname);
        int NumberOfModel(string modelName);
        void PrintAllBoats();
    }
}
