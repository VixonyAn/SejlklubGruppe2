using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Booking : IBooking
    {
        #region properties
        public IMember Holder { get; }

        public IBoat Bookable { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public bool IsValid { get { return true; } } //Bookable.IsDamaged? Where Is Damaged would be a bool-property on a boat object.

        #endregion

        #region constructors
        public Booking(IMember holder, IBoat bookable, DateTime start, DateTime end)
        {
            Holder = holder;
            //If Boat.IsDamaged could be a bool-property that looks for any instances of serious damage on the boat
            //If there is serious damage, throw an exception here? Maybe this should be handled by the repo instead.
            Bookable = bookable;
            Start = start;
            End = end;
        }
        #endregion

        #region methods
        /// <summary>
        /// Checks if an external dateTime interval overlaps with this booking.
        /// </summary>
        /// <param name="start">The start of the interval</param>
        /// <param name="end">The end of the interval</param>
        /// <returns>True if an overlap was found. Otherwise returns false.</returns>
        public bool IntervalOverlap(DateTime start, DateTime end)
        {
            if (start >= Start && start <= End || end >= Start && end <= End) return true;
            return false;
        }

        public TimeSpan LengthOfTrip()
        {
            return End - Start; //Interesting that two DateTimes using the "-" operator returns a different datatype
                                //Makes sense, but was unknown to the author of this file at the time of writing.
        }

        #endregion
    }
}
