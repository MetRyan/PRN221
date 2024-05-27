using FUMiniHotelSystemClassLib.Model;
using FUMiniHotelSystemClassLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.IRepository
{
    public interface IUnitOfWork
    {
        CustomerRepository GetCustomersRepository();
        RoomInformationRepository GetRoomInformationRepository();
        RoomTypeRepository GetRoomTypesRepository();
        BookingReservationRepository GetBookingReservationsRepository();
        BookingDetailsRepository GetBookingDetailsRepository();
        Task<int> SaveChangesAsync();
    }
}
