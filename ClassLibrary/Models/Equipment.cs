using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Equipment : IEquipment
    {
        #region Instance Fields
        private int _id;
        private static int _counter = 0;
        private string _description, _type;
        #endregion

        #region Properties
        public int Id { get { return _id; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        #endregion


        #region Constructor
        public Equipment(string type, string description)
        {
            _id = _counter;
            _counter++;
            _type = type;
            _description = description;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"The equipment with the id: ${Id} is a ${Type} with the description {Description}";
        }
        #endregion

    }
}
