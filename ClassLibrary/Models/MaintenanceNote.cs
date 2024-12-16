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
        public Boat Boat { get; set; }
        public string Note { get; set; }
        public int No { get { return _no; } }
        public DateTime TimeCreated { get; }
        public DateTime LastUpdated { get; set; }
        public bool SevereDamage { get; set; }
        public string SevereDamageString { get { return SevereDamage ? "SERIØST" : "Minimalt"; } }
        public bool Resolved { get; set; }
        public string ResolvedString { get { return Resolved ? "Løst" : "AKTUELT"; } }
        #endregion

        #region Constructors
        public MaintenanceNote()
        {
            _counter++;
            _no = _counter;
        }

        public MaintenanceNote(Member member, Boat boat, string note, bool severeDamage)
        {
            _counter++;
            _no = _counter;
            Member = member; //get by name
            Boat = boat; //get by reg
            Note = note;
            TimeCreated = DateTime.Now;
            LastUpdated = TimeCreated;
            SevereDamage = severeDamage;
            Resolved = false;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Vedligeholdesesnotat: {Note}\nBåd: {Boat.Registration} Skade: {SevereDamageString} Status: {ResolvedString}\nForfatter: {Member.Name} Dato Rapporteret: {TimeCreated} Sidst Opdateret: {LastUpdated}\n";
        }
        #endregion
    }
}
