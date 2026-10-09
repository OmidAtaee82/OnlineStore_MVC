using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Categories;
using Online_Store.ViewModel.CategoryPage;
using Online_Store.ViewModel.Product;
using ServicesContract;

namespace Online_Store.Controllers
{
    public class CategoriesController : Controller
    {

        protected readonly ICategoryService _categoryService;
        protected readonly IProductService _productService;

        public CategoriesController(ICategoryService category , IProductService product)
        {
            _categoryService = category;
            _productService = product;
        }

        [Route("/categories")]
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAllCategory()
                .Where(x=>x.ParentId == null)
                .Select(x=>new CategoryVM
            {
                Id = x.Id , 
                Name = x.Name , 
                CategoryImage = x.CategoryImage , 
                ParentName = x.Parent?.Name
            }).ToList();

            var model = new CategoryPageVM();
            model.Categories = categories;

            return View(model);
        }


        [Route("/category/{id}")]
        public IActionResult Category(int id)
        {
            var categories = _categoryService.GetChildCategory(id).Select(x=>new CategoryVM
            {
                Id = x.Id , 
                Name = x.Name , 
                CategoryImage = x.CategoryImage
            }).ToList();

            var products = _productService.GetProductsByCategory(id).Select(x => new ProductVM
            {
                Id = x.Id , 
                Name = x.Name , 
                Description = x.Description , 
                ProductImage = x.ProductImage , 
                Price = x.Price , 
                Discount = x.Discount , 
                Color = x.Color , 
                BrandName = x.Brand?.Name , 
                CategoryName = x.Category?.Name

            }).ToList();

            var model = new CategoryPageVM();

            model.Categories = categories;
            model.Products = products;

            return View(model);

        }

    }
}
