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
    public class SiparisController : Controller
    {
        private readonly SqlDbContext _context;

        public SiparisController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Siparis
        public async Task<IActionResult> Index()
        {
            var sqlDbContext = _context.Siparisler.Include(s => s.Masa);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Admin/Siparis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler
                .Include(s => s.Masa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (siparis == null)
            {
                return NotFound();
            }

            return View(siparis);
        }

        // GET: Admin/Siparis/Create
        public IActionResult Create()
        {
            ViewData["MasaID"] = new SelectList(_context.Masalar, "ID", "ID");
            return View();
        }

        // POST: Admin/Siparis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToplamFiyat,MasaID,ID,CreateTime,UpdateTime")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MasaID"] = new SelectList(_context.Masalar, "ID", "ID", siparis.MasaID);
            return View(siparis);
        }

        // GET: Admin/Siparis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }
            ViewData["MasaID"] = new SelectList(_context.Masalar, "ID", "ID", siparis.MasaID);
            return View(siparis);
        }

        // POST: Admin/Siparis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToplamFiyat,MasaID,ID,CreateTime,UpdateTime")] Siparis siparis)
        {
            if (id != siparis.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparisExists(siparis.ID))
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
            ViewData["MasaID"] = new SelectList(_context.Masalar, "ID", "ID", siparis.MasaID);
            return View(siparis);
        }

        // GET: Admin/Siparis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparis = await _context.Siparisler
                .Include(s => s.Masa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (siparis == null)
            {
                return NotFound();
            }

            return View(siparis);
        }

        // POST: Admin/Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Siparisler == null)
            {
                return Problem("Entity set 'SqlDbContext.Siparisler'  is null.");
            }
            var siparis = await _context.Siparisler.FindAsync(id);
            if (siparis != null)
            {
                _context.Siparisler.Remove(siparis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisExists(int id)
        {
          return (_context.Siparisler?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
