using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Scan(int id)
        {
            if (id == null || string.IsNullOrEmpty(id.ToString()) || id == 0)
            {
                return Content("Okuttuğunuz QR Geçersiz veya Zarar görmüş lütfen bir garsondan yardım isteyiniz.");
            }
            else
            {
                var masa = await dbContext.Masalar.FindAsync(id);

                if (string.IsNullOrEmpty(masa.MasaSifresi)) // Masa şifresi var mı diye kontrol edilir.
                {
                    string value = id.ToString();
                    if (Request.Cookies.TryGetValue("MasaId" , out value)) // Kullanıcının Cookie'si var mı diye bakar
                    {
                        return RedirectToAction("Index" , "Home");
                    }

                    //Cookie eklenir.
                    this.Response.Cookies.Append("MasaId" , id.ToString());
                    dbContext.Masalar.FindAsync(id).Result.MasaSifresi = masa.SifreOlustur();
                    dbContext.SaveChanges();
                    return RedirectToAction("SifreAyarla");
                }
                else
                {
                    return RedirectToAction("Giris",new { id=id });
                }
            }
        }

        public async Task<IActionResult> SifreAyarla()
        {
            int id = Convert.ToInt32(Request.Cookies["MasaId"]);
            Masa masa = await dbContext.Masalar.FindAsync(id);
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