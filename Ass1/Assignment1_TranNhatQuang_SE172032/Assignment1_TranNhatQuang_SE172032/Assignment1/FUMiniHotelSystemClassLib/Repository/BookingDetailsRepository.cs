using FUMiniHotelSystemClassLib.Daos;
using FUMiniHotelSystemClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class BookingDetailsRepository : GenericRepository<BookingDetail>
    {
        public BookingDetailsRepository(FUMiniHotelManagementContext context) :base (context)
        {
        }

        public  Task<List<BookingDetail>> GetAllWithDetailAsync() => BookingDao.Instance.GetAllWithDetailAsync();

    }
}
