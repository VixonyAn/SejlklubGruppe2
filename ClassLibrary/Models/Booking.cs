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
        public IMember Holder => throw new NotImplementedException();

        public IBoat Bookable => throw new NotImplementedException();

        public DateTime Start => throw new NotImplementedException();

        public DateTime End => throw new NotImplementedException();

        public bool IntervalOverlap(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
