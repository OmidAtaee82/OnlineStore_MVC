using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Product
{
    public class ProductListVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string? Color { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }


    }
}
