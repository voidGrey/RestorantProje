using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;

namespace RestorantMVC.Controllers
{
    public class QRController : Controller
    {
        private readonly SqlDbContext dbContext;

        public QRController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Eğer bir id içermiyorsa doğrudan Home sayfasına yönlendirir.
        /// </summary>
        public IActionResult Index()
        {
            return RedirectToAction("Scan");
        }

        /// <summary>
        /// ID ile gelen kullanıcıya Cookie yapıştırarak tanınmasını sağlar.
        /// </summary>
        /// <param name="id">MasaID Değeri</param>
        public async Task<IActionResult> Scan(int id , string f)
        {

            //Gelen Firma ID Encrypt'i byte Arraya geri dönüştürülüp string'e çevriliyor.
            byte[] firmaId = WebEncoders.Base64UrlDecode(f);
            string decryptValue = await RestorantExtension.DecryptAsync(firmaId,"YeyoYoOyeŞifrehehe");
            this.Response.Cookies.Append("f" , f);

            if (id == null || string.IsNullOrEmpty(id.ToString()) || id == 0)
            {
                return Content("Okuttuğunuz QR Geçersiz veya Zarar görmüş lütfen bir garsondan yardım isteyiniz.");
            }
            else
            {

                // DB'den masa çekiliyor.
                var masa = await dbContext.Masalar.FirmaFilter(decryptValue).Where(p=> p.MasaID == id).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(masa.MasaSifresi)) // Masa şifresi var mı diye kontrol edilir.
                {
                    string value = id.ToString();
                    if (Request.Cookies.TryGetValue("MasaId" , out value)) // Kullanıcının Cookie'si var mı diye bakar
                    {
                        return RedirectToAction("Index","Menu", new {area = "Musteri"});
                    }

                    //Cookie eklenir.
                    this.Response.Cookies.Append("MasaId" , id.ToString());
                    
                    //Masa Şifresi oluşturuluyor.
                    dbContext.Masalar.FirmaFilter(decryptValue)
                                     .Where(masa => masa.MasaID == id)
                                     .FirstOrDefaultAsync()
                                     .Result.MasaSifresi = masa.SifreOlustur();
                    dbContext.SaveChanges();
                    return RedirectToAction("SifreAyarla", new {firmaId = decryptValue});
                }
                else
                {
                    return RedirectToAction("Giris" , new { id = masa.ID });
                }
            }
        }

        public async Task<IActionResult> SifreAyarla(string firmaId)
        {
            int id = Convert.ToInt32(Request.Cookies["MasaId"]);
            Masa masa = await dbContext.Masalar.FirmaFilter(firmaId).Where(m => m.MasaID == id).FirstOrDefaultAsync();
            return View(masa);
        }

        [HttpGet]
        public IActionResult Giris(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(Masa cloneMasa)
        {
            int id = cloneMasa.ID;
            Masa masa = await dbContext.Masalar.FindAsync(id);

            if (masa == null) { return NotFound(); }

            if (masa.MasaSifresi == cloneMasa.MasaSifresi)
            {
                this.Response.Cookies.Append("MasaId" , id.ToString());

                return RedirectToAction("Index" , "Home");
            }
            else
            {
                return View();
            }
        }
    }
}