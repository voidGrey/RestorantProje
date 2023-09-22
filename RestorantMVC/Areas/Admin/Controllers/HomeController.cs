using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Extensions;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<Firma> userManager;

        public HomeController(UserManager<Firma> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            await this.SetUser(userManager);
            return View();
        }
    }
}