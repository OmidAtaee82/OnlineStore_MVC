using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;

namespace ServicesComtract
{
    public interface IProductService
    {

        List<ProductListVM> GetAllPtoducts();

    }
}
