using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMaintenanceRepository
    { // sorting system for two lists, resolved and unresolved

        List<IMaintenanceNote> GetAll();
        void AddNote(Member member, string note, bool severeDamage);
        IMaintenanceNote GetNoteById(int index);
        void RemoveNote(int index);
        void ResolveNote(int index);
        void EditNote(int index, string note);
        void SortNotes();
        void PrintAllNotes();
    }
}
