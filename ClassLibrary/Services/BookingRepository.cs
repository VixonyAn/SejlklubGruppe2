using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class BookingRepository : IBookingRepository
    {
        #region instance fields
        public List<IBooking> _internalRepo;
        #endregion

        #region constructors
        public BookingRepository()
        {
            _internalRepo = new List<IBooking>();
        }
        #endregion

        #region methods

        public void AddBooking(IBooking booking)
        {
            int currentIndex = _internalRepo.Count - 1;
            if(currentIndex<0 || _internalRepo[currentIndex].Start<booking.Start)
            {
                _internalRepo.Add(booking);
            } else
            {
                while(currentIndex>0 && _internalRepo[currentIndex-1].Start>booking.Start)
                {
                    currentIndex--;
                }
                _internalRepo.Insert(currentIndex, booking);
            }

        }

        public void AddBooking(IMember holder, IBoat bookable, DateTime start, DateTime end)
        {
            AddBooking(new Booking(holder, bookable, start, end));
        }

        public bool BoatBookedInInterval(IBoat queryBoat, DateTime start, DateTime end)
        {
            List<IBooking> matches = GetBookingsForBoat(queryBoat);
            foreach(IBooking booking in matches)
            {
                if(booking.IntervalOverlap(start, end)) return true;
            }
            return false;
        }
        /// <summary>
        /// The function takes a list of boats and checks if any of them are booked or not depending on the value of the bool isBooked.
        /// </summary>
        /// <param name="queryBoats">The boats that we are looking through</param>
        /// <param name="start">Start of the interval</param>
        /// <param name="end">End of the interval</param>
        /// <param name="isBooked">A bool that determines if we are looking for boats that are free (booked = false) or those that are booked (booked = true)</param>
        /// <returns>A list of boats containing either only those boats that were booked or thoose that were free depending on the value of isBooked</returns>
        public List<IBoat> BoatsBookedInInterval(List<IBoat> queryBoats, DateTime start, DateTime end, bool isBooked)
            //In razorpages queryBoats should probably use GetAll() from the singleton boat repo to begin with, assuming you just want to book any boat
            //Using other (Filtered) lists could make sense in for example a scenario where you only want boats of a certain model
        {
            List<IBoat> resultList = new List<IBoat>();

            foreach(IBoat boat in queryBoats)
            {
                if(isBooked = BoatBookedInInterval(boat,start, end)) resultList.Add(boat);
            }

            return resultList;
        }


        #region filtering
        public List<IBooking> GetAll()
            {
                return new List<IBooking>(_internalRepo);
            }

            public List<IBooking> GetBookingsForBoat(IBoat boat)
            {
                List<IBooking> result = new List<IBooking>();

                for (int i = 0; i < _internalRepo.Count; i++)
                {
                    if (_internalRepo[i].Bookable == boat) result.Add(_internalRepo[i]);
                }

                return result;
            }

            public List<IBooking> GetBookingsForMember(IMember member)
            {
                List<IBooking> result = new List<IBooking>();

                for(int i =0; i<_internalRepo.Count;i++)
                {
                    if (_internalRepo[i].Holder == member) result.Add(_internalRepo[i]);
                }

                return result;
            }

            public List<IBooking> GetBookingsForModel(IModel model)
            {
                List<IBooking> result = new List<IBooking>();

                for (int i = 0; i < _internalRepo.Count; i++)
                {
                    if (_internalRepo[i].Bookable.Model == model) result.Add(_internalRepo[i]);
                }

                return result;
            }

            public List<IBooking> GetBookingsForDayInterval(DateTime start, DateTime end, out bool found)//Currently is a time interval, not day interval
            {
                List<IBooking> result = new List<IBooking>();
                int searchIndex = 0;
                int startIndex = -1;
                int endIndex = -1;
                found = false;

                while(searchIndex < _internalRepo.Count && startIndex < 0) //Searches for the first instance (if any)
                                                                           //where either end or beginning of the booking
                                                                           //overlaps with either dateTime
                {
                    if (_internalRepo[searchIndex].IntervalOverlap(start, end)) startIndex = searchIndex;
                    else searchIndex++;
                }

                if(startIndex > 0) //If this is still -1, there was no bookings at all within the given days.
                {
                    searchIndex = _internalRepo.Count - 1;
                    while (searchIndex > 0 && endIndex < 0)//Searches for the last instance 
                    {
                        if (_internalRepo[searchIndex].IntervalOverlap(start, end)) endIndex = searchIndex;
                        else searchIndex--;
                    }
                    found = true;
                    result = _internalRepo.GetRange(startIndex, endIndex - startIndex + 1);
                }

                return result;
            }
            #endregion
        #endregion
    }
}
