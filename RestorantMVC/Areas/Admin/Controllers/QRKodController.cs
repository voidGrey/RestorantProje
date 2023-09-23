using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using RestorantMVC.Areas.Admin.Models;
using RestorantMVC.Extensions;
using System.Drawing;
using System.Drawing.Imaging;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class QRKodController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;

        public QRKodController(SqlDbContext dbContext, UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> QRKodOlustur()
        {
            await this.SetUser(userManager);

            return View();
        }

        /// <summary>
        /// İçerisine gönderilen QrCode Modelini işleyip ekrana basar
        /// </summary>
        /// <param name="host">Sitenin url'si</param>
        /// <param name="QrCodeInfo">Site içerisinde ki QRController'e yönlendirilecek MasaID ile QR Datası</param>
        /// <param name="qRCode">QR Kodu</param>
        /// <param name="QrBitMap">QR Resim Dosyası</param>
        /// <param name="BitmapArray">Resimin Byte[] Dönüştürülmüş hali</param>
        /// <param name="QrUri">QRCoder için oluşturulmu formatlı bir string</param>

        [HttpPost]
        public async Task<IActionResult> QRKodOlustur(QRCodeModel qRCode)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);
            //QRCodeGenerator qrGenarator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenarator.CreateQrCode("GELECEK URL MASA ID V.B." , QRCodeGenerator.ECCLevel.Q);
            //QRCode qRCode = new(qrCodeData);
            //Bitmap qrCodeImage = qRCode.GetGraphic(20);
            //return View();
            string host = HttpContext.Request.Scheme+"//"+HttpContext.Request.Host.Value+"/QR/Scan/" ;

            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode( host + qRCode.QRCodeText , QRCodeGenerator.ECCLevel.Q);
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