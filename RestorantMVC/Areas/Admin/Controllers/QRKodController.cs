using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using RestorantMVC.Areas.Admin.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QRKodController : Controller
    {
        [HttpGet]
        public IActionResult QRKodOlustur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QRKodOlustur(QRCodeModel qRCode)
        {
            //QRCodeGenerator qrGenarator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenarator.CreateQrCode("GELECEK URL MASA ID V.B." , QRCodeGenerator.ECCLevel.Q);
            //QRCode qRCode = new(qrCodeData);
            //Bitmap qrCodeImage = qRCode.GetGraphic(20);
            //return View();
            string host = HttpContext.Request.Scheme+"//"+HttpContext.Request.Host.Value+"/Home/QRScan/";
            
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode( host+qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Image QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = ImageToByte(QrBitmap);

            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            ViewBag.QrCodeUri = QrUri;
            return View();
        }

        public byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream , ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
