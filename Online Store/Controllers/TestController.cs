using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Online_Store.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Content("User Id : " + " " + ":" +  userId);

        }

        [AllowAnonymous]
        public IActionResult Public()
        {
            return Content("این صفحه برای عموم قابل مشاهده است . ");
        }

    }
}
