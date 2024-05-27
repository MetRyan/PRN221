using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FUMiniHotelManagementContext _context;
        public BookingDetailsRepository _bookingDetails;
        public BookingReservationRepository _bookingReservations;
        public CustomerRepository _customers;
        public RoomInformationRepository _roomInformations;
        public RoomTypeRepository _roomTypes;

        public UnitOfWork(FUMiniHotelManagementContext context)
        {
            _context = context;
            _bookingDetails = new BookingDetailsRepository(context);
            _bookingReservations = new BookingReservationRepository(context);
            _customers = new CustomerRepository(context);
            _roomInformations = new RoomInformationRepository(context);
            _roomTypes = new RoomTypeRepository(context);
        }
        public CustomerRepository GetCustomersRepository()
        {
            return _customers;
        }
        public RoomInformationRepository GetRoomInformationRepository()
        {
            return _roomInformations;
        }
        public RoomTypeRepository GetRoomTypesRepository()
        {
            return _roomTypes;
        }
        public BookingReservationRepository GetBookingReservationsRepository()
        {
            return _bookingReservations;
        }
        public BookingDetailsRepository GetBookingDetailsRepository()
        {
            return _bookingDetails;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
