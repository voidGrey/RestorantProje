using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Controllers
{
    public class QRScanController : Controller
    {
        public IActionResult Scan(string MasaID)
        {
            TempData["MasaID"] = MasaID;
            return RedirectToAction("Index", "Home");
        }
    }
}
