using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using System.Security.Claims;

namespace RestorantMVC.Areas.Admin.Components
{
    public class GunlukKarViewComponent : ViewComponent
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;

        public GunlukKarViewComponent(SqlDbContext dbContext , UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string firmaId = userManager.GetUserId((ClaimsPrincipal)this.User);
            // Mevcut tarihi al
            DateTime thisDay = DateTime.Now;
            DateTime test = DateTime.Today.AddDays(-1);

            var thisDayResult = await dbContext.SiparisDetaylar.FirmaFilter(firmaId)
                .Where(value => value.CreateTime > DateTime.Today && value.CreateTime < DateTime.Today.AddDays(1)).ToListAsync();

            var previousDayResult = await dbContext.SiparisDetaylar.FirmaFilter(firmaId)
                .Where(
                value => value.CreateTime < DateTime.Today &&
                value.CreateTime > test
                ).ToListAsync();

            double previousMounthCurrancy = 0;
            foreach (var item in previousDayResult)
            {
                previousMounthCurrancy += item.Fiyat * item.Adet;
            }

            double ThisMounthCurrancy = 0;
            foreach (var item in thisDayResult)
            {
                ThisMounthCurrancy += item.Fiyat * item.Adet;
            }

            double karFarkiYuzde = ((ThisMounthCurrancy - previousMounthCurrancy) / ThisMounthCurrancy) * 100;

            ViewBag.Currancy = ThisMounthCurrancy;
            ViewBag.YuzdelikKar = karFarkiYuzde;

            return View();
        }
    }
}