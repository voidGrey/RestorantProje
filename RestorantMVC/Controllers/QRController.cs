using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Controllers
{
    public class QRController : Controller
    {
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
        /// <param name="id">MasaID</param>
        public IActionResult Scan(int id)
        {
            // Gelen ID'yi Kontrol eder.
            if (id == null || string.IsNullOrEmpty(id.ToString()) || id == 0)
            {
                return Content("Okuttuğunuz QR Geçersiz veya Zarar görmüş lütfen bir garsondan yardım isteyiniz.");
            }
            else
            {
                string value = id.ToString();
                if (Request.Cookies.TryGetValue("MasaId" , out value)) // Kullanıcının Cookie'si var mı diye bakar
                {
                    return RedirectToAction("Index" , "Home");
                }

                //Cookie eklenir.
                this.Response.Cookies.Append("MasaId" , id.ToString());
                return RedirectToAction("Index" , "Home");
            }
        }
    }
}