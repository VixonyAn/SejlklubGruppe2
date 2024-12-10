using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class MaintenanceNote : IMaintenanceNote
    { // the boat's maintenance log contains a list of issues and wether they are severe/minor, resolved/unresolved
        #region Instance Fields
        private int _no;
        private static int _counter = 0;
        #endregion

        #region Properties
        public Member Member { get; set; }
        public string Note { get; set; }
        public int No { get { return _no; } }
        public DateTime TimeCreated { get; }
        public DateTime LastUpdate { get; set; }
        public bool SevereDamage { get; set; }
        public bool Resolved { get; set; }
        #endregion

        #region Constructors
        public MaintenanceNote()
        {
            _counter++;
            _no = _counter;
        }

        public MaintenanceNote(Member member, string note, bool severeDamage)
        {
            _counter++;
            _no = _counter;
            Member = member; //get by name
            Note = note;
            TimeCreated = DateTime.Now;
            LastUpdate = TimeCreated;
            SevereDamage = severeDamage;
            Resolved = false;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Vedligeholdesesnotat: {Note}\nSkade: {(SevereDamage?"SERIØST":"Minimalt")} Status: {(Resolved?"Løst":"AKTUELT")}\nForfatter:{Member.Name} Dato Rapporteret: {TimeCreated} Sidst Opdateret: {LastUpdate}\n";
        }
        #endregion
    }
}
