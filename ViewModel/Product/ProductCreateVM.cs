using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ViewModel.Product
{
    public class ProductCreateVM
    {

        [Required(ErrorMessage = "نام محصول الزامی است")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "عکس محصول الزامی است")]
        public IFormFile ProductImage { get; set; }

        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "قیمت محصول الزامی است")]
        [Range(0 , double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(0 , 100)]
        public int? Discount { get; set; }

        public string? Color { get; set; }

        [Range(1 , int.MaxValue , ErrorMessage = "انتخاب دسته بندی محصول الزامی است")]
        public int CategoryId { get; set; }

        [Range(1 , int.MaxValue , ErrorMessage = "انتخاب برند محصول الزامی است")]
        public int BrandId { get; set; }
        public List<Category> Categories { get; set; }

        public List<Brand> Brands { get; set; }

    }
}
