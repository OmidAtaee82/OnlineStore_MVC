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


        public List<Product> GetAllPtoducts()
        {

            return _OnlineStoreDb.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Select(x => new Product
                {
                    Id = x.Id , 
                    Name = x.Name , 
                    Description = x.Description , 
                    ProductImage = x.ProductImage , 
                    Price = x.Price , 
                    Discount = x.Discount , 
                    Color = x.Color , 
                    Brand = x.Brand , 
                    Category = x.Category
                }).ToList();

            //var result = _OnlineStoreDb.Products.Select(x=>new Product
            //{
            //    Id = x.Id , 
            //    Name = x.Name , 
            //    Description = x.Description , 
            //    ProductImage = x.ProductImage , 
            //    Price = x.Price , 
            //    Discount = x.Discount , 
            //    Color = x.Color , 
            //    BrandId = x.BrandId , 
            //    CategoryId = x.CategoryId
            //}).ToList();

        }

    }
}
