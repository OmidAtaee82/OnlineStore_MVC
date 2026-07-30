using Entity;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.ViewModel.Product
{
    public class ProductEditVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "نام محصول الزامی است")]
        [StringLength(70)]
        public string Name { get; set; }

        [MaxLength(600)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "عکس محصول الزامی است")]
        public IFormFile ProductImage { get; set; }

        public string? CurrentImage { get; set; }

        [Required(ErrorMessage = "قیمت محصول الزامی است")]
        [Range(1, double.MaxValue)]
        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public string? Color { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "انتخاب برند محصول الزامی است")]
        public int BrandId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "انتخاب دسته بندی محصول الزامی است")]
        public int CategoryId { get; set; }

        public List<Brand> Brands { get; set; } = new();

        public List<Category> Categories { get; set; } = new();

    }
}
