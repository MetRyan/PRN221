using FUMiniHotelSystemClassLib.Daos;
using FUMiniHotelSystemClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystemClassLib.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }
        public  Task<List<Customer>> getAll() => CustomerDAO.Instance.GetAllWithDetailAsync();
        public Customer verifiedMember(Customer customer) => CustomerDAO.Instance.verifiedUser(customer);

    }
}
