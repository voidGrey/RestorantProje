using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Models;

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
        public IActionResult Ekle(int id, int masaid)
        {

            var x = dbContext.Set<Urun>().Find(id);
            
            return RedirectToAction("Index");
        }
    }
}
