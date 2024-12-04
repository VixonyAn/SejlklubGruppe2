using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class KeyTakenException : Exception
    {
        public KeyTakenException()
        {
        }

        public KeyTakenException(string message) : base(message)
        {
        }
    }


}
