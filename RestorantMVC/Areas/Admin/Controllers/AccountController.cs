using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Extensions;
using RestorantMVC.Models;
using System.Text;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Firma> userManager;
        private readonly SqlDbContext dbContext;
        private readonly SignInManager<Firma> signInManager;
        private string firmaId;

        public AccountController(UserManager<Firma> userManager, SqlDbContext dbContext, SignInManager<Firma> signInManager)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","FirmaLogin",new {area = "default"});
        }
        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            var user = await dbContext.Users.FindAsync(firmaId);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhoneNumber(string phoneNumber)
        {
            var user = await userManager.GetUserAsync(User);
            user.PhoneNumber = phoneNumber;
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Başarılı yanıt döndür
                return Json(new { success = true, phone = user.PhoneNumber });
            }

            // Hata durumunda hata yanıtı döndür
            return Json(new { success = false , errors = result.Errors });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordRequest(string currentPassword, string newPassword, string reNewPassword)
        {
            var user = await userManager.GetUserAsync(User);
            
            if(newPassword != reNewPassword) { return Json(new { success = false, error = "Şifreler uyumlu değil." });; }

            try
            {
                var result = await userManager.ChangePasswordAsync(user , currentPassword , newPassword);

                if (result.Succeeded) 
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false , error = result.Errors.FirstOrDefault().Description});
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> ChangeMailRequest(string mailData, string passData)
        {
            var firma = await userManager.GetUserAsync(User);

            if(!await userManager.CheckPasswordAsync(firma,passData)) 
            {
                return Json(new { success = false , error = "Hatalı Şifre" });
            }

            var result = await userManager.GenerateChangeEmailTokenAsync(firma , mailData);


            StringBuilder message = new StringBuilder();
            message.AppendLine("<html>");
            message.AppendLine("<Head>");
            message.AppendLine("<meta charset='UTF-8' />");

            message.AppendLine("</Head>");
            message.AppendLine("<body>");

            message.AppendLine($"<p> Merhaba {firma.UserName}  </p> <br>");
            message.AppendLine("<p> Mail değiştirme isteğiniz üzerine gönderilen Onay Kodu Aşağıdadır. </p>");

            string host = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Admin/Account/ChangeMail?uid=";
            message.AppendLine($"<a href='{host}{mailData}&code={result}'> Onaylayin </a>");


            message.AppendLine("</body>");


            message.AppendLine("</html>");

            EmailHelper email = new EmailHelper();

            bool sonuc = email.SendEmail(firma.Email, message.ToString());

            if (sonuc)
            {
                return Json(new {success = true});

            }
            else
            {
                return Json(new { success = false , error = "Mail gönderiminde bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });

            }
        }

        public async Task<IActionResult> ChangeMail(string uid , string code)
        {
            var firma = await userManager.GetUserAsync(User);
            code = code.Replace(' ' , '+');
            var result = await userManager.ChangeEmailAsync(firma,uid,code);

            if(result.Succeeded)
            {

                return RedirectToAction("Settings");

            }
            else
            {
                return Json("MAİL DEĞİŞİKLİĞİNDE SORUNA RASTLANDI: " + result.Errors.FirstOrDefault());
            }
        }

        public async Task<IActionResult> UpdateVergiDairesi(string vergiDairesi)
        {
            var user = await userManager.GetUserAsync(User);
            user.VergiDairesi = vergiDairesi;

            var result = await userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return Json(new { success = true , vergiDairesi = user.VergiDairesi });
            }

            return Json(new { success = false , errors = result.Errors });
        }
        public async Task<IActionResult> UpdateVergiNo(string vergiNo)
        {
            var user = await userManager.GetUserAsync(User);
            user.VergiNo = vergiNo;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Json(new { success = true , vergiDairesi = user.VergiDairesi });
            }

            return Json(new { success = false , errors = result.Errors });
        }
    }
}
