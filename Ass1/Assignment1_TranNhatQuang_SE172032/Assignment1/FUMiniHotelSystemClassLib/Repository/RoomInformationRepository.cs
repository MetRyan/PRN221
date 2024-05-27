using FUMiniHotelSystemClassLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class RoomInformationRepository : GenericRepository<RoomInformation>
    {
        public RoomInformationRepository(FUMiniHotelManagementContext context) :base (context)
        {
        }
        public async Task<List<RoomInformation>> GetAllWithDetailAsync()
        {
            return await _context.RoomInformations
                .AsNoTracking()
                .Include(b => b.RoomType)
                .ToListAsync();
        }
    }
}
