﻿using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        #region Instance Fields
        private List<MaintenanceNote> _maintenanceNotes;
        #endregion

        #region Constructors
        public MaintenanceRepository()
        {
            // populates the internal list
            _maintenanceNotes = new List<MaintenanceNote>();

            // templist can be displayed through the console app with the boats
            List<MaintenanceNote> tempList = MockData.RandomNotes(10, MockData.GetInstance().MemberData.Values.ToList(), MockData.GetInstance().BoatData.Values.ToList()); // maintenance list is filled by mockdata
            foreach (MaintenanceNote maintNote in tempList)
            {
                AddNote(maintNote.Member, maintNote.Boat, maintNote.Note, maintNote.SevereDamage);
            }
            //_maintenanceNotes = MockData.RandomNotes(10, MockData.GetInstance().MemberData.Values.ToList(), MockData.GetInstance().BoatData.Values.ToList()); // maintenance list is filled by mockdata
        }
        #endregion

        #region Methods
        public List<MaintenanceNote> GetAll()
        {
            return new List<MaintenanceNote>(_maintenanceNotes);
        }

        public void AddNote(Member member, Boat boat, string note, bool severeDamage)
        {
            // first two lines allow the boat's list to be updated
            MaintenanceNote tempNote = new MaintenanceNote(member, boat, note, severeDamage);
            boat.MaintenanceLog.Add(tempNote);
            // last line updates the internal list
            _maintenanceNotes.Add(tempNote);
            //_maintenanceNotes.Add(new MaintenanceNote(member, boat, note, severeDamage));
        }

        public List<MaintenanceNote> GetNotesByReg(string boatReg)
        { // retrieve maintenanceNotes to a list if the note has the same boat registration
            List<MaintenanceNote> regNoteList = new List<MaintenanceNote>();
            foreach (MaintenanceNote maintNote in _maintenanceNotes)
            {
                if (maintNote.Boat.Registration == boatReg)
                {
                    regNoteList.Add(maintNote);
                }
            }
            return regNoteList;
        }
        public MaintenanceNote GetNoteById(int maintId)
        { // checks the entire list until a note with the same ID is found, or returns null
            foreach (MaintenanceNote maintNote in _maintenanceNotes)
            {
                if (maintId == maintNote.No)
                {
                    return maintNote;
                }
            }
            return null;
        }

        public void RemoveNote(int maintId)
        {
            // first two lines allow the boat's list to be updated
            MaintenanceNote tempNote = GetNoteById(maintId);
            tempNote.Boat.MaintenanceLog.Remove(tempNote);
            // last line updates the internal list
            _maintenanceNotes.Remove(tempNote);
            //_maintenanceNotes.Remove(GetNoteById(maintId));
        }

        public void ResolveNote(int maintId)
        { // overrides resolved status and LastUpdated
            GetNoteById(maintId).Resolved = true;
            GetNoteById(maintId).LastUpdated = DateTime.Now;
        }

        public void EditNote(int maintId, string note, bool severeDamage, bool resolved)
        { // overrides Note, damage status and LastUpdated
            GetNoteById(maintId).Note = note;
            GetNoteById(maintId).SevereDamage = severeDamage;
            GetNoteById(maintId).Resolved = resolved;
            GetNoteById(maintId).LastUpdated = DateTime.Now;
        }
        public void PrintAllNotes()
        { // for each note in the list, print notes ToString method
            foreach (MaintenanceNote maintNote in _maintenanceNotes)
            {
                Console.WriteLine(maintNote.ToString());
            }
        }
        public override string ToString()
        { // creates a local string and adds each note from the list to it then returns the string
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
