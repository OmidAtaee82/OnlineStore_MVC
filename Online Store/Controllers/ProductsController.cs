using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Product;
using ServicesContract;

namespace Online_Store.Controllers
{
    public class ProductsController : Controller
    {

        protected readonly IProductService _productService;

        public ProductsController(IProductService product)
        {
            _productService = product;
        }

        [Route("/products/{id}")]
        public IActionResult Details(int id)
        {
            var product = _productService.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            var model = new ProductVM();

            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.ProductImage = product.ProductImage;
            model.Price = product.Price;
            model.Discount = product.Discount;
            model.Color = product.Color;
            model.BrandName = product.Brand?.Name;
            model.CategoryName = product.Category?.Name;

            return View(model);
        }
    }
}
