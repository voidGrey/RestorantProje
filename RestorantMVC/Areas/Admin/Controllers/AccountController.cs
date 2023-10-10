using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Extensions;

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
        public IActionResult UpdatePhoneNumber(string phoneNumber)
        {
            var user = userManager.GetUserAsync(User).Result;
            user.PhoneNumber = phoneNumber;
            var result = userManager.UpdateAsync(user).Result;

            if (result.Succeeded)
            {
                // Başarılı yanıt döndür
                return Json(new { success = true, phone = user.PhoneNumber });
            }

            // Hata durumunda hata yanıtı döndür
            return Json(new { success = false , errors = result.Errors });
        }
    }
}
