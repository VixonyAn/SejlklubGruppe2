using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ICourse
    {
        // start date and time     { [start date], [start time]      date format:dd/mm/yyyy  
        //end date and time         [end date], [end time]  }        time format: hh/mm
        //string[,] Timeslot = new string[2,2];
        // attendees range [min,max]
        //current number of attendees
        //master/teacher/creator of the course/event
        //description

        string[,] TimeSlot { get; set; }
        int[] AttendeeRange { get; set; }
        List<Member> Attendees { get; set; }
        Member Master { get; set; }
        string Description { get; set; }
    }
}
