using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Areas.Admin.Controllers
{

    [Area("/admin")]
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {

        [Route("/admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
