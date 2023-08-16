using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Controllers
{
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;

        public SiparisController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ekle(Urun urunler)
        {

            return RedirectToAction("Index");
        }
    }
}
