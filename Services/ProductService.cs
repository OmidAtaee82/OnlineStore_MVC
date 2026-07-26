using Entity;
using Microsoft.EntityFrameworkCore;
using ServicesComtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService:IProductService
    {

        private readonly OmidOnlineStoreDB _OnlineStoreDb;

        public ProductService(OmidOnlineStoreDB OnlineStoreDb)
        {
            _OnlineStoreDb = OnlineStoreDb;
        }


        public List<Product> GetAllProducts()
        {

            return _OnlineStoreDb.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ProductImage = x.ProductImage,
                    Price = x.Price,
                    Discount = x.Discount,
                    Color = x.Color,
                    Category = x.Category,
                    Brand = x.Brand
                }).ToList();

        }


        public List<Category> GetAllCategories()
        {
            return _OnlineStoreDb.Categories.Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public List<Brand> GetAllBrands()
        {
            return _OnlineStoreDb.Brands.Select(x => new Brand
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }


        public void AddProduct(Product model)
        {
            _OnlineStoreDb.Products.Add(model);
            _OnlineStoreDb.SaveChanges();
        }
        

    }
}
