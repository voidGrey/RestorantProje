using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Entites.Concrate;
using DAL.Contexts;
using System.Net.WebSockets;

namespace RestorantMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SqlDbContext dbContext;

        public AccountController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            Kullanici user = dbContext.Kullanicilar
                                        .Include(p=>p.Roller)
                                        .FirstOrDefault(p=>p.KullaniciAdi==loginRequest.Username && p.Sifre==loginRequest.Password);

            string roller = string.Empty;
            foreach (var role in user.Roller)
            {
                roller = role.RoleAdi +";";
            }



            if (user!=null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginRequest.Username),
                        new Claim(ClaimTypes.Name, loginRequest.Username),
                        new Claim(ClaimTypes.Role, roller)
                        //new Claim("FullName", user.FullName),
                        //new Claim(ClaimTypes.Role, "Administrator"),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme ,
                                              new ClaimsPrincipal(claimsIdentity) ,
                                              authProperties);
                //var role= user.Roller.Where(p => p.RoleAdi.Contains("Admin")).First();
                // if(role!=null)
                foreach (var role in user.Roller)
                {
                    if(role.RoleAdi=="Admin")
                        return RedirectToAction("Index" , "Admin" , new { area = "Admin" });
                    if (role.RoleAdi == "Musteri")
                        return RedirectToAction("Kategori" , "Menu" , new { area = "Musteri" });
                }
                //return RedirectToAction("Index" , "Admin");
            }
            

            if (ModelState.IsValid)
            {
                if (loginRequest.Username == user.KullaniciAdi && loginRequest.Password == user.Sifre)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginRequest.Username),
                        new Claim(ClaimTypes.Name, loginRequest.Username)
                        //new Claim(ClaimTypes.Email, "email")
                        //new Claim("FullName", user.FullName),
                        //new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme ,
                                                  new ClaimsPrincipal(claimsIdentity) ,
                                                  authProperties);

                    return RedirectToAction("Index" , "Admin");
                }
                else
                {
                    ModelState.AddModelError("Password" , "Username or Password wrong !");
                }
            }


            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
