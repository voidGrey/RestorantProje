using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using System.Security.Claims;

namespace RestorantMVC.Areas.Admin.Components
{
    public class AylikKarViewComponent : ViewComponent
    {
        private readonly UserManager<Firma> userManager;

        public SqlDbContext dbContext { get; }

        public AylikKarViewComponent(SqlDbContext dbContext, UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            string firmaId = userManager.GetUserId((ClaimsPrincipal)this.User);
            // Mevcut tarihi al
            DateTime thisDay = DateTime.Now;

            // 30 gün öncesine gitmek için TimeSpan oluştur
            TimeSpan thirtyDaysAgo = new TimeSpan(30, 0, 0, 0); // 30 gün = 30 gün * 24 saat = 30 gün * 24 saat * 60 dakika * 60 saniye

            // 30 gün öncesini hesapla ve atama yap
            DateTime thisDayMinus30Days = thisDay.Subtract(thirtyDaysAgo);

            var result = await dbContext.SiparisDetaylar.FirmaFilter(firmaId).Where(p => p.CreateTime > thisDayMinus30Days).ToListAsync();

            double currancy = 0;
            foreach (var item in result)
            {
                currancy += item.Fiyat * item.Adet;
            }

            return View(currancy);
        }
    }
}
