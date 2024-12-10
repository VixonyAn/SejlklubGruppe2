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
        List<IBooking> BookingsForBoat(IBoat boat);
        List<IBooking> BookingsForModel(IModel model);
        List<IBooking> BookingsForMember(IMember member);
    }
}
