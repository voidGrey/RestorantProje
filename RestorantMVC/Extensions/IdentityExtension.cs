using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RestorantMVC.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection IdentityAyarlari(this IServiceCollection services)
        {

            string constr = @"Server=(localdb)\mssqllocaldb;Database=IdentityDb;Trusted_Connection=true;TrustServerCertificate=true";
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(constr));



            services.AddIdentity<Firma , IdentityRole>()
                .AddEntityFrameworkStores<SqlDbContext>()
                .AddDefaultTokenProviders(); // Token Olusturmada ise yarayacak bolum


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false; //Olusturulacak sifre icerisinde sayi olsunmu 

                //Kucuk Karakter olsunmu 
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
                options.Lockout.MaxFailedAccessAttempts = 5; // 5 yanlis denemede kilitle
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);// 5 Dakika kilitle

                options.User.RequireUniqueEmail = false; // user icerisinde tekil mail olsun mu 

                options.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöprsştuüvyzwxq0123456789@.-_";
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => { opt.LoginPath = "/Account/Login/"; });
            return services;
        }
    }
}
