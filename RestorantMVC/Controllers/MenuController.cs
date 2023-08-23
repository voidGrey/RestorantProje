using DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly SqlDbContext dbContext;

        public MenuController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async  Task<IActionResult> Kategori( int? id)
        {
            var urunler = dbContext.Urunler.Where(a => a.KategoriID == id).ToList();
            return View();
        }
    }
}
