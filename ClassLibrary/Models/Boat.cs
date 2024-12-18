﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Data;
using ClassLibrary.Interfaces;
using ClassLibrary.Services;

namespace ClassLibrary.Models
{
    public class Boat : IBoat
    {
        // boat (grasp) is the expert on it's own issues and maintenance
        // boat includes "maintenance log" of issues
        // udover default + en ny constructor til salg opslag (ejer's kontakt/pris i Post)
        #region Properties
        public Model Model { get; set; }
        public string Nickname { get; set; }
        public string Registration { get; set; }
        public List<IMaintenanceNote> MaintenanceLog { get; set; }
        // skal hente maintenance notes og printe den med båden når man ser båden?
        #endregion

        #region Constructors
        public Boat()
        {
            MaintenanceLog = new List<IMaintenanceNote>();
        }
        public Boat(Model model, string nickname, string registration) // Constructor takes a Model and Registration for the boat
        {
            Model = model;
            Nickname = nickname;
            Registration = registration;
            MaintenanceLog = new List<IMaintenanceNote>();
        }
        #endregion

        #region Methods
        public override string ToString() // This prints the Models ToString too :>
        {
            string maintLog = "";
            foreach (MaintenanceNote maintNote in MaintenanceLog)
            {
                maintLog += maintNote.ToString() + "\n";
            }
            return $"Model: {Model.ModelName}\nNavn: {Nickname}\nRegistration: {Registration}\nMaintenance Log:\n\n{maintLog}";
        } // maintlog kan printes sammen med båden
        #endregion
    }
}
