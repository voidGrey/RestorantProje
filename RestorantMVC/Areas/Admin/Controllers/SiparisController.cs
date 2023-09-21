using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;

        public SiparisController(SqlDbContext dbContext, UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View(Siparisler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var masaListesi = (from item in dbContext.Masalar
                               select new SelectListItem
                               {
                                   Text = item.MasaID.ToString(),
                                   Value = item.MasaID.ToString()
                               }).ToList();
            ViewBag.Masalar = masaListesi;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SiparisMaster siparisMaster)
        {
            dbContext.SiparisMasterlar.Add(siparisMaster);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CloseOrder(int id)
        {
            var siparis = await dbContext.SiparisMasterlar.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }

            siparis.IsActive = false;
            siparis.MasaId = null;

            dbContext.Update(siparis);
            await dbContext.SaveChangesAsync();

            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View("Index" , Siparisler);
        }

        public async Task<IActionResult> Details(int id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);
            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMaster.MasaId == siparismaster.MasaId).ToList();

            List<Urun> urunler = new List<Urun>();

            foreach (var item in siparisler)
            {
                Urun clone = await dbContext.Urunler.Where(p=> p.ID == item.UrunId).FirstOrDefaultAsync();

                urunler.Add(clone);
            }

            ViewBag.Urun = urunler;

            return View(siparisler);
        }
    }
}