using FUMiniHotelSystemClassLib.Model;
using Microsoft.EntityFrameworkCore;

namespace FUMiniHotelSystemClassLib.Daos
{
    public class BookingDao
    {
        private readonly FUMiniHotelManagementContext _context;

        private static BookingDao instance = null;
        private static readonly object instanceLock = new object();
        public static FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private BookingDao() { }

        public static BookingDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDao();
                    }
                    return instance;
                }
            }
        }
        public async Task<List<BookingDetail>> GetAllWithDetailAsync()
        {
            return await db.BookingDetails
              .AsNoTracking()
              .Include(b => b.Room)
              .Include(b => b.BookingReservation)
                  .ThenInclude(b => b.Customer)
              .ToListAsync();


        }





    }
}
