using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Boat : IBoat
    {
        // boat (grasp) is the expert on it's own issues and maintenance
        // boat includes "maintenance log" of issues
        // udover default + en ny constructor til salg opslag (ejer's kontakt/pris i Post)
        #region Properties
        public Model Model { get; set; }
        public string Nickname { get; set; }
        public string Registration { get; set; }
        //public List<IMaintenanceNote> MaintenanceNotes { get; set; } // skal hente liste og printe den med båden når man ser båden?
        #endregion

        #region Constructors
        public Boat()
        {
            
        }
        public Boat(Model model, string nickname, string registration) // Constructor takes a Model and Registration for the boat
        {
            Model = model;
            Nickname = nickname;
            Registration = registration;
        }
        #endregion

        #region Methods
        public override string ToString() // This prints the Models ToString too :>
        {
            return $"Model: {Model}\nNavn:{Nickname}\nRegistration: {Registration}\n";
        }
        #endregion
    }
}
