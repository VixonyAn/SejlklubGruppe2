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

        List<MaintenanceNote> GetAll();
        void AddNote(Member member, string note, bool severeDamage);
        MaintenanceNote GetNoteById(int id);
        void RemoveNote(Member member, int noteId);
        void ResolveNote(bool resolved);
        void EditNote(Member member, string note);
        void SortNotes();
        void PrintAllNotes();
    }
}
