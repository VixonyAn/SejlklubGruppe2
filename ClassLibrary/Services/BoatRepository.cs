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

namespace ClassLibrary.Services
{
    public class BoatRepository : IBoatRepository
    {
        #region Instance Fields
        private Dictionary<string, Boat> _boats; // string is Registration as key
        #endregion

        #region Constructors
        public BoatRepository()
        {
            _boats = new Dictionary<string, Boat>();
        }
        #endregion

        #region Methods
        public List<Boat> GetAll()
        {
            return _boats.Values.ToList();
        }

        public void AddBoat(Boat boat)
        {
            if (!_boats.ContainsKey(boat.Registration))
            { // because dictionaries cannot contain duplicates
                _boats.Add(boat.Registration, boat);
            }
            else
            {
                throw new KeyTakenException($"En båd med registrerings ID '{boat.Registration}' findes allerede\n");
            }
        }

        public Boat GetBoatByReg(string registration)
        {
            if (registration != null && _boats.ContainsKey(registration))
            {
                return _boats[registration];
            }
            return null;
        }

        public void RemoveBoat(string registration)
        {
            _boats.Remove(registration);
        }

        public void EditBoat(Boat newBoatInfo, Model model, string description, string registration)
        {
            Boat oldBoatInfo = GetBoatByReg(registration);
            oldBoatInfo.Model = newBoatInfo.Model;
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
