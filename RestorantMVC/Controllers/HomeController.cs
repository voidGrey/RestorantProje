using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Models;
using System.Diagnostics;

namespace RestorantMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, SqlDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new LayoutViewModel { Kategoriler = dbContext.Kategoriler.ToList() };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Menu(int id)
        {
            var result = dbContext.Kategoriler.Find(id);
            return RedirectToAction("Menu", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}