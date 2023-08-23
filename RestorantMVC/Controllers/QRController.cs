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
            if(id == null || string.IsNullOrEmpty(id.ToString())) 
            {
                return NotFound();
            }
            else
            {
                this.Response.Cookies.Append("MasaId" , id.ToString());
                return Redirect("Home");
            }

        }
    }
}
