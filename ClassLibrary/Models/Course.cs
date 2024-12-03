using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Course : ICourse
    {
        public int Id { get; set; }

        public string[,] TimeSlot {  get; set; }
            // new string[2, 2];


        public int[] AttendeeRange {  get; set; }
                                   //new int[2];

        public List<member> Attendees {  get; set; }

        public member Master {  get; set; }

        public string Description { get; set; }


        public Course() 
        {    
        }

        public Course(int id, string[,] timeSlot, int[] attendeeRange, List<member> attendees, member master, string description)
        {
            Id = id;
            TimeSlot = timeSlot;
            AttendeeRange = attendeeRange;
            Attendees = attendees;
            Master = master;
            Description = description;
        }
    }
}
