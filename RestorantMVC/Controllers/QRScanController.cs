using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Controllers
{
    public class QRScanController : Controller
    {
        public IActionResult Index(int? id)
        {
            HttpContext.Response.Cookies.Append("MasaId","5"); 
            return RedirectToAction("Home");
        }
        public IActionResult Scan(string tableId)
        {
            return RedirectToAction("Index", "Home", new { tableId });
        }
    }
}
