using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Models;
using System.Security.Claims;

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
            return RedirectToAction("Login" , "FirmaLogin");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return RedirectToAction("Login", "FirmaLogin");
            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}