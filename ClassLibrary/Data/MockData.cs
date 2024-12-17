using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
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
        private Dictionary<string, IMember> _memberData;
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

            _memberData = new Dictionary<string, IMember>()
            {
            { "Kurt@Chainmail.kz", new Member("Kurt", "11 11 11 11", "Kurt@Chainmail.kz") },
            { "pohe@Zealand.dk", new Member("Poul", "56780", "pohe@Zealand.dk") },
            { "CHHE@Zealand.dk", new Member("Charlotte", "72010", "CHHE@Zealand.dk") },
            { "ValdeM@OldMail.dk", new Member("Valdemar Den Store", "10 10 10 10", "ValdeM@OldMail.dk") },
            { "HrOlsen@Mail.dk", new Member("Egon Olsen", "72 55 65 00", "HrOlsen@Mail.dk") },
            { "Yvonne@Mail.dk", new Member("Yvonne", "72 55 65 00", "Yvonne@Mail.dk") },

            { "andenEgon@Egon.Egon", new Member("Egon", "88 88 88 88", "andenEgon@Egon.Egon") },
            { "Egon@Egon.Egon", new Member("Egon", "88 88 88 88", "Egon@Egon.Egon") },

            { "Kublai@yahoo.dk", new Member("Kublai Khan", "10 10 10 10", "Kublai@yahoo.dk") },
            { "Ejgild@yahoo.dk", new Member("Ejgild", "14 14 14 14", "Ejgild@yahoo.dk") },
            { "Ulla@Chainmail.kz", new Member("Ulla", "11 10 11 10", "Ulla@Chainmail.kz") },
            { "Støj@xenofobi.DK", new Member("Støjberg", "10 13 10 11", "Støj@xenofobi.DK") },
            { "Vaks@Redaktion.bl", new Member("Viggo", "13 13 13 13", "Vaks@Redaktion.bl") },
            { "FrkJanne@Redaktion.bl", new Member("Janne", "13 13 13 11", "FrkJanne@Redaktion.bl") },
            { "Kaos@ministermail.dk", new Member("Stauning", "00 00 00 01", "Kaos@ministermail.dk") }
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

        public Dictionary<string, IMember> MemberData
        {
            get { return _memberData; }
        }
        #endregion

        #region Methods
        public static MockData GetInstance()
        {
            if(_theInstance == null)
            {
                _theInstance = new MockData();
                _theInstance.PopulateBoats();
            }
            return _theInstance;
        }

        private void PopulateBoats()
        {

            _boatData = new Dictionary<string, Boat>()
            {
            { "1234", new Boat(optimistjolle, "Ahoy", "1234") },
            { "5678", new Boat(optimistjolle, "Ship'n", "5678") },
            { "9012", new Boat(optimistjolle, "Rover", "9012") },
            { "3456", new Boat(laserjolle, "Tintin", "3456") }
            };
        }

        public static List<MaintenanceNote> RandomNotes(int maxNotes, List<IMember> memberData, List<Boat> boatData)
        {
            List<string> _maintenanceNoteOptions = new List<string>()
            {
                "Meget store igler",
                "Loch Ness",
                "Læk",
                "Båd halveret",
                "Stor læk",
                "Hva'ba?",
                "Bom væltet",
                "Sejl væk ?!?!",
                "aaaaaaa",
            };

        List<MaintenanceNote> result = new List<MaintenanceNote>();

            Random random = new Random();
            int numberOfIssues = random.Next(maxNotes+1);
            bool pristine = false; // (random.Next(3) < 2);
            List<Member> members = memberData.Cast<Member>().ToList();
            List<Boat> boats = boatData.ToList();

            if (!pristine)
            {
                for(int i = 0; i<numberOfIssues; i++)
                {
                    result.Add(new MaintenanceNote(members[(random.Next(members.Count))], boats[(random.Next(boats.Count))], _maintenanceNoteOptions[(random.Next(_maintenanceNoteOptions.Count))], (random.Next(2) < 1)));
                }
            }
            return result;
        }
        #endregion
    }
}
