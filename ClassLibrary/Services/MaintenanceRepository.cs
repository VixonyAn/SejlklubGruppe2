using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        #region Instance Fields
        //private List<MaintenanceNote> _maintenanceNotes;
        private List<IMaintenanceNote> _maintenanceNotes;
        #endregion

        #region Constructors
        public MaintenanceRepository()
        {
            _maintenanceNotes = MockData.RandomNotes(5, MockData.GetInstance().MemberData.Values.ToList()); // boat dictionary is filled by mockdata
        }
        #endregion

        #region Methods
        public List<IMaintenanceNote> GetAll()
        {
            return new List<IMaintenanceNote>(_maintenanceNotes);
        }
        public void AddNote(Member member, string note, bool severeDamage)
        {
            _maintenanceNotes.Add(new MaintenanceNote(member, note, severeDamage));
        }
        public IMaintenanceNote GetNoteById(int index)
        {
            if (index > 0 && index < _maintenanceNotes.Count)
            {
                return _maintenanceNotes[index];
            }
            throw new IndexOutOfRangeException("No maintenance note exists with that Id");
        }
        public void RemoveNote(int index)
        {
            _maintenanceNotes.RemoveAt(index);
        }

        public void ResolveNote(int index)
        {
            _maintenanceNotes[index].Resolved = true;
            _maintenanceNotes[index].LastUpdated = DateTime.Now;
        }

        public void EditNote(int index, string note)
        {
            _maintenanceNotes[index].Note = note;
            _maintenanceNotes[index].LastUpdated = DateTime.Now;
        }
        public void SortNotes()
        { // last updated, damage value, damage status, create a new list?
            throw new NotImplementedException();
        }
        public void PrintAllNotes()
        {
            foreach (MaintenanceNote maintNote in _maintenanceNotes)
            {
                Console.WriteLine(maintNote.ToString());
            }
        }
        public override string ToString()
        {
            string maintLog = "\n";
            foreach (MaintenanceNote maintNote in _maintenanceNotes)
            {
                maintLog += maintNote.ToString() + "\n";
            }
            return maintLog;
        }
        #endregion
    }
}
