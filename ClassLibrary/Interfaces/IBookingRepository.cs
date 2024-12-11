using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IBookingRepository
    {

        void AddBooking(IBooking booking);
        void AddBooking(IMember holder, IBoat bookable, DateTime start, DateTime end);

        List<IBooking> GetAll();
        List<IBooking> GetBookingsForBoat(IBoat boat);
        List<IBooking> GetBookingsForModel(IModel model);
        List<IBooking> GetBookingsForMember(IMember member);
        List<IBooking> GetBookingsForDayInterval(DateTime start, DateTime end, out bool found);
    }
}
