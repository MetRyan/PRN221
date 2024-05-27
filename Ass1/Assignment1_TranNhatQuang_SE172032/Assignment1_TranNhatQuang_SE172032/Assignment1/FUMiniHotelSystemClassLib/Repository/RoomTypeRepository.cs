using FUMiniHotelSystemClassLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class RoomTypeRepository :GenericRepository<RoomType> 
    {
        public RoomTypeRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }
        public async Task<List<RoomInformation>> GetAllWithDetailAsync()
        {
            return await _context.RoomInformations
                .AsNoTracking()
                .Include(b => b.RoomType)
                .Include(b => b.BookingDetails)
                .ToListAsync();
        }
    }
}
