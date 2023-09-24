using DAL.Contexts;
using DAL.Repository.Abstract;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using System.Security.Cryptography.X509Certificates;

namespace RestorantMVC.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class MenuController : Controller
    {
        private readonly SqlDbContext dbContext;
        private string decryptValue;
        public MenuController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            await this.ViewBagSettings(dbContext);

            return View();
        }


        /// <summary>
        /// Belirli bir kategoriye ait ürünleri listelemek için kullanılan işlem.
        /// </summary>
        /// <param name="id">Kategori kimliği</param>
        public async Task<IActionResult> Kategori(int? id)
        {
            await this.ViewBagSettings(dbContext);

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            Kategori selfIdToId = await dbContext.Kategoriler.FirmaFilter(firmaId).Where(kategori => kategori.SelfKategoriID == id).FirstOrDefaultAsync();

            var urunler = await dbContext.Urunler.FirmaFilter(firmaId).Where(a => a.KategoriID == selfIdToId.ID).ToListAsync();
            return View(urunler);
        }

        /// <summary>
        /// Belirli bir ürünü siparişe eklemek için kullanılan GET işlemi.
        /// </summary>
        /// <param name="id">Eklenen ürünün kimliği</param>
        [HttpGet]
        public async Task<IActionResult> Ekle(int id)
        {
            await this.ViewBagSettings(dbContext);

            // Cookie'den masa id'sini çekiyorum.
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);
            if (masaid == 0)
            {
                return RedirectToAction("IndexLogin", "Home", new { area = "default" });
            }
            // Masa yeni oluşturuldu mu diye bakıyorum
            bool yeniSiparis = true;

            //DB'De ki Sipariş Master'leri çekiyorum
            var masters = dbContext.SiparisMasterlar.Where(s => s.MasaId == masaid).Where(s => s.IsActive == true);
            // SiparişDetail atamak için yeni bir detail listesi oluşturuyorum.
            List<SiparisDetay> details = new();

            //DB'den çekilen Sipariş Master' yeni siparisMaster olarak atıyorum
            SiparisMaster siparisMaster = masters.FirstOrDefault();

            // siparisMaster boş veya değersiz dönmediyse SiparişMaster'de ki Details'ları çekiyorum
            // ve yeni sipariş boolean'ını kapatıyorum.
            if (siparisMaster != null)
            {
                details = dbContext.SiparisDetaylar.Where(d => d.SiparisMasterId == siparisMaster.ID).ToList();
                yeniSiparis = false;
            }

            // DB'den gelen siparisMaster' null ise yeni bir tane oluşturuyorum.
            if (siparisMaster == null) { siparisMaster = await CreateSiparisMaster(id , masaid); }
            else // null değil ise yukarıda oluşturduğum details listesinin atamasını yapıyorum.
                siparisMaster.SiparisDetay = details;

            // Gelen ürün sipariş detay olarak oluşturuluyor.
            bool AynıUrunKontrolu = false;
            foreach (var item in siparisMaster.SiparisDetay)
            {
                if (item.UrunId == id)
                {
                    AynıUrunKontrolu = true;
                }
            }
            if (AynıUrunKontrolu)
            {
                var siparisDetay = dbContext.SiparisDetaylar
                    .FirstOrDefault(x => x.UrunId == id && x.SiparisMasterId == siparisMaster.ID);

                if (siparisDetay != null)
                {
                    siparisDetay.Adet++;
                    dbContext.SaveChanges();
                }
            }
            else { await CreateSiparisDetay(id , yeniSiparis , siparisMaster); }

            //Database'e kaydedilen sipariş master'ın ToplamTutarı Güncelleniyor ve database'e yeniden kayıt ediliyor.
            await dbContext.SaveChangesAsync();
            siparisMaster.ToplamTutar = dbContext.SiparisDetaylar.Where(v => v.SiparisMasterId == siparisMaster.ID).Sum(x => x.Fiyat * x.Adet);
            await dbContext.SaveChangesAsync();

            //Siparişler liste olarak sayfaya gönderiliyor.
            ICollection<SiparisDetay> siparisler = dbContext.SiparisDetaylar.Where(sd => sd.SiparisMaster.MasaId == siparisMaster.MasaId).ToList();
            return RedirectToAction("Index" , "Siparis");
        }

        /// <summary>
        /// Belirtilen ürün ID'si ve sipariş Master nesnesi ile yeni bir sipariş detayı oluşturur ve veritabanına kaydeder.
        /// </summary>
        /// <param name="id">Ürünün ID'si.</param>
        /// <param name="yeniSiparis">Eğer bu yeni bir sipariş ise true, aksi takdirde false.</param>
        /// <param name="siparisMaster">Siparişin ait olduğu Master nesnesi.</param>
        /// <returns>Asenkron bir işlem sonucu.</returns>
        private async Task CreateSiparisDetay(int id , bool yeniSiparis , SiparisMaster siparisMaster)
        {
            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            SiparisDetay siparisDetay = new SiparisDetay
                  (
                  siparisMaster.ID,
                  siparisMaster,
                  await dbContext.Urunler.FindAsync(id),
                  dbContext.Urunler.Find(id).ID,
                  1,
                  dbContext.Urunler.Find(id).Fiyat
                  );

            siparisDetay.FirmaId = firmaId;
            siparisMaster.ToplamTutar = dbContext.SiparisDetaylar.Sum(x => x.Fiyat);

            // Yeni eklenen ürün siparisMaster'de ki sipariş Detay listesine ekleniyor.
            siparisMaster.SiparisDetay.Add(siparisDetay);

            //DB KAYIT
            await dbContext.SiparisDetaylar.AddAsync(siparisDetay);
            if (yeniSiparis) // Yeni Master ise DB kayıt
                await dbContext.SiparisMasterlar.AddAsync(siparisMaster);
        }

        /// <summary>
        /// Belirtilen masa ID'si ve sipariş oluşturma tarihi ile yeni bir sipariş Master nesnesi oluşturur.
        /// </summary>
        /// <param name="id">Masa ID'si.</param>
        /// <param name="masaid">Siparişin ait olduğu masa ID'si.</param>
        /// <returns>Oluşturulan sipariş Master nesnesi.</returns>
        private async Task<SiparisMaster> CreateSiparisMaster(int id , int masaid)
        {

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            SiparisMaster siparisMaster = new SiparisMaster();
            siparisMaster.CreateTime = DateTime.Now;
            siparisMaster.UpdateTime = DateTime.Now;
            siparisMaster.MasaId = masaid;
            siparisMaster.Masa = await dbContext.Masalar.FindAsync(id);
            siparisMaster.IsActive = true;
            siparisMaster.SiparisDetay = new List<SiparisDetay>();
            siparisMaster.FirmaId = firmaId;
            return siparisMaster;
        }

        /// <summary>
        /// Belirli bir ürünü siparişe eklemek için kullanılan POST işlemi.
        /// </summary>
        /// <param name="siparisMaster">Sipariş Master nesnesi</param>
        [HttpPost]
        public async Task<IActionResult> Ekle(SiparisMaster siparisMaster)
        {
            await this.ViewBagSettings(dbContext);

            return View();
        }
    }
}