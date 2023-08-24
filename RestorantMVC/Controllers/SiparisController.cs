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
            var sqlDbContext = _context.SiparisMasterlar.Include(s => s.Masa);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Siparis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiparisMasterlar == null)
            {
                return NotFound();
            }

            var siparisMaster = await _context.SiparisMasterlar
                .Include(s => s.Masa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (siparisMaster == null)
            {
                return NotFound();
            }

            return View(siparisMaster);
        }

        // GET: Siparis/Create
        public IActionResult Create()
        {
            ViewData["MasaId"] = new SelectList(_context.Masalar, "ID", "ID");
            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasaId,ToplamTutar,IsActive,ID,CreateTime,UpdateTime")] SiparisMaster siparisMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MasaId"] = new SelectList(_context.Masalar, "ID", "ID", siparisMaster.MasaId);
            return View(siparisMaster);
        }

        // GET: Siparis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SiparisMasterlar == null)
            {
                return NotFound();
            }

            var siparisMaster = await _context.SiparisMasterlar.FindAsync(id);
            if (siparisMaster == null)
            {
                return NotFound();
            }
            ViewData["MasaId"] = new SelectList(_context.Masalar, "ID", "ID", siparisMaster.MasaId);
            return View(siparisMaster);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MasaId,ToplamTutar,IsActive,ID,CreateTime,UpdateTime")] SiparisMaster siparisMaster)
        {
            if (id != siparisMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(siparisMaster);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparisMasterExists(siparisMaster.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["MasaId"] = new SelectList(_context.Masalar, "ID", "ID", siparisMaster.MasaId);
            return View(siparisMaster);
        }

        // GET: Siparis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiparisMasterlar == null)
            {
                return NotFound();
            }

            var siparisMaster = await _context.SiparisMasterlar
                .Include(s => s.Masa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (siparisMaster == null)
            {
                return NotFound();
            }

            return View(siparisMaster);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SiparisMasterlar == null)
            {
                return Problem("Entity set 'SqlDbContext.SiparisMasterlar'  is null.");
            }
            var siparisMaster = await _context.SiparisMasterlar.FindAsync(id);
            if (siparisMaster != null)
            {
                _context.SiparisMasterlar.Remove(siparisMaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisMasterExists(int id)
        {
          return (_context.SiparisMasterlar?.Any(e => e.ID == id)).GetValueOrDefault();
        }

    }
}
