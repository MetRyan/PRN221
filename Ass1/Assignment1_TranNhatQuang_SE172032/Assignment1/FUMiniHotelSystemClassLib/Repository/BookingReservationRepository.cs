using FUMiniHotelSystemClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class BookingReservationRepository :GenericRepository<BookingReservation>
    {
        public BookingReservationRepository(FUMiniHotelManagementContext context) :base(context)
        {
        }
    }
}
