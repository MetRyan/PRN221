using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void add(Product product) => ProductDao.Instance.addProduct(product);

        public Product getByID(int id) => ProductDao.Instance.getProductByID(id);

        public IEnumerable<Product> getList()  => ProductDao.Instance.getProduct(); 

        public void update(Product product) => ProductDao.Instance.updateProduct(product);      
    }
}
