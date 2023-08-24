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

        public async Task<IActionResult> Ekle(int id)
        {
            SiparisMaster siparisMaster = new SiparisMaster();
            siparisMaster.ID = await dbContext.SiparisMasterlar.CountAsync() + 10;
            siparisMaster.CreateTime = DateTime.Now;
            siparisMaster.UpdateTime = DateTime.Now;

            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            siparisMaster.MasaId = masaid;
            siparisMaster.Masa = await dbContext.Masalar.FindAsync(id);
            siparisMaster.IsActive = true;

            SiparisDetay siparisDetay = new SiparisDetay
                (
                await dbContext.SiparisDetaylar.CountAsync() + 10,
                siparisMaster.ID,
                siparisMaster,
                await dbContext.Urunler.FindAsync(id),
                dbContext.Urunler.Find(id).ID,
                1,
                dbContext.Urunler.Find(id).Fiyat
                );

            siparisMaster.SiparisDetay = new List<SiparisDetay>();
            siparisMaster.SiparisDetay.Add(siparisDetay);

            dbContext.SiparisMasterlar.Add(siparisMaster);
            dbContext.SiparisDetaylar.Add(siparisDetay);

            dbContext.SaveChanges();

            return View();


            //var siparis = dbContext.Masalar.Find(masaId).Siparis;
            //SiparisDetay yeniSiparisDetay = new SiparisDetay();

            //yeniSiparisDetay.SiparisMaster = siparis;
            //yeniSiparisDetay.SiparisMasterId = id;
            //yeniSiparisDetay.UrunId = masaId;
            //yeniSiparisDetay.Urun = dbContext.Urunler.Find(masaId);
            //yeniSiparisDetay.Fiyat = dbContext.Urunler.Find(masaId).Fiyat;

            //siparis.SiparisDetay.Add(yeniSiparisDetay);

            //dbContext.Masalar.Find(id).Siparis = siparis;

            //dbContext.SaveChanges();
            //return RedirectToAction("Ekle");
        }
    }
}