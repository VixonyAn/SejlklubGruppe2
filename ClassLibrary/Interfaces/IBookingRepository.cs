using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IBookingRepository
    {

        List<IBooking> GetAll();
        List<IBooking> GetBookingsForBoat(IBoat boat);
        List<IBooking> GetBookingsForModel(IModel model);
        List<IBooking> GetBookingsForMember(IMember member);
        List<IBooking> GetBookingsFromDayInterval(DateTime start, DateTime end);
    }
}
