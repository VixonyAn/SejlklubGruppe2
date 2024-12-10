using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class BookingRepository : IBookingRepository
    {
        public List<IBooking> _internalRepo;


        public BookingRepository()
        {
            _internalRepo = new List<IBooking>();
        }


        public List<IBooking> GetAll()
        {
            return new List<IBooking>(_internalRepo);
        }

        public List<IBooking> BookingsForBoat(IBoat boat)
        {
            List<IBooking> result = new List<IBooking>();

            for (int i = 0; i < _internalRepo.Count; i++)
            {
                if (_internalRepo[i].Bookable == boat) result.Add(_internalRepo[i]);
            }

            return result;
        }

        public List<IBooking> BookingsForMember(IMember member)
        {
            List<IBooking> result = new List<IBooking>();

            for(int i =0; i<_internalRepo.Count;i++)
            {
                if (_internalRepo[i].Holder == member) result.Add(_internalRepo[i]);
            }

            return result;
        }

        public List<IBooking> BookingsForModel(IModel model)
        {
            List<IBooking> result = new List<IBooking>();

            for (int i = 0; i < _internalRepo.Count; i++)
            {
                if (_internalRepo[i].Bookable.Model == model) result.Add(_internalRepo[i]);
            }

            return result;
        }
    }
}
