using Microsoft.AspNetCore.Mvc;
using ZXing;

namespace RestorantMVC.Controllers
{
    public class CookieController : Controller
    {
        private static readonly Dictionary<string, CustomerData> CustomerDataDictionary = new Dictionary<string, CustomerData>();

        public IActionResult Index()
        {
            string userCookie = Request.Cookies["user_cookie"];

            if (CustomerDataDictionary.ContainsKey(userCookie))
            {
                return Content($"Merhaba {CustomerDataDictionary[userCookie].Name}! Son işlem: {CustomerDataDictionary[userCookie].LastAction}");
            }

            return Content("QR kod okutulmadı veya geçerli oturum bulunmuyor.");
        }

        public IActionResult ScanQR(string userId)
        {
            
            string userCookie = userId;
            CustomerDataDictionary[userCookie] = new CustomerData { Name = "Müşteri", LastAction = "QR kod tarandı" };

            Response.Cookies.Append("user_cookie", userCookie);
            return RedirectToAction("Index");
        }

        public IActionResult PlaceOrder(string userId, string order)
        {
            if (CustomerDataDictionary.ContainsKey(userId))
            {
                CustomerDataDictionary[userId].LastAction = $"Sipariş verildi: {order}";
            }

            return RedirectToAction("Index");
        }

        public IActionResult MakePayment(string userId, decimal amount)
        {
            if (CustomerDataDictionary.ContainsKey(userId))
            {
                CustomerDataDictionary[userId].LastAction = $"Ödeme yapıldı: {amount:C}";
            }

            return RedirectToAction("Index");
        }
    }

    public class CustomerData
    {
        public string Name { get; set; }
        public string LastAction { get; set; }
    }
}

