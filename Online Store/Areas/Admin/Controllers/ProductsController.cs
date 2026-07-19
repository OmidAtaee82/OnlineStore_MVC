using Microsoft.AspNetCore.Mvc;
using ServicesComtract;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsController : Controller
    {

        protected readonly IProductService _productService;

        public ProductsController(IProductService p)
        {
            _productService = p;
        }

        [Route("/admin/products")]
        public IActionResult Products()
        {
            var result = _productService.GetAllPtoducts();
            return View(result);
        }
    }
}
