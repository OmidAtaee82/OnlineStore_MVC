using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Brands;
using Online_Store.ViewModel.Categories;
using Online_Store.ViewModel.HomePage;
using Online_Store.ViewModel.Product;
using ServicesContract;

namespace Online_Store.Controllers
{
    public class HomeController : Controller
    {

        protected readonly ICategoryService _categoryService;
        protected readonly IBrandService _brandservice;
        protected readonly IProductService _productService;

        public HomeController(ICategoryService category , IBrandService brand , IProductService product)
        {
            _categoryService = category;
            _brandservice = brand;
            _productService = product;
        }

        [Route("/")]
        public IActionResult Index()
        {

            var category = _categoryService.GetMainCategory().Select(x=>new CategoryVM
            {
                Id = x.Id , 
                Name = x.Name , 
                CategoryImage = x.CategoryImage , 
            }).ToList();

            var brand = _brandservice.GetAllBrands().Select(x => new BrandVM
            {
                Name = x.Name,
                BrandImage = x.BrandImage,
            }).ToList();

            var amazingProduct = _productService.GetAmazingProduct().Select(x=>new ProductVM
            {
                Name = x.Name,
                Description = x.Description , 
                ProductImage = x.ProductImage , 
                Price = x.Price , 
                Discount = x.Discount , 
                Color = x.Color , 
                BrandName = x.Brand?.Name , 
                CategoryName = x.Category?.Name
            }).ToList();


            var newProduct = _productService.GetNewProduct().Select(x=>new ProductVM
            {
                Name = x.Name , 
                Description = x.Description , 
                ProductImage = x.ProductImage , 
                Price = x.Price , 
                Discount = x.Discount , 
                Color = x.Color , 
                BrandName = x.Brand?.Name , 
                CategoryName = x.Category?.Name
            }).ToList();

            var model = new HomePageVM();
            model.Categories = category;
            model.Brands = brand;
            model.products = amazingProduct;
            model.newProducts = newProduct;

            return View(model);

        }
    }
}
