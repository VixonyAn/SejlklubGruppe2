using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMember
    {

        string Name { get; set;}
        string Email { get; set; }
        string Phone { get; set; }

        string ToString();
    }
}
