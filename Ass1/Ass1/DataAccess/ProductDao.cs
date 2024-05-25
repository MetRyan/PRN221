using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDao
    {
        private static ProductDao instance = null;
        private static readonly object instanceLock = new();
        FStoreContext storeContext;
        private ProductDao() {
            storeContext = new FStoreContext(); // Khởi tạo FStoreContext

        }

        public static ProductDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new ProductDao();
                    return instance;
                }
            }
        }

        public IEnumerable<Product> getProduct()
        {

            try
            {
               return  storeContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
       public void addProduct(Product product)
        {

            try {
                storeContext.Attach(product);
                storeContext.SaveChanges();
            
            } catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public void updateProduct(Product product)
        {

            try
            {
                storeContext.Update(product);
                storeContext.SaveChanges();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public Product getProductByID(int id)
        {
            try {
                Product products = storeContext.Products.First(p => p.ProductId == id);

                return products;
            
            }catch (Exception ex) {
                throw new Exception(ex.Message);
                    }
        
        }



    }
}
