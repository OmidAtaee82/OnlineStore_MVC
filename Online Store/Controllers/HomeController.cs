using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
