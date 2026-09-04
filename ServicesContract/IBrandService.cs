using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IBrandService
    {
        List<Brand> GetAllBrands();
        Brand GetBrand(int id);
        void AddBrand(Brand brand);
        void UpdateBrand(Brand model);
    }
}
