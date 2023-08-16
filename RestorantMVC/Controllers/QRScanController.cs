using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestorantMVC.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Entites.Concrate;
using DAL.Contexts;

namespace RestorantMVC.Controllers
{
    public class QRScanController : Controller
    {
        private readonly SqlDbContext dbContext;

        public QRScanController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        

        public async Task<IActionResult> Scan(int? id)
        {
            var masa = dbContext.Masalar.Find(id);
            if (masa.MasaSifresi == null)
            {
                masa.MasaSifresi = masa.SifreOlustur();
                dbContext.SaveChanges();

                HttpContext.Response.Cookies.Append("MasaId" , id.ToString());
                return RedirectToAction("Home");
            }
            else
            {
                return View(masa);
                //BENİ ŞİFRE GİRİŞ ALANINA YÖNLENDİR ve YANIMDA ID GÖNDER

                /*
                 *return RedirectToAction("MasaController",id)
                 */
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(MasaRequest loginRequest)
        {
            Masa admin = dbContext.Masalar.Find(loginRequest.Id);
            if (ModelState.IsValid)
            {
                if (loginRequest.Sifre == admin.MasaSifresi)
                {


                    return RedirectToAction("Index" , "Admin");
                }
                else
                {
                    ModelState.AddModelError("Password" , "Username or Password wrong !");
                }
            }

            return View();

    }
}