using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entites.Concrate;
using Entites.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace RestorantMVC.Extensions
{
    public static class RestorantExtension
    {
        /// <summary>
        /// Veritabanı tablosu içindeki nesneleri belirli bir Firma ID'ye göre filtrelemek için kullanılan extension method.
        /// </summary>
        /// <typeparam name="TModel">Filtreleme işlemi yapılacak nesne türü.</typeparam>
        /// <param name="model">Filtreleme işlemi uygulanacak olan DbSet nesnesi. (boş bırak)</param>
        /// <param name="id">Filtreleme için kullanılacak olan Firma ID değeri.</param>
        /// <returns>Filtrelenmiş nesneleri içeren bir IQueryable nesnesi.</returns>
        public static IQueryable<TModel> FirmaFilter<TModel>(this DbSet<TModel> model , string id) where TModel : BaseEntity
        {
            return model.Where(a => a.FirmaId == id);
        }
        /// <summary>
        /// Controller nesnesinin içindeki kullanıcı bilgisini ayarlamak ve ViewBag üzerinden kullanıcı bilgisine erişim sağlamak için kullanılan extension method.
        /// </summary>
        /// <param name="model">Controller nesnesi. (this) </param>
        /// <param name="userManager">UserManager<Firma> nesnesi, kullanıcı bilgisini almak için kullanılır.</param>
        /// <returns>Controller nesnesi, kullanıcı bilgisi ViewBag üzerinden ayarlandıktan sonra döndürülür.</returns>
        /// <remarks>
        /// Bu method, bir Controller nesnesinin içindeki kullanıcı bilgisini UserManager aracılığıyla alır ve bu bilgiyi ViewBag.User üzerinden Controller'a ekler.
        /// Kullanıcı bilgisine erişim sağlamak için Controller içinde ViewBag.User kullanabilirsiniz.
        /// </remarks>

        public static async Task<dynamic> SetUser(this Controller model , UserManager<Firma> userManager)
        {
            var user = await userManager.GetUserAsync(model.User);
            model.ViewBag.User = user;
            return model;
        }

    }
}
