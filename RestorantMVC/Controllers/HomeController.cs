using DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Models;
using System.Diagnostics;

namespace RestorantMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlDbContext dbContext;

        public HomeController(ILogger<HomeController> logger , SqlDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new LayoutViewModel { Kategoriler = dbContext.Kategoriler.ToList() };
            return View(viewModel);
        }

        public async Task<IActionResult> Menu(int? id)
        {
            var urunler =  await dbContext.Urunler.Where(a => a.KategoriID == id).ToListAsync();

            return View(urunler);
        }

        [ResponseCache(Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}