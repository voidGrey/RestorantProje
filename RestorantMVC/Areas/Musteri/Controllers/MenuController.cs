using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using RestorantMVC.Hubs;

namespace RestorantMVC.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class MenuController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly IHubContext<SiparisHub> hubContext;
        private string decryptValue;

        public MenuController(SqlDbContext dbContext, IHubContext<SiparisHub> hubContext)
        {
            this.dbContext = dbContext;
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            await this.ViewBagSettings(dbContext);

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            Kategori selfIdToId = await dbContext.Kategoriler.FirmaFilter(firmaId).FirstOrDefaultAsync();
            int? findId = selfIdToId.SelfKategoriID;

            return RedirectToAction("Kategori", new {id=findId});
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
            int findId = selfIdToId.ID;

            var urunler = await dbContext.Urunler.FirmaFilter(firmaId).Where(a => a.KategoriID == findId).ToListAsync();
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

            Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");

            // Cookie'den masa id'sini çekiyorum.
            int masaid = Convert.ToInt32(HttpContext.Request.Cookies["MasaId"]);

            // Ürünü çekiyorum.
            Urun urun = await dbContext.Urunler.FirmaFilter(firmaId).Where(u => u.ID == id).FirstOrDefaultAsync();

            //Siparis Masterler'in listesi
            var siparisMasterler = await dbContext.SiparisMasterlar.FirmaFilter(firmaId).Where(m => m.MasaId == masaid).ToListAsync();

            //Clone sipariş master.
            SiparisMaster clone = null;
            int cloneID = 0;

            foreach (var item in siparisMasterler)
            {
                if (item.IsActive)
                {
                    clone = item;
                    cloneID = item.ID;
                }
            }

            if (clone == null)
            {
                clone = new SiparisMaster();
                clone.IsActive = true;
                clone.FirmaId = firmaId;
                clone.MasaId = masaid;
                await dbContext.SiparisMasterlar.AddAsync(clone);
                await dbContext.SaveChangesAsync();
                cloneID = dbContext.SiparisMasterlar.Count();
            }

            var siparisDetaylar = await dbContext.SiparisDetaylar.FirmaFilter(firmaId)
                                        .Where(v => v.SiparisMasterId == cloneID).ToListAsync();

            clone.SiparisDetay = siparisDetaylar;
            bool urunStatus = true;

            foreach (var item in clone.SiparisDetay)
            {
                if (item.UrunId == urun.ID && item.status == SiparisDetay.Status.Onay_Bekliyor)
                {
                    item.Adet++;
                    item.status = SiparisDetay.Status.Onay_Bekliyor;
                    dbContext.SiparisDetaylar.Update(item);
                    await dbContext.SaveChangesAsync();
                    urunStatus = false;

                    continue;
                }
            }

            if (urunStatus)
            {
                SiparisDetay siparisDetay = new SiparisDetay();
                siparisDetay.FirmaId = firmaId;
                siparisDetay.Adet = 1;
                siparisDetay.Urun = urun;
                siparisDetay.UrunId = urun.ID;
                siparisDetay.CreateTime = DateTime.Now;
                siparisDetay.Fiyat = urun.Fiyat * siparisDetay.Adet;
                siparisDetay.SiparisMasterId = cloneID;
                siparisDetay.status = SiparisDetay.Status.Onay_Bekliyor;
                await dbContext.SiparisDetaylar.AddAsync(siparisDetay);
                await dbContext.SaveChangesAsync();
            }
            await hubContext.Clients.All.SendAsync("YeniSiparisGeldi", 1);

            return RedirectToAction("Index" , "Siparis");
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