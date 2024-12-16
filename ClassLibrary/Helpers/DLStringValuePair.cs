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
        private string _DLString, _secondaryString;
        #endregion

        #region Constructors
        public DLStringValuePair(int value, string s)
        {
            _DLValue = value;
            _DLString = s;
        }

        public DLStringValuePair(string s1, string s2)
        {
            _DLString = s1;
            _secondaryString = s2;
            _DLValue = 0;
        }
        #endregion

        #region Properties
        public int DLValue { get { return _DLValue; } set { _DLValue = value; } }
        public string DLString { get { return _DLString; } }

        public string SecondaryString { get { return _secondaryString;} }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"String: {_DLString}. DL-Value: {_DLValue}.";
        }
        #endregion
    }
}
