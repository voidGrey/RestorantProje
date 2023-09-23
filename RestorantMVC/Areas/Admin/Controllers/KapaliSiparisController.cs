using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using RestorantMVC.Extensions;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KapaliSiparisController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;
        public KapaliSiparisController(SqlDbContext dbContext, UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var sqlDbContext = dbContext.SiparisMasterlar.FirmaFilter(firmaId).Include(s => s.Masa);
            return View(await sqlDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMaster.ID == siparismaster.ID).ToList();

            List<Urun> urunler = new List<Urun>();

            foreach (var item in siparisler)
            {
                Urun clone = await dbContext.Urunler.Where(p => p.ID == item.UrunId).FirstOrDefaultAsync();

                urunler.Add(clone);
            }

            ViewBag.Urun = urunler;

            return View(siparisler);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            
            if (siparismaster == null)
            {
                return NotFound();
            }
            
            return View(siparismaster);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            dbContext.SiparisMasterlar.Remove(siparismaster);

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
