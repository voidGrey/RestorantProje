using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;

namespace RestorantMVC.Controllers
{
    public class SiparisController : Controller
    {
        private readonly SqlDbContext _context;

        public SiparisController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Siparis
        public async Task<IActionResult> Index()
        {
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            var x = _context.SiparisMasterlar.Where(s => s.MasaId == masaid);
            var sqlDbContext = x.FirstOrDefault();
            var s = _context.SiparisDetaylar.Where(d => d.SiparisMasterId == sqlDbContext.ID).ToListAsync();
            return View(s);
        }

        // GET: Siparis/Details/5
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

        // GET: Siparis/Create
        public IActionResult Create()
        {
            ViewData["SiparisMasterId"] = new SelectList(_context.SiparisMasterlar, "ID", "ID");
            ViewData["UrunId"] = new SelectList(_context.Urunler, "ID", "UrunAciklama");
            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Siparis/Edit/5
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

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Siparis/Delete/5
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

        // POST: Siparis/Delete/5
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
