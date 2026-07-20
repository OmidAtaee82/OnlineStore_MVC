using Entity;
using Microsoft.EntityFrameworkCore;
using ServicesComtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;

namespace Services
{
    public class ProductService:IProductService
    {

        private readonly OmidOnlineStoreDB _OnlineStoreDb;

        public ProductService(OmidOnlineStoreDB OnlineStoreDb)
        {
            _OnlineStoreDb = OnlineStoreDb;
        }


        public List<ProductListVM> GetAllPtoducts()
        {

            return _OnlineStoreDb.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Select(x => new ProductListVM
                {
                    Id = x.Id , 
                    Name = x.Name , 
                    Description = x.Description , 
                    ProductImage = x.ProductImage , 
                    Price = x.Price , 
                    Discount = x.Discount , 
                    Color = x.Color , 
                    BrandName = x.Brand.Name , 
                    CategoryName = x.Category.Name
                }).ToList();

        }

    }
}
