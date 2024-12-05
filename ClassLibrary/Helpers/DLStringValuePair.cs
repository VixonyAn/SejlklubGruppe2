using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers
{
    public class DLStringValuePair
    {
        #region Instance Fields
        private int _DLValue;
        private string _DLString;
        #endregion

        #region Constructors
        public DLStringValuePair(int value, string s)
        {
            _DLValue = value;
            _DLString = s;
        }
        #endregion

        #region Properties
        public int DLValue { get { return _DLValue; } }
        public string DLString { get { return _DLString; } }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"String: {_DLString}. DL-Value: {_DLValue}.";
        }
        #endregion
    }
}
