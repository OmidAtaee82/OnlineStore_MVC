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


        [Route("/admin/products/{id}")]
        public IActionResult Product(int id)
        {
            var product = _productService.GetProduct(id);
            var model = new ProductVM();
            if (product != null)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.ProductImage = product.ProductImage;
                model.Price = product.Price;
                model.Discount = product.Discount;
                model.Color = product.Color;
                model.BrandName = product.Brand.Name;
                model.CategoryName = product.Category.Name;
            }
            return View(model);
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
        [Route("/admin/products/edit/{id}")]
        public IActionResult ProductsEdit(int id)
        {
            var product = _productService.GetProduct(id);

            var model = new ProductEditVM();

            if (product != null)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.CurrentImage = product.ProductImage;
                model.Price = product.Price;
                model.Discount = product.Discount;
                model.Color = product.Color;
                model.BrandId = product.BrandId;
                model.CategoryId = product.CategoryId;
                model.Categories = _productService.GetAllCategories();
                model.Brands = _productService.GetAllBrands();

            }

            return View(model);

        }

        [HttpPost]
        [Route("/admin/products/edit/{id}")]
        public IActionResult ProductsEdit(ProductEditVM productVM)
        {

            string imgPath = productVM.CurrentImage;

            if (productVM.ProductImage != null)
            {
                string fileName = productVM.ProductImage.FileName;
                string path = Path.Combine(_env.WebRootPath , "img" , fileName);
                using (var path_file = new FileStream(path , FileMode.Create))
                {
                    productVM.ProductImage.CopyTo(path_file);
                }

                imgPath = "/img/" + fileName;

            }

            var product = new Product
            {
                Id = productVM.Id,
                Name = productVM.Name,
                Description = productVM.Description,
                ProductImage = imgPath,
                Price = productVM.Price.Value,
                Discount = productVM.Discount,
                Color = productVM.Color,
                BrandId = productVM.BrandId,
                CategoryId = productVM.CategoryId
            };

            _productService.UpdateProduct(product);

            return RedirectToAction("Products");

        }


    }
}
