using AutoMapper;
using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using RestorantMVC.Models;
using System.IO.MemoryMappedFiles;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UrunController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly UserManager<Firma> userManager;
        private string firmaId;


        public UrunController(SqlDbContext context, UserManager<Firma> userManager, IMapper Mapper, IWebHostEnvironment _hostingEnviroment)
        {
            dbContext = context;
            this.userManager = userManager;
            mapper = Mapper;
            hostingEnviroment = _hostingEnviroment;
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
        public async Task<IActionResult> Create([Bind("UrunAdi,UrunAciklama,FotografLink,Fiyat,KategoriID,ID,CreateTime,UpdateTime")] UrunModel urunV)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var urun = mapper.Map<Urun>(urunV);

            urun.FirmaId = firmaId;
            urun.CreateTime = DateTime.Now;

            // Resim Yükleme Alanı.

            IFormFile theFile = HttpContext.Request.Form.Files[0];
            string uploads = Path.Combine(hostingEnviroment.WebRootPath,"uploads");
            if(theFile.Length > 0)
            {
                string filePath = Path.Combine(uploads, theFile.Name) + ".jpg";
                using(Stream fileStream = new FileStream(filePath , FileMode.Create))
                {
                    await theFile.CopyToAsync(fileStream);
                }
                urun.FotografLink = filePath;

            }

            // Resim Yüklendi.


            if (!IsUniqueForFirma(urun.UrunAdi , firmaId))
            {
                ModelState.AddModelError("KategoriAdi" , "Kategori adı zaten mevcut");
                return View(urun);
            }
            if (!ModelState.IsValid)
            {
                try
                {
                    dbContext.Urunler.Add(urun);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("" , "Aynı İsimde bir ürün zaten mevcut");
                    ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler.FirmaFilter(firmaId) , "ID" , "KategoriAdi");
                    return Json(ex);
                }
            }
            return View(urun);
        }

        private bool IsUniqueForFirma(string urunadi , string firmaId)
        {
            firmaId = userManager.GetUserId(User);

            var kategorivarmi = dbContext.Urunler.FirstOrDefault(c => c.UrunAdi == urunadi && c.FirmaId == firmaId);
            return kategorivarmi == null;
        }

        // GET: Admin/Urun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var urun = dbContext.Urunler.Find(id);
            ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler.FirmaFilter(firmaId).ToList() , "ID" , "KategoriAdi");

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
            firmaId = userManager.GetUserId(User);
            urun.FirmaId = firmaId;
            urun.UpdateTime = DateTime.Now;

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
            catch (Exception ex)
            {
                ModelState.AddModelError("" , ex.Message);
                ViewData["KategoriID"] = new SelectList(dbContext.Kategoriler.FirmaFilter(firmaId).ToList() , "ID" , "KategoriAdi");
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