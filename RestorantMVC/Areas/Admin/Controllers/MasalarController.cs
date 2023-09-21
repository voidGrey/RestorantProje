using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasalarController : Controller
    {
        private readonly SqlDbContext _context;
        private readonly UserManager<Firma> userManager;

        public MasalarController(SqlDbContext context, UserManager<Firma> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Admin/Masalar
        public async Task<IActionResult> Index()
        {
            return _context.Masalar != null ?
                        View(await _context.Masalar.ToListAsync()) :
                        Problem("Entity set 'SqlDbContext.Masalar'  is null.");
        }

        // GET: Admin/Masalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Masalar == null)
            {
                return NotFound();
            }

            var masa = await _context.Masalar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masa == null)
            {
                return NotFound();
            }

            return View(masa);
        }

        // GET: Admin/Masalar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Masalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasaID,MasaSifresi,ID,CreateTime,UpdateTime")] Masa masa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masa);
        }

        // GET: Admin/Masalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Masalar == null)
            {
                return NotFound();
            }

            var masa = await _context.Masalar.FindAsync(id);
            if (masa == null)
            {
                return NotFound();
            }
            return View(masa);
        }

        // POST: Admin/Masalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("MasaID,MasaSifresi,ID,CreateTime,UpdateTime")] Masa masa)
        {
            if (id != masa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasaExists(masa.ID))
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
            return View(masa);
        }

        // GET: Admin/Masalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Masalar == null)
            {
                return NotFound();
            }

            var masa = await _context.Masalar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masa == null)
            {
                return NotFound();
            }

            return View(masa);
        }

        // POST: Admin/Masalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Masalar == null)
            {
                return Problem("Entity set 'SqlDbContext.Masalar'  is null.");
            }
            var masa = await _context.Masalar.FindAsync(id);
            if (masa != null)
            {
                _context.Masalar.Remove(masa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SiparisiKapat(int? id)
        {
            if (id == null) { return NotFound(); }
            var masa = await _context.Masalar.FirstOrDefaultAsync(m => m.ID == id);
            if (masa == null) { return NotFound(); }

            return View(masa);
        }

        [HttpPost, ActionName("SiparisiKapat")]
        public async Task<IActionResult> SiparisiKapatConfirmed(int id)
        {
            if (_context.Masalar == null)
            {
                return Problem("Entity set 'SqlDbContext.Masalar'  is null.");
            }
            var masa = await _context.Masalar.FindAsync(id);
            if (masa != null)
            {
                masa.MasaSifresi = null;
                masa.CreateTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasaExists(int id)
        {
            return (_context.Masalar?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}