using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    /// <summary>
    /// Sipariş işlemlerini yönetmek için kullanılan Controller sınıfı.
    /// </summary>
    public class SiparisController : Controller
    {
        private readonly SqlDbContext _context;

        public SiparisController(SqlDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Siparişlerin listesini görüntülemek için kullanılan işlem.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            //MasaID'nin siparişleri listelenir.
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            var siparisMasterlar = _context.SiparisMasterlar.Where(s => s.MasaId == masaid);
            var siparisMaster = siparisMasterlar.FirstOrDefault();
            var siparisDetaylari = _context.SiparisDetaylar.Where(d => d.SiparisMasterId == siparisMaster.ID).ToList();

            // Urun'lerin isimleri null dönmesin diye ürünlerin atamasını DB'den atıyorum.
            foreach (var item in siparisDetaylari)
                if (item.Urun == null)
                    item.Urun = _context.Urunler.Find(item.UrunId);

            return View(siparisDetaylari);
        }

        /// <summary>
        /// Belirli bir siparişin detaylarını görüntülemek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Sipariş detayının kimliği</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await _context.SiparisDetaylar
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
        public IActionResult Create()
        {
            ViewData["SiparisMasterId"] = new SelectList(_context.SiparisMasterlar, "ID", "ID");
            ViewData["UrunId"] = new SelectList(_context.Urunler, "ID", "UrunAciklama");
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
            if (ModelState.IsValid)
            {
                _context.Add(siparisDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiparisMasterId"] = new SelectList(_context.SiparisMasterlar, "ID", "ID", siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "ID", "UrunAciklama", siparisDetay.UrunId);
            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını düzenlemek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Düzenlenecek sipariş detayının kimliği</param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await _context.SiparisDetaylar.FindAsync(id);
            if (siparisDetay == null)
            {
                return NotFound();
            }
            ViewData["SiparisMasterId"] = new SelectList(_context.SiparisMasterlar, "ID", "ID", siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "ID", "UrunAciklama", siparisDetay.UrunId);
            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını düzenlemek için kullanılan POST işlemi.
        /// </summary>
        /// <param name="id">Düzenlenecek sipariş detayının kimliği</param>
        /// <param name="siparisDetay">Düzenlenen sipariş detayı</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiparisMasterId,UrunId,Adet,Fiyat,ID,CreateTime,UpdateTime")] SiparisDetay siparisDetay)
        {
            if (id != siparisDetay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparisDetay);
                    await _context.SaveChangesAsync();
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
            ViewData["SiparisMasterId"] = new SelectList(_context.SiparisMasterlar, "ID", "ID", siparisDetay.SiparisMasterId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "ID", "UrunAciklama", siparisDetay.UrunId);
            return View(siparisDetay);
        }

        /// <summary>
        /// Belirli bir sipariş detayını silmek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Silinecek sipariş detayının kimliği</param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiparisDetaylar == null)
            {
                return NotFound();
            }

            var siparisDetay = await _context.SiparisDetaylar
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
            if (_context.SiparisDetaylar == null)
            {
                return Problem("Entity set 'SqlDbContext.SiparisDetaylar'  is null.");
            }
            var siparisDetay = await _context.SiparisDetaylar.FindAsync(id);
            if (siparisDetay != null)
            {
                _context.SiparisDetaylar.Remove(siparisDetay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisDetayExists(int id)
        {
            return (_context.SiparisDetaylar?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}