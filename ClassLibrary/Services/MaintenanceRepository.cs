﻿using ClassLibrary.Data;
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
        private List<MaintenanceNote> _maintenanceNotes;
        #endregion

        #region Constructors
        public MaintenanceRepository()
        {
            //_maintenanceNotes = MockData.GetInstance().MaintenanceData; // boat dictionary is filled by mockdata
        }
        #endregion

        #region Methods
        public List<MaintenanceNote> GetAll()
        {
            return new List<MaintenanceNote>(_maintenanceNotes);
        }
        public void AddNote(Member member, string note, bool severeDamage)
        {
            _maintenanceNotes.Add(new MaintenanceNote(member, note, severeDamage));
        }
        public MaintenanceNote GetNoteById(int id)
        {
            throw new NotImplementedException();
        }
        public void RemoveNote(Member member, int noteId)
        {
            throw new NotImplementedException();
        }

        public void ResolveNote(int index)
        {
            _maintenanceNotes[index].Resolved = true;
        }

        public void EditNote(int index, string note)
        {
            _maintenanceNotes[index].Note = note;
            _maintenanceNotes[index].LastUpdate = DateTime.Now;
        }
        public void SortNotes()
        { // last updated, damage value, damage status
            throw new NotImplementedException();
        }
        public void PrintAllNotes()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}