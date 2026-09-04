using Entity;
using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BrandService:IBrandService
    {

        protected readonly OmidOnlineStoreDB _OnlieStoreDb;

        public BrandService(OmidOnlineStoreDB OnliStoreDb)
        {
            _OnlieStoreDb = OnliStoreDb;
        }


        public List<Brand> GetAllBrands()
        {

            var brands = _OnlieStoreDb.Brands.Select(x => new Brand
            {
                Id = x.Id , 
                Name = x.Name , 
                BrandImage = x.BrandImage
            }).ToList();

            return brands;

        }


        public Brand GetBrand(int id)
        {
            var brand = _OnlieStoreDb.Brands.FirstOrDefault(x=>x.Id == id);

            if(brand == null)
            {
                return null;
            }

            return brand;

        }

        public void AddBrand(Brand brand)
        {
            _OnlieStoreDb.Brands.Add(brand);
            _OnlieStoreDb.SaveChanges();
        }

        public void UpdateBrand(Brand model)
        {

            var brand = _OnlieStoreDb.Brands.FirstOrDefault(x=>x.Id == model.Id);

            if(brand != null)
            {
                brand.Id = model.Id;
                brand.Name = model.Name;
                brand.BrandImage = model.BrandImage;
            }

            _OnlieStoreDb.SaveChanges();

        }

    }
}
