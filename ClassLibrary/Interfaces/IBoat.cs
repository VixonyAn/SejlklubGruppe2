using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IBoat
    {
        Model Model { get; set; }
        string Nickname { get; set; }
        string Registration { get; set; }
        List<MaintenanceNote> MaintenanceLog { get; set; }

        string ToString();
    }
}
