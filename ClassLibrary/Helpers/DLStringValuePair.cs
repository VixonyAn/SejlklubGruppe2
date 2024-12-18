using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers
{
    public class DLStringValuePair<T>
    {
        #region Instance Fields
        private int _DLValue;
        private string _DLString;
        private T _arbitraryValue;

        #endregion

        #region Constructors
        public DLStringValuePair(int value, string s)
        {
            _DLValue = value;
            _DLString = s;
        }

        public DLStringValuePair(string s, T arbitraryValue)
        {
            _DLString = s;
            _arbitraryValue = arbitraryValue;
            _DLValue = 0;
        }
        #endregion

        #region Properties
        public int DLValue { get { return _DLValue; } set { _DLValue = value; } }
        public string DLString { get { return _DLString; } }

        public T Data { get { return _arbitraryValue; } }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"String: {_DLString}. DL-Value: {_DLValue}. {((_arbitraryValue == null)? "" : "Secondary data: " + _arbitraryValue.ToString())}";
        }


        #endregion
    }
}
