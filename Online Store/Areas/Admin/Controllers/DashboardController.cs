using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("/admin")]

    public class DashboardController : Controller
    {

        [Route("/admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
