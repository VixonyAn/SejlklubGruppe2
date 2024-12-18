﻿using ClassLibrary.Models;
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
        void AddNote(Member member, Boat boat, string note, bool severeDamage);
        List<MaintenanceNote> GetNotesByReg(string boatReg);
        MaintenanceNote GetNoteById(int maintId);
        void RemoveNote(int maintId);
        void ResolveNote(int maintId);
        void EditNote(int maintId, string note, bool severeDamage, bool resolved);
        void PrintAllNotes();
    }
}
