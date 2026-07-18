using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsController : Controller
    {

        [Route("/admin/products")]
        public IActionResult Products()
        {
            return View();
        }
    }
}
