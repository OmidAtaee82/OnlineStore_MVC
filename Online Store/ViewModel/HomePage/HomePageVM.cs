using Online_Store.ViewModel.Brands;
using Online_Store.ViewModel.Categories;
using Online_Store.ViewModel.Product;

namespace Online_Store.ViewModel.HomePage
{
    public class HomePageVM
    {

        public List<CategoryVM> Categories { get; set; }

        public List<BrandVM> Brands { get; set; }

        public List<ProductVM> products { get; set; }

        public List<ProductVM> newProducts { get; set; }

    }
}
