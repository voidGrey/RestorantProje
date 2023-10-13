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
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

            Masa masa = await dbContext.Masalar.FirmaFilter(firmaId)
                .Where(m=>m.MasaID == Convert.ToInt32(qRCode.QRCodeText)).FirstOrDefaultAsync();

            if (masa != null)
            {
                // Restoran kimliğini şifrele
                byte[] CryptedFirmaID = await RestorantExtension.EncryptAsync(firmaId , "YeyoYoOyeŞifrehehe");

                string CryptedString = WebEncoders.Base64UrlEncode(CryptedFirmaID);

                // QR kodu tarayıcı sayfasının temel URL'sini al.
                string host = HttpContext.Request.Scheme+"://"+HttpContext.Request.Host.Value+"/QR/Scan/"
                + masa.ID.ToString() + "?f=" + CryptedString;



                // QR kodu verilerini oluştur.

                QRCodeGenerator QrGenerator = new QRCodeGenerator();
                QRCodeData QrCodeInfo = QrGenerator.CreateQrCode( host , QRCodeGenerator.ECCLevel.L);

                // QR kodu görüntüsünü oluştur.
                QRCode QrCode = new QRCode(QrCodeInfo);
                Image QrBitmap = QrCode.GetGraphic(60);

                // QR kodu görüntüsünü bayt dizisine dönüştür.
                byte[] BitmapArray = ImageToByte(QrBitmap);

                // Bayt dizisini base64 dizesine dönüştür.
                string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));

                // Base64 dizesini ViewBag'e kaydet, böylece görünümde görüntülenebilir.
                ViewBag.QrCodeUri = QrUri;
                return View();
            }
            else
            {
                return Json(new { status = "error" , message = "Girdiğiniz ID'de bir masanız bulunmamaktadır." });
            }

            
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