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

        public Model Model { get; set; }
        public string Registration { get; set; }
        public List<Issue> Issue { get; set; } // skal hente liste og printe den med båden når man ser båden?

        public Boat(Model model, string registration) // Constructor takes a Model and Registration for the boat
        {
            Model = model;
            Registration = registration;
        }

        public override string ToString() // This prints the Models ToString too :>
        {
            return $"Model: {Model}\nRegistration: {Registration}";
        }
    }
}
