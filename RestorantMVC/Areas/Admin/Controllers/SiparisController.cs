using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;

        public SiparisController(SqlDbContext dbContext , UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);
            var Siparisler = await dbContext.SiparisMasterlar.FirmaFilter(firmaId).ToListAsync();
            var siparisDetaylar = await dbContext.SiparisDetaylar.FirmaFilter(firmaId).ToListAsync();

            foreach (var sMaster in Siparisler)
            {
                foreach (var sDetay in siparisDetaylar)
                {
                    if (sMaster.ID == sDetay.SiparisMasterId)
                        sMaster.SiparisDetay.Add(sDetay);
                }
            }

            await CalculateTotalPrice(Siparisler);
            return View(Siparisler);
        }

        private async Task CalculateTotalPrice(List<SiparisMaster> Siparisler)
        {
            foreach (var master in Siparisler)
            {
                var siparisDetails = await dbContext.SiparisDetaylar.FirmaFilter(firmaId).
                Where(m=> m.SiparisMasterId == master.ID).ToListAsync();
                double? @double = 0;

                for (int i = 0; i < siparisDetails.Count; i++)
                    @double += (siparisDetails[i].Fiyat * siparisDetails[i].Adet);

                master.ToplamTutar = @double;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await this.SetUser(userManager);

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
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);
            siparisMaster.FirmaId = firmaId;

            dbContext.SiparisMasterlar.Add(siparisMaster);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.SetUser(userManager);
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
            await this.SetUser(userManager);
            var siparis = await dbContext.SiparisMasterlar.FindAsync(id);

            siparis.IsActive = false;
            siparis.MasaId = null;

            dbContext.Update(siparis);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);

            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.FirmaFilter(firmaId).Where(sd => sd.SiparisMaster.MasaId == siparismaster.MasaId).ToList();

            List<Urun> urunler = new List<Urun>();

            foreach (var item in siparisler)
            {
                Urun clone = await dbContext.Urunler.Where(p=> p.ID == item.UrunId).FirstOrDefaultAsync();

                urunler.Add(clone);
            }

            ViewBag.Urun = urunler;

            return View(siparisler);
        }

        public async Task<IActionResult> Hazırlanıyor(int id)
        {
            await this.SetUser(userManager);
            var siparisdetay = await dbContext.SiparisDetaylar.FindAsync(id);
            siparisdetay.status = (SiparisDetay.Status)3;
            dbContext.Update(siparisdetay);
            await dbContext.SaveChangesAsync();

            return View(siparisdetay);
        }

        public async Task<IActionResult> TeslimEdildi(int id)
        {
            await this.SetUser(userManager);
            var siparisdetay = await dbContext.SiparisDetaylar.FindAsync(id);
            siparisdetay.status = (SiparisDetay.Status)6;
            dbContext.Update(siparisdetay);
            await dbContext.SaveChangesAsync();

            return View(siparisdetay);
        }
    }
}