using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {
        private readonly SqlDbContext _context;

        public UrunController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Urun
        public async Task<IActionResult> Index()
        {
            var sqlDbContext = _context.Urunler.Include(u => u.Kategori);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Admin/Urun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // GET: Admin/Urun/Create
        public IActionResult Create()
        {
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "ID", "KategoriAdi");
            return View();
        }

        // POST: Admin/Urun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunAdi,UrunAciklama,FotografLink,Fiyat,KategoriID,ID,CreateTime,UpdateTime")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "ID", "KategoriAdi");
                return View(urun);
            }
            try
            {
                _context.Urunler.Add(urun);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Aynı İsimde bir ürün zaten mevcut");
                ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "ID", "KategoriAdi");
                return View(urun);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Urun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var urun = _context.Urunler.Find(id);
            ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "ID", "KategoriAdi");
            return View(urun);
        }

        // POST: Admin/Urun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrunAdi,UrunAciklama,FotografLink,Fiyat,KategoriID,ID,CreateTime,UpdateTime")] Urun urun)
        {
            if (id != urun.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                return View(urun);
            }
            try
            {
                _context.Urunler.Update(urun);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Aynı İsimde bir urun zaten mevcut");
                ViewData["KategoriID"] = new SelectList(_context.Kategoriler, "ID", "KategoriAdi");
                return View(urun);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Urun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // POST: Admin/Urun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Urunler == null)
            {
                return Problem("Entity set 'SqlDbContext.Urunler'  is null.");
            }
            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunExists(int id)
        {
          return (_context.Urunler?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
