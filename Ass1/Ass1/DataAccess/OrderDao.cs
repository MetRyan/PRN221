using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDao
    {
        private static OrderDao instance = null;
        private static readonly object instanceLock = new();
        private OrderDao() { }
        public static OrderDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new OrderDao();
                    return instance;
                }
            }
        }
        FStoreContext storeContext;
        //
        IEnumerable<Order> getList() {


            try {
            return storeContext.Orders.ToList();
            } catch (Exception ex){ throw new Exception(ex.Message); }
        }
        public void Add (Order order)
        {
            try { 
            
            
            }
            catch (Exception ex) { throw new Exception(ex.Message); }


        }

    }
}
