using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IBooking
    {
        //to make a booking, to have a booking, etc.


        //only get, editing a booking should create a new instance to be added and sorted.
        IMember Holder { get; }
        IBoat Bookable { get; }

        DateTime Start { get; } 
        DateTime End { get; }

        bool IntervalOverlap(DateTime start, DateTime end);

        TimeSpan LengthOfTrip();

    }
}
