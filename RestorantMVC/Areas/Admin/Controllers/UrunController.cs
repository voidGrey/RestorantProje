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
    public class UrunController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;


        public UrunController(SqlDbContext context, UserManager<Firma> userManager)
        {
            dbContext = context;
            this.userManager = userManager;
        }

        // GET: Admin/Urun
        public async Task<IActionResult> Index()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var sqlDbContext = dbContext.Urunler.FirmaFilter(firmaId).Include(u => u.Kategori);

            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Admin/Urun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await this.SetUser(userManager);

            if (id == null || dbContext.Urunler == null)

            {
                return NotFound();
            }

            var urun = await dbContext.Urunler
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // GET: Admin/Urun/Create
        public async Task<IActionResult> Create()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler.FirmaFilter(firmaId) , "ID" , "KategoriAdi");;

            return View();
        }

        // POST: Admin/Urun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunAdi,UrunAciklama,FotografLink,Fiyat,KategoriID,ID,CreateTime,UpdateTime")] Urun urun)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            urun.FirmaId = firmaId;

            if (ModelState.IsValid)
            {
                ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler , "ID" , "KategoriAdi");
                return View(urun);
            }
            try
            {
                dbContext.Urunler.Add(urun);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("" , "Aynı İsimde bir ürün zaten mevcut");
                ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler , "ID" , "KategoriAdi");
                return View(urun);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Urun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await this.SetUser(userManager);

            var urun = dbContext.Urunler.Find(id);
            ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler , "ID" , "KategoriAdi");

            return View(urun);
        }

        // POST: Admin/Urun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("UrunAdi,UrunAciklama,FotografLink,Fiyat,KategoriID,ID,CreateTime,UpdateTime")] Urun urun)
        {
            await this.SetUser(userManager);

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
                dbContext.Urunler.Update(urun);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("" , "Aynı İsimde bir urun zaten mevcut");
                ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler , "ID" , "KategoriAdi");
                return View(urun);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Urun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await this.SetUser(userManager);

            if (id == null || dbContext.Urunler == null)

            {
                return NotFound();
            }

            var urun = await dbContext.Urunler
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
            await this.SetUser(userManager);

            if (dbContext.Urunler == null)

            {
                return Problem("Entity set 'SqlDbContext.Urunler'  is null.");
            }
            var urun = await dbContext.Urunler.FindAsync(id);
            if (urun != null)
            {
                dbContext.Urunler.Remove(urun);
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunExists(int id)
        {
            return (dbContext.Urunler?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}