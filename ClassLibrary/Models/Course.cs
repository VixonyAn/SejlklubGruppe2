using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Course : ICourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime[] TimeSlot = new DateTime[2];
        


        public int[] AttendeeRange {  get; set; }
                                   //new int[2];

        public List<Member> Attendees {  get; set; }

        public Member Master {  get; set; }

        public string Description { get; set; }


        public Course() 
        {    
        }

        public Course(int id,string name, DateTime startDateTime, DateTime endDateTime, int[] attendeeRange, List<Member> attendees, Member master, string description)
        {
            Id = id;
            Name = name;
            TimeSlot[0]=startDateTime;
            TimeSlot[1]=endDateTime;
            AttendeeRange = attendeeRange;
            Attendees = attendees;
            Master = master;
            Description = description;
        }
        public override string ToString()
        {
            return $"id: {Id} \n Name: {Name} \n  timeslot   from: {TimeSlot[0]}, to:{TimeSlot[1]} \n  Creator: {Master.Name} \n  Minimum Number of Attendees: {AttendeeRange[0]} ,  Max Number of Attendees: {AttendeeRange[1]}  \n  places left: {((Attendees.Count < AttendeeRange[1]) ? $"der er {AttendeeRange[1]-Attendees.Count} pladser tilbage" : $"der er ikke flere pladser {Attendees.Count} ud af {AttendeeRange[1]} \n " +$"")}";
        }
    }

}
