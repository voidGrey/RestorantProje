using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Areas.Admin
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
    }
}
