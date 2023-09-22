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
        public static IQueryable<TModel> FirmaFilter<TModel>(this DbSet<TModel> model , string id) where TModel : BaseEntity
        {
            return model.Where(a => a.FirmaId == id);
        }
        public static async Task<dynamic> SetUser(this Controller model , UserManager<Firma> userManager)
        {
            var user = await userManager.GetUserAsync(model.User);
            model.ViewBag.User = user;
            return model;
        }

    }
}
