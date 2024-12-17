using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMaintenanceNote
    { // the boat's maintenance log contains a list of issues and wether they are severe/minor, resolved/unresolved
        Member Member { get; set; }
        Boat Boat { get; set; }
        string Note { get; set; }
        int No { get; }
        DateTime TimeCreated { get; }
        DateTime LastUpdated { get; set; }
        public bool SevereDamage { get; set; }
        public bool Resolved { get; set; }

        string ToString();
    }
}
