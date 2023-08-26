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
            // Cookie'den masa id'sini çekiyorum.
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            // Masa yeni oluşturuldu mu diye bakıyorum
            bool yeniSiparis = true;

            //DB'De ki Sipariş Master'leri çekiyorum
            var masters = dbContext.SiparisMasterlar.Where(s => s.MasaId == masaid).Where(s => s.IsActive == true);
            // SiparişDetail atamak için yeni bir detail listesi oluşturuyorum.
            List<SiparisDetay> details  = new();

            //DB'den çekilen Sipariş Master' yeni siparisMaster olarak atıyorum
            SiparisMaster siparisMaster = masters.FirstOrDefault();

            // siparisMaster boş veya değersiz dönmediyse SiparişMaster'de ki Details'ları çekiyorum
            // ve yeni sipariş boolean'ını kapatıyorum.
            if (siparisMaster != null)
            {
                details = dbContext.SiparisDetaylar.Where(d => d.SiparisMasterId == siparisMaster.ID).ToList();
                yeniSiparis = false;
            }

            // DB'den gelen siparişMaster' null ise yeni bir tane oluşturuyorum.
            if (siparisMaster == null)
            {
                siparisMaster = new SiparisMaster();

                siparisMaster.CreateTime = DateTime.Now;
                siparisMaster.UpdateTime = DateTime.Now;

                siparisMaster.MasaId = masaid;
                siparisMaster.Masa = await dbContext.Masalar.FindAsync(id);
                siparisMaster.IsActive = true;
                siparisMaster.SiparisDetay = new List<SiparisDetay>();
            }
            else // null değil ise yukarıda oluşturduğum details listesinin atamasını yapıyorum.
                siparisMaster.SiparisDetay = details;

            // Gelen ürün sipariş detay olarak oluşturuluyor.
            SiparisDetay siparisDetay = new SiparisDetay
                (
                siparisMaster.ID,
                siparisMaster,
                await dbContext.Urunler.FindAsync(id),
                dbContext.Urunler.Find(id).ID,
                1,
                dbContext.Urunler.Find(id).Fiyat
                );

            // Yeni eklenen ürün siparisMaster'de ki sipariş Detay listesine ekleniyor.
            siparisMaster.SiparisDetay.Add(siparisDetay);

            //DB KAYIT
            await dbContext.SiparisDetaylar.AddAsync(siparisDetay);
            if (yeniSiparis) // Yeni Master ise DB kayıt
                await dbContext.SiparisMasterlar.AddAsync(siparisMaster);

            //SaveChange
            await dbContext.SaveChangesAsync();

            //Siparişler liste olarak sayfaya gönderiliyor.
            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMaster.MasaId == siparisMaster.MasaId).ToList();
            return View(siparisler);
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(SiparisMaster siparisMaster)
        {
            return View();
        }
    }
}