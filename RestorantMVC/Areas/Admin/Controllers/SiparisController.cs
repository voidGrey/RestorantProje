using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;

        public SiparisController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View(Siparisler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var masaListesi = (from item in dbContext.Masalar
                               select new SelectListItem
                               {
                                   Text = item.MasaID.ToString(),
                                   Value = item.MasaID.ToString()
                               }).ToList();
            ViewBag.Masalar = masaListesi;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SiparisMaster siparisMaster)
        {
            dbContext.SiparisMasterlar.Add(siparisMaster);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var siparis = await dbContext.SiparisMasterlar.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }

            return View(siparis);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siparis = await dbContext.SiparisMasterlar.FindAsync(id);

            siparis.IsActive = false;
            siparis.MasaId = null;

            dbContext.Update(siparis);
            await dbContext.SaveChangesAsync();

            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View("Index", Siparisler);
        }


        public async Task<IActionResult> Details(int id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMaster.MasaId == siparismaster.MasaId).ToList();

            List<Urun> urunler = new List<Urun>();

            foreach (var item in siparisler)
            {
                Urun clone = await dbContext.Urunler.Where(p=> p.ID == item.UrunId).FirstOrDefaultAsync();

                urunler.Add(clone);
            }

            ViewBag.Urun = urunler;

            return View(siparisler);
        }

        public async Task<IActionResult> Onayla(int id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            siparismaster.status = (SiparisMaster.Status)2;
            dbContext.Update(siparismaster);
            await dbContext.SaveChangesAsync();

            return View(siparismaster);
        }
    }
}