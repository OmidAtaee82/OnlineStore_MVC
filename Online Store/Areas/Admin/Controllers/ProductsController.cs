using Entity;
using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Product;
using ServicesContract;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsController : Controller
    {

        protected readonly IProductService _productService;
        protected readonly IWebHostEnvironment _env;

        public ProductsController(IProductService p , IWebHostEnvironment env)
        {
            _productService = p;
            _env = env;
        }

        [Route("/admin/products")]
        public IActionResult Products()
        {
            var product = _productService.GetAllProducts();
            var result = product.Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ProductImage = x.ProductImage,
                Price = x.Price,
                Discount = x.Discount,
                Color = x.Color,
                BrandName = x.Brand.Name,
                CategoryName = x.Category.Name
            }).ToList();

            return View(result);
        }


        [HttpGet]
        [Route("/admin/products/create")]
        public IActionResult ProductsCreate()
        {
            var model = new ProductCreateVM();
            model.Categories = _productService.GetAllCategories();
            model.Brands = _productService.GetAllBrands();

            return View(model);
        }

        [HttpPost]
        [Route("/admin/products/create")]
        public IActionResult ProductsCreate(ProductCreateVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string imgPath = "";

            if (model.ProductImage != null)
            {
                string fileName = model.ProductImage.FileName;
                string path = Path.Combine(_env.WebRootPath, "img", fileName);
                using (var path_file = new FileStream(path , FileMode.Create))
                {
                    model.ProductImage.CopyTo(path_file);
                }

                imgPath = "/img/" + fileName;

            }

            _productService.AddProduct(new Product
            {
                Name = model.Name , 
                Description = model.Description , 
                ProductImage = imgPath,
                Price = model.Price.Value , 
                Discount = model.Discount , 
                Color = model.Color , 
                BrandId = model.BrandId , 
                CategoryId = model.CategoryId , 
            });

            return RedirectToAction("Products");

        }


        [HttpGet]
        [Route("/admin/products/edit")]
        public IActionResult ProductsEdit()
        {
            return View();
        }


    }
}
