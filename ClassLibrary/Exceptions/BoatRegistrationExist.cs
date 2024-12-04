using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class BoatRegistrationExist : Exception
    {
        public BoatRegistrationExist()
        {
        }

        public BoatRegistrationExist(string message) : base(message)
        {
        }
    }
}
