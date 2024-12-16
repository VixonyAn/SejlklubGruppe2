using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Exceptions;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using ClassLibrary.Data;

namespace ClassLibrary.Services
{
    public class BoatRepository : IBoatRepository
    {
        #region Instance Fields
        private Dictionary<string, Boat> _boats; // Registration as key
        #endregion

        #region Constructors
        public BoatRepository()
        {
            _boats = MockData.GetInstance().BoatData; // boat dictionary is filled by mockdata
            //_boats = new Dictionary<string, Boat>();
        }
        #endregion

        #region Methods
        public List<Boat> GetAll()
        {
            return _boats.Values.ToList(); // gets all our values
        }

        public void AddBoat(Boat boat)
        {
            if (!_boats.ContainsKey(boat.Registration)) // if dict DOESN'T contain this key, boat is added
            { // because dictionaries cannot contain duplicates
                _boats.Add(boat.Registration, boat);
            }
            else // if dict DOES contain this key, exception is thrown
            {
                throw new KeyTakenException($"Kan ikke oprette en båd med registrerings ID '{boat.Registration}' denne ID findes allerede\n");
            }
        }

        // this is polymorphism
        public void AddBoat(Model modelName, string nickname, string registration)
        {
            if (!_boats.ContainsKey(registration)) // if dict DOESN'T contain this key, boat is added
            { // because dictionaries cannot contain duplicates
                _boats.Add(registration, new Boat(modelName, nickname, registration));
            }
            else // if dict DOES contain this key, exception is thrown
            {
                throw new KeyTakenException($"Kan ikke oprette en båd med registrerings ID '{registration}' denne ID findes allerede\n");
            }
        }

        public Boat GetBoatByReg(string registration)
        {
            if (registration != null && _boats.ContainsKey(registration))
            { // if searched Reg isn't null, and Dict contains a Boat with the Reg, the Boat is found
                return _boats[registration];
            }
            return null; // else return nothing
        }

        public void RemoveBoat(string registration)
        {
            _boats.Remove(registration);
        }

        // Edit in case of registration ID typo or a new nickname for the boat
        public void EditBoat(string oldBoatReg, string newBoatReg, string newNickname)
        {
            if (_boats.ContainsKey(newBoatReg))
            { // if Dict already contains a Boat with the new Reg ID, throw an exception
                throw new KeyTakenException($"Kan ikke ændre bådens registrerings ID til '{newBoatReg}' denne ID findes allerede\n");
            } // else
            // _boats[oldBoatReg].Registration = newBoatReg; // updates boat info but NOT key info!!!!
            // the code below works as intended
            Boat oldBoat = _boats[oldBoatReg]; // temp Ref to Boat, gets oldBoat info
            _boats.Remove(oldBoatReg); // severs Ref to the Boat (oldRegID) in the Dict
            _boats[newBoatReg] = oldBoat; // oldBoat info placed in new spot using new Reg ID as key
            oldBoat.Registration = newBoatReg; // overwrites old Reg ID with new Reg ID in object (not key)
            oldBoat.Nickname = newNickname; // overwrites old Nickname with new Nickname
        }
        public int NumberOfModel(string modelName)
        {
            int count = 0;
            foreach (Boat boat in _boats.Values)
            {
                if (boat.Model.ModelName == modelName)
                {
                    count++;
                }
            }
            return count;
        }
        public void PrintAllBoats()
        {
            foreach (Boat boat in _boats.Values)
            {
                Console.WriteLine(boat.ToString());
            }
        }
        #endregion
    }
}
