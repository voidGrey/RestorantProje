using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasalarController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;

        public MasalarController(SqlDbContext context, UserManager<Firma> userManager)
        {
            dbContext = context;
            this.userManager = userManager;

        }

        // GET: Admin/Masalar
        public async Task<IActionResult> Index()
        {

            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            return dbContext.Masalar != null ?
                        View(await dbContext.Masalar.FirmaFilter(firmaId).ToListAsync()) :

                        Problem("Entity set 'SqlDbContext.Masalar'  is null.");
        }

        // GET: Admin/Masalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await this.SetUser(userManager);

            if (id == null || dbContext.Masalar == null)

            {
                return NotFound();
            }

            var masa = await dbContext.Masalar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masa == null)
            {
                return NotFound();
            }

            return View(masa);
        }

        // GET: Admin/Masalar/Create
        public async Task<IActionResult> Create()
        {
            await this.SetUser(userManager);

            return View();
        }

        // POST: Admin/Masalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasaID,MasaSifresi,ID,CreateTime,UpdateTime")] Masa masa)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            masa.FirmaId = firmaId;
            if (ModelState.IsValid) 
            {
                dbContext.Add(masa); 
                await dbContext.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
            return View(masa);
        }

        // GET: Admin/Masalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await this.SetUser(userManager);


            if (id == null || dbContext.Masalar == null)

            {
                return NotFound();
            }

            var masa = await dbContext.Masalar.FindAsync(id);
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
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);
            masa.FirmaId = firmaId;
            masa.UpdateTime = DateTime.Now;

            if (id != masa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(masa);
                    await dbContext.SaveChangesAsync();
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
            await this.SetUser(userManager);

            if (id == null || dbContext.Masalar == null)

            {
                return NotFound();
            }

            var masa = await dbContext.Masalar
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
            await this.SetUser(userManager);

            if (dbContext.Masalar == null)

            {
                return Problem("Entity set 'SqlDbContext.Masalar'  is null.");
            }
            var masa = await dbContext.Masalar.FindAsync(id);
            if (masa != null)
            {
                dbContext.Masalar.Remove(masa);
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SiparisiKapat(int? id)
        {
            await this.SetUser(userManager);

            if (id == null) { return NotFound(); }
            var masa = await dbContext.Masalar.FirstOrDefaultAsync(m => m.ID == id);
            if (masa == null) { return NotFound(); }

            return View(masa);
        }

        [HttpPost, ActionName("SiparisiKapat")]
        public async Task<IActionResult> SiparisiKapatConfirmed(int id)
        {
            await this.SetUser(userManager);

            if (dbContext.Masalar == null)

            {
                return Problem("Entity set 'SqlDbContext.Masalar'  is null.");
            }
            var masa = await dbContext.Masalar.FindAsync(id);
            if (masa != null)
            {
                masa.MasaSifresi = null;
                masa.CreateTime = DateTime.Now;
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasaExists(int id)
        {

            return (dbContext.Masalar?.Any(e => e.ID == id)).GetValueOrDefault();

        }
    }
}