using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly SqlDbContext dbContext;

        public MenuController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Kategori(int? id)
        {
            var urunler = await dbContext.Urunler.Where(a => a.KategoriID == id).ToListAsync();
            return View(urunler);
        }
        [HttpGet]
        public async Task<IActionResult> Ekle(int id)
        {
            SiparisMaster siparisMaster = new SiparisMaster();
            
            siparisMaster.CreateTime = DateTime.Now;
            siparisMaster.UpdateTime = DateTime.Now;

            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            siparisMaster.MasaId = masaid;
            siparisMaster.Masa = await dbContext.Masalar.FindAsync(id);
            siparisMaster.IsActive = true;

            SiparisDetay siparisDetay = new SiparisDetay
                (
                siparisMaster.ID,
                siparisMaster,
                await dbContext.Urunler.FindAsync(id),
                dbContext.Urunler.Find(id).ID,
                1,
                dbContext.Urunler.Find(id).Fiyat
                );

            siparisMaster.SiparisDetay = new List<SiparisDetay>();
            siparisMaster.SiparisDetay.Add(siparisDetay);

            await dbContext.SiparisDetaylar.AddAsync(siparisDetay);
            await dbContext.SiparisMasterlar.AddAsync(siparisMaster);

            await dbContext.SaveChangesAsync();

            return View(siparisMaster);
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(SiparisMaster siparisMaster)
        {
            ICollection<SiparisDetay> x = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMasterId == siparisMaster.ID).ToList();
            return View(x);
        }
    }
}