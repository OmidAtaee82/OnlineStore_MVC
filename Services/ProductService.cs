using Entity;
using Microsoft.EntityFrameworkCore;
using ServicesContract;
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


        public Product GetProduct(int id)
        {
            var product = _OnlineStoreDb.Products
                .Include(x=>x.Category)
                .Include(x=>x.Brand)
                .FirstOrDefault(x=>x.Id == id);
            return product;
        }


        public void AddProduct(Product model)
        {
            _OnlineStoreDb.Products.Add(model);
            _OnlineStoreDb.SaveChanges();
        }


        public void UpdateProduct(Product model)
        {
            var product = _OnlineStoreDb.Products.FirstOrDefault(x => x.Id == model.Id);

            if(product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.ProductImage = model.ProductImage;
                product.Price = model.Price;
                product.Discount = model.Discount;
                product.Color = model.Color;
                product.CategoryId = model.CategoryId;
                product.BrandId = model.BrandId;
            }

            _OnlineStoreDb.SaveChanges();

        }


        public void DeleteProduct(int id)
        {
            var product = _OnlineStoreDb.Products.FirstOrDefault(x=>x.Id == id);

            if (product != null)
            {
                _OnlineStoreDb.Products.Remove(product);
            }

            _OnlineStoreDb.SaveChanges();

        }
        

    }
}
