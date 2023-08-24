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

        public async Task<IActionResult> Ekle(int id, int masaId)
        {
            SiparisMaster siparisMaster = dbContext.Masalar.Find(masaId).Siparis;

            SiparisDetay yenisiparis = new();
            yenisiparis.SiparisMaster = siparisMaster;
            
            yenisiparis.SiparisMasterId = id;
            yenisiparis.UrunId = masaId;
            yenisiparis.Urun = dbContext.Urunler.Find(masaId);
            yenisiparis.Fiyat = dbContext.Urunler.Find(masaId).Fiyat;

            siparisMaster.SiparisDetay.Add(yenisiparis);

            dbContext.Masalar.Find(id).Siparis = siparisMaster;

            dbContext.SaveChanges();
            return RedirectToAction("Ekle");


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