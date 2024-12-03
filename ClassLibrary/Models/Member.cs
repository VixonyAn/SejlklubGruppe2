using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Member : IMember
    {
        #region Instance fields

        #endregion

        #region Constructors

        #endregion

        #region Properties
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Clubmember: {Name}. Phone: {Phone}. Email: {Email}";
        }

        #endregion

    }
}
