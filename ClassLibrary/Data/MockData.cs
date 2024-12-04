using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Data
{
    public class MockData
    {
        #region Instance fields
        private static MockData _theInstance;

        private Model optimistjolle;
        private Model laserjolle;


        private Dictionary<string, Model> _modelData;

        private Dictionary<string, Boat> _boatData;
        #endregion

        #region Constructors
        private MockData()
        {
            optimistjolle = new Model("Optimistjolle", "hyggelig for begyndere", 00.00, 00.00, 00.00, 00.00);
            laserjolle = new Model("Laserjolle", "enkel og let for alle aldersgrupper", 00.00, 00.00, 00.00, 00.00);

            _modelData = new Dictionary<string, Model>()
            {
            { "Optimistjolle", optimistjolle },
            { "Laserjolle", laserjolle },
            };

            _boatData = new Dictionary<string, Boat>()
            {
            { "1234", new Boat(optimistjolle, "1234") },
            { "5678", new Boat(optimistjolle, "5678") },
            { "9012", new Boat(optimistjolle, "9012") },
            { "3456", new Boat(laserjolle, "3456") }
            };
        }
        #endregion

        #region Properties
        public Dictionary<string, Model> ModelData
        {
            get { return _modelData; }
        }

        public Dictionary<string, Boat> BoatData
        {
            get { return _boatData; }
        }
        #endregion

        #region Methods

        public static MockData GetInstance()
        {
            if(_theInstance == null)
            {
                _theInstance = new MockData();
            }
            return _theInstance;
        }

        #endregion
    }
}
