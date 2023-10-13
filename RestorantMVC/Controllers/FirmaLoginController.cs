using AutoMapper;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Models;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestorantMVC.Controllers
{
    public class FirmaLoginController : Controller
    {
        private readonly UserManager<Firma> userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<Firma> signInManager;

        public FirmaLoginController(UserManager<Firma> userManager, IMapper mapper, SignInManager<Firma> _signInManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Login()
        {
            LoginDto loginDto = new LoginDto();
            return View(loginDto);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            //Validasyondan geçmedi ise ayni verileri view'e geri gonder
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }
            else
            {

                var  user = await userManager.FindByEmailAsync(loginDto.Email);


                if (user == null)
                {
                    ModelState.AddModelError("" , "Boyle bir kullanici Yoktur");
                    return View(loginDto);
                }

                // Burasi Mail onaylanmi mi ona bakar
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("" , "Mail onaylanmamistir");
                    return View(loginDto);
                }

                //signInManager verilen password ile oturum Acar
                await signInManager.SignOutAsync();
                var result = await signInManager.PasswordSignInAsync(user,loginDto.Password,loginDto.RememberMe,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index" , "Home" , new { Area = "Admin" });
                }

                ModelState.AddModelError("" , "Email yada Sifre Hatalidir");
                return View(loginDto);
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            FirmaRegisterDTO firma = new ();
            return View(firma);
        }
        [HttpPost]
        public async Task<IActionResult> Register(FirmaRegisterDTO firmadto)
        {

            var firma = mapper.Map<Firma>(firmadto);

            if(!ModelState.IsValid) 
            { 
                return View(firmadto);
            }
            var result = await userManager.CreateAsync(firma,firmadto.Password);

            if (result.Succeeded)
            {

                var code = await userManager.GenerateEmailConfirmationTokenAsync(firma);

                StringBuilder message = new StringBuilder();
                message.AppendLine("<html>");
                message.AppendLine("<Head>");
                message.AppendLine("<meta charset='UTF-8' />");

                message.AppendLine("</Head>");
                message.AppendLine("<body>");

                message.AppendLine($"<p> Merhaba {firma.UserName}  </p> <br>");

                message.AppendLine("<p> Uyelik islemlerini tamamlamak icin asagidaki linki tiklayin </p>");

                string host = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/ConfirmEmail?uid=";
                message.AppendLine($"<a href='{host}{firma.Id}&code={code}'> Onaylayin </a>");


                message.AppendLine("</body>");


                message.AppendLine("</html>");

                EmailHelper email = new EmailHelper();

                bool sonuc = email.SendEmail(firma.Email, message.ToString());

                if (sonuc)
                {
                    return RedirectToAction("Index" , "Home");

                }
                else
                {
                    ModelState.AddModelError("" , "Mail Goderiminde hata olustu");
                    return View(firmadto);
                }

            }
            else
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError("Sorunla karşılaşıldı" , error.Description);
                return View(firmadto);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index" , "Home");
        }

        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string uid , string code)
        {

            ConfirmEmailModel model = new();
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(code))
            {
                var user = await userManager.FindByIdAsync(uid);
                code = code.Replace(' ' , '+');
                model.Email = user.Email;
                var result = await userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                    return View(model);
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    model.ErrorDescription = error.Description;
                    model.HasError = true;
                    ModelState.AddModelError("" , error.Description);
                    return View(model);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailModel model)
        {
            return View(model);
        }
    }
}
