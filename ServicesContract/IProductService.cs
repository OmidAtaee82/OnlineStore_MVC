using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IProductService
    {

        List<Product> GetAllProducts();
        Product GetProduct(int id);
        List<Category> GetAllCategories();
        List<Brand> GetAllBrands();
        void AddProduct(Product model);
        void UpdateProduct(Product model);

    }
}
