using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Controllers
{
    public class CategoriesController : Controller
    {

        [Route("/categories")]
        public IActionResult Categories()
        {
            return View();
        }
    }
}
