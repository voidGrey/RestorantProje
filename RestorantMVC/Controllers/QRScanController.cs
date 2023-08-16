using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Controllers
{
    public class QRScanController : Controller
    {
        public IActionResult Scan(string tableId)
        {
            return RedirectToAction("Index", "Home", new { tableId });
        }
    }
}
