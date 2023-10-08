using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestorantMVC.Extensions;
using RestorantMVC.Hubs;
using System.Runtime.InteropServices;

namespace RestorantMVC.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly IHubContext<SiparisHub> hubContext;
        private string decryptValue;

        public SiparisController(SqlDbContext context, IHubContext<SiparisHub> hubContext)
        {
            dbContext = context;
            this.hubContext = hubContext;
        }

        /// <summary>
        /// Siparişlerin listesini görüntülemek için kullanılan işlem.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            await this.ViewBagSettings(dbContext);

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            //MasaID'nin siparişleri listelenir.
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);

            var siparisMasterlar = dbContext.SiparisMasterlar.FirmaFilter(firmaId).Where(s => s.MasaId == masaid);
            var siparisMaster = siparisMasterlar.FirstOrDefault();
            //toplam tutarı menu controllerdan çekemediğim için buraya aldım
            siparisMaster.ToplamTutar = dbContext.SiparisDetaylar.Where(v => v.SiparisMasterId == siparisMaster.ID).Sum(x => x.Fiyat * x.Adet);
            await dbContext.SaveChangesAsync();
            var siparisDetaylari = dbContext.SiparisDetaylar.FirmaFilter(firmaId).Where(d => d.SiparisMasterId == siparisMaster.ID).ToList();

            // Urun'lerin isimleri null dönmesin diye ürünlerin atamasını DB'den atıyorum.
            foreach (var item in siparisDetaylari)
                if (item.Urun == null)
                    item.Urun = await dbContext.Urunler.FindAsync(item.UrunId);

            return View(siparisDetaylari);
        }

        /// <summary>
        /// Belirli bir siparişin detaylarını görüntülemek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Sipariş detayının kimliği</param>
        public async Task<IActionResult> Details(int? id)
        {
            await this.ViewBagSettings(dbContext);

            if (id == null || dbContext.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await dbContext.SiparisDetaylar
            .Include(s => s.SiparisMaster)
            .Include(s => s.Urun)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (siparisDetay == null)
            {
                return NotFound();
            }

            return View(siparisDetay);
        }

        /// <summary>
        /// Yeni bir sipariş detayı oluşturmak için kullanılan işlem.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            await this.ViewBagSettings(dbContext);

            ViewData["SiparisMasterId"] = new SelectList(dbContext.SiparisMasterlar , "ID" , "ID");
            ViewData["UrunId"] = new SelectList(dbContext.Urunler , "ID" , "UrunAciklama");
            return View();
        }

        /// <summary>
        /// Yeni bir sipariş detayı oluşturmak için kullanılan POST işlemi.
        /// </summary>
        /// <param name="siparisDetay">Oluşturulan sipariş detayı</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiparisMasterId,UrunId,Adet,Fiyat,ID,CreateTime,UpdateTime")] SiparisDetay siparisDetay)
        {
            await this.ViewBagSettings(dbContext);

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            siparisDetay.FirmaId = firmaId;

            if (ModelState.IsValid)
            {
                dbContext.Add(siparisDetay);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiparisMasterId"] = new SelectList(dbContext.SiparisMasterlar , "ID" , "ID" , siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(dbContext.Urunler , "ID" , "UrunAciklama" , siparisDetay.UrunId);
            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını düzenlemek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Düzenlenecek sipariş detayının kimliği</param>
        public async Task<IActionResult> Edit(int? id)
        {
            await this.ViewBagSettings(dbContext);

            if (id == null || dbContext.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await dbContext.SiparisDetaylar.FindAsync(id);
            if (siparisDetay == null)
            {
                return NotFound();
            }
            ViewData["SiparisMasterId"] = new SelectList(dbContext.SiparisMasterlar , "ID" , "ID" , siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(dbContext.Urunler , "ID" , "UrunAciklama" , siparisDetay.UrunId);

            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını düzenlemek için kullanılan POST işlemi.
        /// </summary>
        /// <param name="id">Düzenlenecek sipariş detayının kimliği</param>
        /// <param name="siparisDetay">Düzenlenen sipariş detayı</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("SiparisMasterId,UrunId,Adet,Fiyat,ID,CreateTime,UpdateTime")] SiparisDetay siparisDetay)
        {
            await this.ViewBagSettings(dbContext);

            if (id != siparisDetay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(siparisDetay);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparisDetayExists(siparisDetay.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiparisMasterId"] = new SelectList(dbContext.SiparisMasterlar , "ID" , "ID" , siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(dbContext.Urunler , "ID" , "UrunAciklama" , siparisDetay.UrunId);
            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını silmek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Silinecek sipariş detayının kimliği</param>
        public async Task<IActionResult> Delete(int? id)
        {
            await this.ViewBagSettings(dbContext);

            if (id == null || dbContext.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await dbContext.SiparisDetaylar
            .Include(s => s.SiparisMaster)
            .Include(s => s.Urun)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (siparisDetay == null)
            {
                return NotFound();
            }

            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını silmek için kullanılan POST işlemi.
        /// </summary>
        /// <param name="id">Silinecek sipariş detayının kimliği</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.ViewBagSettings(dbContext);

            if (dbContext.SiparisDetaylar == null)
            {
                return Problem("Entity set 'SqlDbContext.SiparisDetaylar'  is null.");
            }
            var siparisDetay = await dbContext.SiparisDetaylar.FindAsync(id);
            if (siparisDetay != null)
            {
                dbContext.SiparisDetaylar.Remove(siparisDetay);
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisDetayExists(int id)
        {
            return (dbContext.SiparisDetaylar?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Onayla(int id)
        {
            await this.ViewBagSettings(dbContext);

            var siparisdetay = await dbContext.SiparisDetaylar.FindAsync(id);
            siparisdetay.status = (SiparisDetay.Status)2;
            dbContext.Update(siparisdetay);

            await hubContext.Clients.All.SendAsync("YeniSiparisGeldi" , 1);
            await dbContext.SaveChangesAsync();

            return View(siparisdetay);
        }

    }
}