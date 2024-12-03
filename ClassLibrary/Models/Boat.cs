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

        Model Model { get; set; }
        string Description { get; set; }
        string Registration { get; set; }
        Issue Issue { get; set; }

        string ToString();
    }
}
