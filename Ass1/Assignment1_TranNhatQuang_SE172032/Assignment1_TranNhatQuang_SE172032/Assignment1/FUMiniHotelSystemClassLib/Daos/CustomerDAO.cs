using FUMiniHotelSystemClassLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Daos
{
    public class CustomerDAO
    {
        private readonly FUMiniHotelManagementContext _context;

        public static FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new CustomerDAO();
                    return instance;
                }
            }
        }

        public async Task<List<Customer>> GetAllWithDetailAsync()
        {

            return await db.Customers
                .AsNoTracking()
                .Include(b => b.BookingReservations)
                .ToListAsync();
        }
       public  Customer verifiedUser(Customer customer)
        {

            var Customers = db.Customers.FirstOrDefault(p => p.EmailAddress == customer.EmailAddress && p.Password == customer.Password);


            if (Customers != null)
            {
                Console.WriteLine($"Found member: ");
            }
            else
            {
                Console.WriteLine("No member found with provided email and password.");
            }

            return Customers;
        }


    }
}
